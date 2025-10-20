using UnityEngine;
using UnityEngine.EventSystems;

public class PivotController : MonoBehaviour
{
    [Header("���[�U�[����ݒ�")]
    public float rotationSpeed = 50f;
    public float yMinLimit = -10f;
    public float yMaxLimit = 60f;

    [Header("������]�ݒ�")]
    public float autoRotationSpeed = 45f; // ������]�̑����i�x/�b�j

    private float currentX = 0f;
    private float currentY = 0f;

    // --- �ǉ������ϐ� ---
    private bool isAutoRotating = true; // ������]�����ǂ����̃t���O
    private float totalRotation = 0f;   // ��]�������v�p�x���L�^

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        currentY = angles.y;
        currentX = angles.x;
    }

    void Update()
    {
        // �� ������]�̏��� ��
        if (isAutoRotating)
        {
            // 1������܂�Y������ɉ�]������
            float rotationAmount = autoRotationSpeed * Time.deltaTime;
            currentY += rotationAmount;
            totalRotation += rotationAmount;

            // ��]��K�p
            transform.rotation = Quaternion.Euler(currentX, currentY, 0);

            // ���v��]�p�x��360�x�𒴂����玩����]���I��
            if (totalRotation >= 360f)
            {
                isAutoRotating = false;
            }
        }
        // �� ���[�U�[����̏��� ��
        else
        {
            // UI�𑀍삵�Ă���ꍇ�͎��_�ړ����Ȃ�
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }
            if (Input.touchCount > 0 && EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                return;
            }

            // �}�E�X����
            if (Input.GetMouseButton(0))
            {
                currentY += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
                currentX -= Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
            }

            // �^�b�`����
            if (Input.touchCount == 1)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Moved)
                {
                    currentY += touch.deltaPosition.x * rotationSpeed * 0.1f * Time.deltaTime;
                    currentX -= touch.deltaPosition.y * rotationSpeed * 0.1f * Time.deltaTime;
                }
            }

            // X���̉�]�ɐ�����������
            currentX = Mathf.Clamp(currentX, yMinLimit, yMaxLimit);

            // ��]��K�p
            transform.rotation = Quaternion.Euler(currentX, currentY, 0);
        }
    }
}