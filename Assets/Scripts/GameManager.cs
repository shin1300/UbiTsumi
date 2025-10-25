// ファイル名: GameManager.cs
// ゲーム進行の中枢。生成・操作・ドロップ判定・カメラ切替・モデル読込を管理。
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GLTFast;
using UnityEngine.Networking;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("ゲーム設定")]
    public List<GameObject> animalPrefabs;
    public Transform spawnPoint;
    public float settleTimeLimit = 5f;
    public Vector3 maxAnimalSize = new Vector3(15f, 15f, 15f);
    [Header("物理設定")]
    public PhysicsMaterial animalPhysicMaterial;
    [Header("操作系")]
    public Joystick joystick;
    public Transform cameraTransform;
    public float moveSpeed = 5f;
    [Header("カメラオブジェクト")]
    public GameObject mainCameraObject;
    public GameObject topDownCameraObject;
    // [Header("マーカー設定")]
    // public GameObject shadowMarkerPrefab; // 削除
    [Header("UI設定")]
    public TextMeshProUGUI dropCountText;

    private Dictionary<string, int> dropCounts = new Dictionary<string, int>();
    private int totalPlayers;
    private int currentPlayerIndex;
    private GameObject currentAnimal;
    // private GameObject currentShadowMarker; // 削除
    private bool isAnimalDropped = false;
    private bool isLoadingComplete = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (GameSettings.selectedMode == GameSettings.GameMode.VS)
        {
            totalPlayers = 2;
            currentPlayerIndex = 0;
        }

        UpdateGameUI();

        if (mainCameraObject != null) mainCameraObject.SetActive(true);
        if (topDownCameraObject != null) topDownCameraObject.SetActive(false);
        StartCoroutine(LoadCustomModels());
    }

    void Update()
    {
        if (!isLoadingComplete || currentAnimal == null || isAnimalDropped) return;

        Vector3 moveDirection = Vector3.zero;

        if (mainCameraObject.activeSelf)
        {
            Vector3 camForward = cameraTransform.forward;
            Vector3 camRight = cameraTransform.right;
            camForward.y = 0;
            camRight.y = 0;
            moveDirection = camForward.normalized * joystick.Vertical + camRight.normalized * joystick.Horizontal;
        }
        else if (topDownCameraObject.activeSelf)
        {
            moveDirection = new Vector3(joystick.Horizontal, 0, joystick.Vertical);
        }

        if (moveDirection != Vector3.zero)
        {
            currentAnimal.transform.Translate(moveDirection.normalized * moveSpeed * Time.deltaTime, Space.World);
        }

        // マーカーの位置更新ロジックを削除
        // if (currentShadowMarker != null)
        // {
        //     ...
        // }
    }

    public void DropCurrentAnimal()
    {
        if (currentAnimal == null || isAnimalDropped) return;

        if (GameSettings.selectedMode == GameSettings.GameMode.ScoreAttack)
        {
            string animalName = currentAnimal.name.Replace("(Clone)", "").Trim();
            if (dropCounts.ContainsKey(animalName))
            {
                dropCounts[animalName]++;
            }
            else
            {
                dropCounts[animalName] = 1;
            }
        }
        else if (GameSettings.selectedMode == GameSettings.GameMode.VS)
        {
            currentPlayerIndex = (currentPlayerIndex + 1) % totalPlayers;
        }

        UpdateGameUI();

        isAnimalDropped = true;
        currentAnimal.GetComponent<Rigidbody>().isKinematic = false;
        currentAnimal.AddComponent<FasterFall>();
        StartCoroutine(CheckIfSettled(currentAnimal));
        currentAnimal = null;

        // マーカーの破棄ロジックを削除
        // if (currentShadowMarker != null)
        // {
        //     Destroy(currentShadowMarker);
        // }
    }

    private void UpdateGameUI()
    {
        if (dropCountText == null) return;

        if (GameSettings.selectedMode == GameSettings.GameMode.ScoreAttack)
        {
            string countText = "落とした数\n";
            foreach (var pair in dropCounts)
            {
                countText += pair.Key + ": " + pair.Value + "\n";
            }
            dropCountText.text = countText;
        }
        else if (GameSettings.selectedMode == GameSettings.GameMode.VS)
        {
            dropCountText.text = $"Player {currentPlayerIndex + 1} のターン";
        }
    }

    private void ApplyPhysicsSettings(GameObject animal)
    {
        Rigidbody rb = animal.GetComponent<Rigidbody>();
        if (rb == null) rb = animal.AddComponent<Rigidbody>();
        rb.mass = 50;
        rb.linearDamping = 1.0f;
        rb.angularDamping = 1.0f;

        if (animal.GetComponentInChildren<Collider>() == null)
        {
            MeshFilter[] meshFilters = animal.GetComponentsInChildren<MeshFilter>();
            if (meshFilters.Length > 0)
            {
                foreach (var mf in meshFilters)
                {
                    if (mf.sharedMesh != null)
                    {
                        MeshCollider mc = mf.gameObject.AddComponent<MeshCollider>();
                        mc.convex = true;
                    }
                }
            }
        }

        if (animal.GetComponent<Collider>() == null)
        {
            var boxCollider = animal.AddComponent<BoxCollider>();
            boxCollider.size *= 0.2f;
            boxCollider.isTrigger = true;
        }

        Collider[] allColliders = animal.GetComponentsInChildren<Collider>();
        foreach (Collider col in allColliders)
        {
            col.material = animalPhysicMaterial;
        }
    }

    private IEnumerator CheckIfSettled(GameObject droppedAnimal)
    {
        if (droppedAnimal == null)
        {
            StartCoroutine(SpawnNewAnimal());
            yield break;
        }

        yield return new WaitForSeconds(1f);

        float timer = 0f;
        Rigidbody rb = droppedAnimal.GetComponent<Rigidbody>();

        while (rb != null && !rb.IsSleeping())
        {
            timer += Time.deltaTime;
            if (timer > settleTimeLimit) break;
            yield return null;
        }

        if (droppedAnimal != null)
        {
            droppedAnimal.tag = "SettledAnimal";
        }

        StartCoroutine(SpawnNewAnimal());
    }

    public int GetTotalDropCount()
    {
        int total = 0;
        foreach (var count in dropCounts.Values)
        {
            total += count;
        }
        return total;
    }

    private IEnumerator SpawnNewAnimal()
    {
        isAnimalDropped = false;
        yield return new WaitForSeconds(1.5f);
        if (animalPrefabs.Count == 0) yield break;
        int randomIndex = Random.Range(0, animalPrefabs.Count);
        GameObject prefabToSpawn = animalPrefabs[randomIndex];
        currentAnimal = Instantiate(prefabToSpawn, spawnPoint.position, Quaternion.identity);
        currentAnimal.SetActive(true);
        ApplyPhysicsSettings(currentAnimal);
        AdjustScale(currentAnimal);
        currentAnimal.GetComponent<Rigidbody>().isKinematic = true;

        // マーカーの生成ロジックを削除
        // if (shadowMarkerPrefab != null)
        // {
        //     currentShadowMarker = Instantiate(shadowMarkerPrefab);
        // }
    }

    // 他の関数（LoadCustomModels, ProcessGltfData, AdjustScale, Rotateなど）は元のまま
    private IEnumerator LoadCustomModels()
    {
        if (DataPersistence.instance != null && DataPersistence.instance.customModelPaths.Count > 0)
        {
            foreach (string path in DataPersistence.instance.customModelPaths)
            {
                string formattedPath = "file:///" + path;
                UnityWebRequest www = UnityWebRequest.Get(formattedPath);
                www.downloadHandler = new DownloadHandlerBuffer();
                yield return www.SendWebRequest();
                if (www.result == UnityWebRequest.Result.Success)
                {
                    byte[] data = www.downloadHandler.data;
                    yield return ProcessGltfData(data);
                }
            }
        }
        isLoadingComplete = true;
        StartCoroutine(SpawnNewAnimal());
    }
    private IEnumerator ProcessGltfData(byte[] data)
    {
        var gltf = new GltfImport();
        var task = gltf.Load(data);
        while (!task.IsCompleted) { yield return null; }
        if (task.Result)
        {
            GameObject customModel = new GameObject("CustomAnimal");
            var instantiator = new GameObjectInstantiator(gltf, customModel.transform);
            var instantiateTask = gltf.InstantiateMainSceneAsync(instantiator);
            while (!instantiateTask.IsCompleted) { yield return null; }
            if (instantiateTask.Result)
            {
                ApplyPhysicsSettings(customModel);
                AdjustScale(customModel);
                customModel.tag = "Animal";
                customModel.SetActive(false);
                animalPrefabs.Add(customModel);
            }
        }
    }
    private void AdjustScale(GameObject animalObject)
    {
        Bounds bounds = new Bounds();
        Renderer[] renderers = animalObject.GetComponentsInChildren<Renderer>();
        if (renderers.Length > 0)
        {
            bounds = renderers[0].bounds;
            for (int i = 1; i < renderers.Length; i++)
            {
                bounds.Encapsulate(renderers[i].bounds);
            }
            float maxDim = Mathf.Max(bounds.size.x, bounds.size.y, bounds.size.z);
            if (maxDim > 0.001f)
            {
                float targetSize = Mathf.Min(maxAnimalSize.x, maxAnimalSize.y, maxAnimalSize.z);
                float scaleFactor = targetSize / maxDim;
                animalObject.transform.localScale *= scaleFactor;
            }
        }
    }
    public void RotateX_Positive() { if (currentAnimal != null) currentAnimal.transform.Rotate(15f, 0, 0); }
    public void RotateX_Negative() { if (currentAnimal != null) currentAnimal.transform.Rotate(-15f, 0, 0); }
    public void RotateY_Positive() { if (currentAnimal != null) currentAnimal.transform.Rotate(0, 15f, 0); }
    public void RotateY_Negative() { if (currentAnimal != null) currentAnimal.transform.Rotate(0, -15f, 0); }
    public void RotateZ_Positive() { if (currentAnimal != null) currentAnimal.transform.Rotate(0, 0, 15f); }
    public void RotateZ_Negative() { if (currentAnimal != null) currentAnimal.transform.Rotate(0, 0, -15f); }
    public void ResetAnimalTransform()
    {
        if (currentAnimal != null && !isAnimalDropped)
        {
            currentAnimal.transform.position = spawnPoint.position;
            currentAnimal.transform.rotation = Quaternion.identity;
        }
    }
    public void ToggleCameraView()
    {
        if (mainCameraObject.activeSelf)
        {
            mainCameraObject.SetActive(false);
            topDownCameraObject.SetActive(true);
        }
        else
        {
            mainCameraObject.SetActive(true);
            topDownCameraObject.SetActive(false);
        }
    }
}
