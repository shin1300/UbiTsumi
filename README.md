# UbiTsumi 🐾

[![Unity](https://img.shields.io/badge/Unity-6000.0.48f1-blue?logo=unity)](#)
![Platform](https://img.shields.io/badge/Platform-Android-lightgrey)
![License](https://img.shields.io/badge/License-MIT-green)

モバイル向けの「動物タワー風」3Dゲーム（Unity）。最小構成で起動・確認できるように整えています。

## 🎥 Demo
- 動画: [docs/movie/demo.mp4](docs/movie/demo.mp4)
  - GitHubのプレビュー制限で再生できない場合はリンク先でダウンロードしてご覧ください

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