// �t�@�C����: ScoreManager.cs
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public static class ScoreManager
{
    private const string HighScoresKey = "HighScores"; // PlayerPrefs�Ŏg���L�[
    private const int MaxScores = 5; // �����L���O�ɕۑ�����ő吔

    // �V�����X�R�A��ǉ�����֐�
    public static void AddScore(int newScore)
    {
        // �����̃X�R�A��ǂݍ��ށi�Ȃ���΋�̕�����j
        string scoresString = PlayerPrefs.GetString(HighScoresKey, "");
        List<int> scores = new List<int>();

        if (!string.IsNullOrEmpty(scoresString))
        {
            // ������𕪊����ă��X�g�ɕϊ�
            scores = scoresString.Split(',').Select(int.Parse).ToList();
        }

        // �V�����X�R�A��ǉ�
        scores.Add(newScore);

        // �X�R�A���~���i�傫�����j�ɕ��ёւ��A���5���������c��
        List<int> sortedScores = scores.OrderByDescending(s => s).Take(MaxScores).ToList();

        // ���X�g���J���}��؂�̕�����ɖ߂�
        string newScoresString = string.Join(",", sortedScores);

        // PlayerPrefs�ɕۑ�
        PlayerPrefs.SetString(HighScoresKey, newScoresString);
        PlayerPrefs.Save(); // �ύX���f�B�X�N�ɏ�������
    }

    // �ۑ�����Ă���X�R�A�����X�g�Ƃ��Ď擾����֐�
    public static List<int> GetScores()
    {
        string scoresString = PlayerPrefs.GetString(HighScoresKey, "");
        if (string.IsNullOrEmpty(scoresString))
        {
            return new List<int>(); // �X�R�A���Ȃ���΋�̃��X�g��Ԃ�
        }

        return scoresString.Split(',').Select(int.Parse).ToList();
    }
}