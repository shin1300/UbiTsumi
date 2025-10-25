# UbiTsumi

モバイル向けの「動物タワー風」3Dゲーム（Unity）。

## 概要
- プレイ: Home.unity から再生（仮想ジョイスティック対応）
- ゲーム: 動物/オブジェクトを積み上げ、安定させる
- カスタムモデル: GLB 取り込み（glTFast + SimpleFileBrowser）に対応（設定により切替）

## Unity バージョン
- ProjectSettings/ProjectVersion.txt を参照（例: 6000.0.48f1）

## 起動手順（開発）
1. Unity Hub でプロジェクトを開く
2. シーン `Assets/Scenes/Home.unity` を開く
3. 再生ボタンを押す

## Android ビルド（簡易）
- Platform: Android
- Scripting Backend: IL2CPP（推奨）/Mono
- SDK/NDK/JDK: Unity Hub 管理のものを推奨
- 後続で `docs/build-notes.md` に詳細を追記予定

## フォルダ構成（抜粋）
- `Assets/Scenes` シーン（Home/GameScene ほか）
- `Assets/Scripts` ゲームロジック（GameManager 他）
- `Assets/Animals` モデル類（必要最低限のみ）
- `Assets/Plugins` 外部プラグイン（SimpleFileBrowser 等）
- `Assets/StarterAssets` 入力/カメラ等のスターターアセット

## 依存アセット（主要）
- glTFast（com.unity.cloud.gltfast）
- SimpleFileBrowser（Android ファイル選択）
- Joystick Pack（仮想ジョイスティック）
- TextMesh Pro
- UCLA Game Lab Wireframe Shader

詳細な出典とライセンスは `ThirdPartyNotices.md` を参照。

## 設定（バージョン管理向け）
- Editor Settings: Visible Meta Files
- Asset Serialization: Force Text
  - 設定スクリーンショットを `docs/images/` に追加予定

## ライセンス
このリポジトリは MIT ライセンスで公開されています。`LICENSE` を参照。

## 命名規則とディレクトリ構成（ガイド）
- Scenes
  - `Home.unity`（起動用）/ `GameScene.unity`（本編）。重複するホームは作らない。
- Scripts
  - クラス/ファイル名はパスカルケース（例: `GameManager`, `DataPersistence`）。用途別サブフォルダは任意。
  - 先頭に1行の概要コメントを付与（役割が一目で分かるように）。
- Assets/Animals
  - 軽量サンプルのみ常備。大容量は Git LFS 管理（`.gitattributes` 済）や任意導入に留める。
- Plugins
  - 外部プラグインのみ配置。自作コードは `Assets/Scripts` に置く。
- .meta（運用要点）
  - 残すアセットは `.meta` 必須（GUID維持）。削除時は同階層の `.meta` も同時に削除。
  - 改名/移動は Unity エディタ上で実施（手動リネームは参照切れの原因）。
