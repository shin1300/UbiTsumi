using UnityEngine;
using UnityEngine.EventSystems;

public class PivotController : MonoBehaviour
{
    [Header("ユーザー操作設定")]
    public float rotationSpeed = 50f;
    public float yMinLimit = -10f;
    public float yMaxLimit = 60f;

    [Header("自動回転設定")]
    public float autoRotationSpeed = 45f; // 自動回転の速さ（度/秒）

    private float currentX = 0f;
    private float currentY = 0f;

    // --- 追加した変数 ---
    private bool isAutoRotating = true; // 自動回転中かどうかのフラグ
    private float totalRotation = 0f;   // 回転した合計角度を記録

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        currentY = angles.y;
        currentX = angles.x;
    }

    void Update()
    {
        // ▼ 自動回転の処理 ▼
        if (isAutoRotating)
        {
            // 1周するまでY軸周りに回転させる
            float rotationAmount = autoRotationSpeed * Time.deltaTime;
            currentY += rotationAmount;
            totalRotation += rotationAmount;

            // 回転を適用
            transform.rotation = Quaternion.Euler(currentX, currentY, 0);

            // 合計回転角度が360度を超えたら自動回転を終了
            if (totalRotation >= 360f)
            {
                isAutoRotating = false;
            }
        }
        // ▼ ユーザー操作の処理 ▼
        else
        {
            // UIを操作している場合は視点移動しない
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }
            if (Input.touchCount > 0 && EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                return;
            }

            // マウス操作
            if (Input.GetMouseButton(0))
            {
                currentY += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
                currentX -= Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
            }

            // タッチ操作
            if (Input.touchCount == 1)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Moved)
                {
                    currentY += touch.deltaPosition.x * rotationSpeed * 0.1f * Time.deltaTime;
                    currentX -= touch.deltaPosition.y * rotationSpeed * 0.1f * Time.deltaTime;
                }
            }

            // X軸の回転に制限をかける
            currentX = Mathf.Clamp(currentX, yMinLimit, yMaxLimit);

            // 回転を適用
            transform.rotation = Quaternion.Euler(currentX, currentY, 0);
        }
    }
}