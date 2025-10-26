# UbiTsumi 🐾

[![Unity](https://img.shields.io/badge/Unity-6000.0.48f1-blue?logo=unity)](#)
![Platform](https://img.shields.io/badge/Platform-Android-lightgrey)
![License](https://img.shields.io/badge/License-MIT-green)

モバイル向けの「動物タワー風」3Dゲーム（Unity）。最小構成で起動・確認できるように整えています。

## 🎥 Demo

![Demo](https://github.com/user-attachments/assets/ad2d3c38-0f14-4bed-9956-113ea5e775a8)

## ⚡ Quick Play
1. Unity Hub でプロジェクトを開く
2. シーン `Assets/Scenes/Home.unity` を開く
3. 再生ボタンを押す（仮想ジョイスティック対応）

## 📦 Quick Build (Android)
- Platform: Android
- Scripting Backend: IL2CPP（推奨）/ Mono
- SDK/NDK/JDK: Unity Hub 管理のものを推奨

## 📁 フォルダ構成（抜粋）
- `Assets/Scenes` シーン（Home / GameScene）
- `Assets/Scripts` ゲームロジック（GameManager ほか）
- `Assets/Animals` モデル類（必要最低限のみ）
- `Assets/Plugins` 外部プラグイン（SimpleFileBrowser 等）
- `Assets/StarterAssets` 入力/カメラ等のスターターアセット（GameScene で参照あり）

## 🔗 依存アセット（主要）
- glTFast（GLB読み込み）
- SimpleFileBrowser（Android ファイル選択）
- Joystick Pack（仮想ジョイスティック）
- TextMesh Pro
- UCLA Game Lab Wireframe Shader

詳細な出典とライセンスは `ThirdPartyNotices.md` を参照してください。

## 🧭 命名規則とディレクトリ構成（ガイド）
- Scenes: `Home.unity`（起動） / `GameScene.unity`（本編）
- Scripts: クラス/ファイル名はパスカルケース（例: `GameManager`, `DataPersistence`）。用途別にサブフォルダ可。先頭に1行の概要コメントを付与
- Animals: 軽量サンプルのみ常備。大容量は Git LFS 管理や任意導入に留める
- Plugins: 外部プラグインのみ配置。自作コードは `Assets/Scripts` に置く
- .meta（運用要点）: 残すアセットは `.meta` 必須（GUID維持）。削除時は同階層の `.meta` も同時に削除。改名/移動は Unity エディタ上で実施

## 📜 ライセンス
MIT License（`LICENSE` を参照）

## 🧩 SlimUI の導入（公開リポジトリ方針）
本リポジトリには SlimUI のアセットは含めていません（Asset Store EULAに従い再配布不可のため）。

SlimUI を使ったメニュー/アイコンを利用するには、各自の環境でインポートしてください。

1. Unity Asset Store から「SlimUI Modern Menu 1」を取得し、プロジェクトにインポート（バージョンは任意の安定版）
2. インポート後に `Home.unity` / `GameScene.unity` を開くと、Main_Menu などの参照が自動解決されます
3. TextMesh Pro を使用している場合は Window > TextMeshPro > Import TMP Essential Resources も実行

補足: SlimUI を含めたプレイ映像（デモ動画）の公開は可能ですが、アセット本体の再配布はできません
