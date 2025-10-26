// ファイル名: ScoreManager.cs
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

// ハイスコアを PlayerPrefs に保存・取得するユーティリティ（最大5件）。
public static class ScoreManager
{
    private const string HighScoresKey = "HighScores"; // PlayerPrefsで使うキー
    private const int MaxScores = 5; // ランキングに保存する最大数

    // 新しいスコアを追加する関数
    public static void AddScore(int newScore)
    {
        // 既存のスコアを読み込む（なければ空の文字列）
        string scoresString = PlayerPrefs.GetString(HighScoresKey, "");
        List<int> scores = new List<int>();

        if (!string.IsNullOrEmpty(scoresString))
        {
            // 文字列を分割してリストに変換
            scores = scoresString.Split(',').Select(int.Parse).ToList();
        }

        // 新しいスコアを追加
        scores.Add(newScore);

        // スコアを降順（大きい順）に並び替え、上位5件だけを残す
        List<int> sortedScores = scores.OrderByDescending(s => s).Take(MaxScores).ToList();

        // リストをカンマ区切りの文字列に戻す
        string newScoresString = string.Join(",", sortedScores);

        // PlayerPrefsに保存
        PlayerPrefs.SetString(HighScoresKey, newScoresString);
        PlayerPrefs.Save(); // 変更をディスクに書き込む
    }

    // 保存されているスコアをリストとして取得する関数
    public static List<int> GetScores()
    {
        string scoresString = PlayerPrefs.GetString(HighScoresKey, "");
        if (string.IsNullOrEmpty(scoresString))
        {
            return new List<int>(); // スコアがなければ空のリストを返す
        }

        return scoresString.Split(',').Select(int.Parse).ToList();
    }
}
