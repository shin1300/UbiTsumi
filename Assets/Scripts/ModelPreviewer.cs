using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

// 読み込んだモデルのスケール調整・整列・自動回転を行うプレビュー表示コンポーネント。
public class ModelPreviewer : MonoBehaviour
{
    [Header("プレビュー設定")]
    public Transform previewParent;
    // public GameObject wireframePrefab; // ★ 削除
    public float modelSpacing = 2.0f;
    public float rotationSpeed = 20f;

    private List<GameObject> previewModels = new List<GameObject>();
    // private List<GameObject> wireframes = new List<GameObject>(); // ★ 削除

    void Update()
    {
        foreach (var model in previewModels)
        {
            if (model != null && model.activeInHierarchy)
            {
                model.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
            }
        }
    }

    public void AddPreviewModel(GameObject model)
    {
        previewModels.Add(model);
        model.transform.SetParent(previewParent, false);
        model.SetActive(false);
    }

    private void ArrangeModels()
    {
        /* ★ 削除
        foreach (var wireframe in wireframes)
        {
            Destroy(wireframe);
        }
        wireframes.Clear();
        */

        if (previewModels.Count == 0) return;

        float totalWidth = 0;
        List<float> modelWidths = new List<float>();

        foreach (var model in previewModels)
        {
            AdjustScale(model);
            Bounds bounds = GetCombinedBounds(model);
            modelWidths.Add(bounds.size.x);
            totalWidth += bounds.size.x;
        }
        totalWidth += (previewModels.Count - 1) * modelSpacing;

        float currentX = -totalWidth / 2.0f;

        for (int i = 0; i < previewModels.Count; i++)
        {
            GameObject model = previewModels[i];

            float modelWidth = modelWidths[i];
            model.transform.localPosition = new Vector3(currentX + modelWidth / 2.0f, 0, 0);

            /* ★ 削除
            if (wireframePrefab != null)
            {
                // ...ワイヤーフレーム生成コード...
            }
            */

            currentX += modelWidth + modelSpacing;
        }
    }

    public void ShowAllPreviews()
    {
        if (previewModels.Count == 0) return;

        previewParent.gameObject.SetActive(true);
        foreach (var model in previewModels)
        {
            model.SetActive(true);
        }
        ArrangeModels();
    }

    public void HideAllPreviews()
    {
        previewParent.gameObject.SetActive(false);
    }

    private Bounds GetCombinedBounds(GameObject obj)
    {
        Renderer[] renderers = obj.GetComponentsInChildren<Renderer>();
        if (renderers.Length == 0) return new Bounds(obj.transform.position, Vector3.zero);

        Bounds bounds = renderers[0].bounds;
        for (int i = 1; i < renderers.Length; i++)
        {
            bounds.Encapsulate(renderers[i].bounds);
        }

        return new Bounds(Vector3.zero, new Vector3(
             bounds.size.x / obj.transform.lossyScale.x,
             bounds.size.y / obj.transform.lossyScale.y,
             bounds.size.z / obj.transform.lossyScale.z
        ));
    }

    private void AdjustScale(GameObject modelObject)
    {
        Bounds bounds = GetCombinedBounds(modelObject);
        if (bounds.size == Vector3.zero) return;

        float maxDim = Mathf.Max(bounds.size.x, bounds.size.y, bounds.size.z);
        if (maxDim > 0.001f)
        {
            float targetSize = 1.5f;
            float scaleFactor = targetSize / maxDim;
            modelObject.transform.localScale = Vector3.one * scaleFactor;
        }
    }
}
