// �t�@�C����: HomeMenu.cs

using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeMenu : MonoBehaviour
{
    // �uScore Attack�v�{�^���ɐݒ肷��֐�
    public void OnClick_ScoreAttack()
    {
        GameSettings.selectedMode = GameSettings.GameMode.ScoreAttack;
        SceneManager.LoadScene("GameScene"); // �Q�[���V�[�������Ⴄ�ꍇ�͏C�����Ă�������
    }

    // �uVS Mode�v�{�^���ɐݒ肷��֐�
    public void OnClick_VS()
    {
        GameSettings.selectedMode = GameSettings.GameMode.VS;
        SceneManager.LoadScene("GameScene"); // �Q�[���V�[�������Ⴄ�ꍇ�͏C�����Ă�������
    }
}