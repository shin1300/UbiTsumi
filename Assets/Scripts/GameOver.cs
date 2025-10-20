using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // �ǂ�ȃI�u�W�F�N�g���ڐG���������O�ɏo�͂���
        Debug.Log("�g���K�[�ɐڐG�I �I�u�W�F�N�g��: " + other.name + ", �^�O: " + other.tag);

        // �ڐG�����I�u�W�F�N�g�̃^�O�� "Animal" ��������
        if (other.CompareTag("Animal"))
        {
            Debug.Log("�Q�[���I�[�o�[�I " + other.name + " ���������܂����B");
            Invoke("ReturnToHome", 1f);
        }
    }

    void ReturnToHome()
    {
        // ���Ȃ��̃z�[���V�[���̖��O�ɍ��킹�Ă�������
        SceneManager.LoadScene("Home");
    }
}