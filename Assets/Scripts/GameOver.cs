using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // どんなオブジェクトが接触したかログに出力する
        Debug.Log("トリガーに接触！ オブジェクト名: " + other.name + ", タグ: " + other.tag);

        // 接触したオブジェクトのタグが "Animal" だったら
        if (other.CompareTag("Animal"))
        {
            Debug.Log("ゲームオーバー！ " + other.name + " が落下しました。");
            Invoke("ReturnToHome", 1f);
        }
    }

    void ReturnToHome()
    {
        // あなたのホームシーンの名前に合わせてください
        SceneManager.LoadScene("Home");
    }
}