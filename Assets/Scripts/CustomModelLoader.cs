using System.Collections;
using UnityEngine;
using GLTFast;
using TMPro;
using System.IO;
using UnityEngine.Networking;
using SimpleFileBrowser;
using UnityEngine.Android;
using System.Threading.Tasks;

// 端末からGLBモデルを読み込み、プレビューに追加するUIローダー（Android対応）。
public class CustomModelLoader : MonoBehaviour
{
    [Header("UI設定")]
    public GameObject loadingIndicator;
    public GameObject completionIndicator;

    [Header("プレビュー機能")]
    public ModelPreviewer modelPreviewer;

    public void OnClick_OpenModelFile()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.ExternalStorageRead))
        {
            Permission.RequestUserPermission(Permission.ExternalStorageRead);
            return;
        }

        FileBrowser.SetFilters(true, new FileBrowser.Filter("GLB Models", ".glb"));
        StartCoroutine(ShowLoadDialogCoroutine());
    }

    private IEnumerator ShowLoadDialogCoroutine()
    {
        yield return FileBrowser.WaitForLoadDialog(FileBrowser.PickMode.Files, false, null, null, "Select GLB Model", "Load");

        if (FileBrowser.Success)
        {
            string filePath = FileBrowser.Result[0];
            StartCoroutine(LoadFileCoroutine(filePath));
        }
    }

    private IEnumerator LoadFileCoroutine(string filePath)
    {
        if (loadingIndicator != null) loadingIndicator.SetActive(true);
        if (completionIndicator != null) completionIndicator.SetActive(false);

        string formattedPath = "file:///" + filePath;
        UnityWebRequest www = UnityWebRequest.Get(formattedPath);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("ファイルの読み込みに失敗しました: " + www.error);
            if (loadingIndicator != null) loadingIndicator.SetActive(false);
        }
        else
        {
            byte[] data = www.downloadHandler.data;
            ProcessGltfData(data, filePath);
        }
    }

    private async void ProcessGltfData(byte[] data, string originalPath)
    {
        var gltf = new GltfImport();
        bool success = await gltf.Load(data);

        if (loadingIndicator != null) loadingIndicator.SetActive(false);

        if (success)
        {
            DataPersistence.instance.customModelPaths.Add(originalPath);
            Debug.Log("カスタムモデルのパスを追加しました: " + originalPath);

            GameObject previewInstance = new GameObject("PreviewModel_" + DataPersistence.instance.customModelPaths.Count);
            var instantiator = new GameObjectInstantiator(gltf, previewInstance.transform);
            bool instantiateSuccess = await gltf.InstantiateMainSceneAsync(instantiator);

            if (instantiateSuccess)
            {
                if (modelPreviewer != null)
                {
                    modelPreviewer.AddPreviewModel(previewInstance);
                }
                else
                {
                    Debug.LogError("InspectorでModelPreviewerが設定されていません！");
                    Destroy(previewInstance);
                }
            }
            else
            {
                Destroy(previewInstance);
                Debug.LogError("GLBモデルのインスタンス化に失敗しました。");
            }

            if (completionIndicator != null)
            {
                StartCoroutine(ShowCompletionIndicator());
            }
        }
        else
        {
            Debug.LogError("GLBデータの解析に失敗しました。");
        }
    }

    private IEnumerator ShowCompletionIndicator()
    {
        completionIndicator.SetActive(true);
        yield return new WaitForSeconds(2f);
        completionIndicator.SetActive(false);
    }
}
