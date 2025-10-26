# Controls and Joystick Pack

このプロジェクトは、Joystick Pack が未導入でもビルド可能です。未導入時はキーボード（`Input.GetAxis("Horizontal/Vertical")`）で操作できます。

Joystick Pack を使う場合（再配布不可・各自インポート）

1. Unity Asset Store から「Joystick Pack」を入手・プロジェクトにインポート
2. シーン上の `GameManager` に含まれる操作コードが自動連携します（定義シンボルの設定で切替）
3. 定義シンボルを設定（任意）
   - Project Settings > Player > Other Settings > Scripting Define Symbols に `JOYSTICK_PACK` を追加
   - シンボル未設定でもキーボード操作で動作します

注意: Joystick Pack は Asset Store EULA によりリポジトリに同梱できません。

