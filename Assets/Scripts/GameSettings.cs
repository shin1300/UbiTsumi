// ファイル名: GameSettings.cs

// 選択されたゲームモード（ScoreAttack / VS）を保持する静的設定クラス。
public static class GameSettings
{
    // ゲームモードの種類を定義
    public enum GameMode
    {
        ScoreAttack,
        VS
    }

    // 選択されたゲームモードを保持
    public static GameMode selectedMode;
}
