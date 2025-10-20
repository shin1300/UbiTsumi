// ファイル名: HomeMenu.cs

using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeMenu : MonoBehaviour
{
    // 「Score Attack」ボタンに設定する関数
    public void OnClick_ScoreAttack()
    {
        GameSettings.selectedMode = GameSettings.GameMode.ScoreAttack;
        SceneManager.LoadScene("GameScene"); // ゲームシーン名が違う場合は修正してください
    }

    // 「VS Mode」ボタンに設定する関数
    public void OnClick_VS()
    {
        GameSettings.selectedMode = GameSettings.GameMode.VS;
        SceneManager.LoadScene("GameScene"); // ゲームシーン名が違う場合は修正してください
    }
}