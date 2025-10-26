# UbiTsumi

[![Unity](https://img.shields.io/badge/Unity-6000.0.48f1-blue?logo=unity)](#)
![Platform](https://img.shields.io/badge/Platform-Android-lightgrey)
![License](https://img.shields.io/badge/License-MIT-green)

研究室メンバーが楽しめる「動物タワー風」3Dゲーム（Unity）。身近な場所（研究室）を舞台に、研究室にあるモノをゲームオブジェクトとして取り込んで遊べるデモ兼ポートフォリオです。

## 🎥 Demo

<video
  src="https://raw.githubusercontent.com/shin1300/UbiTsumi/develop/docs/movie/demo.mp4"
  controls
  playsinline
  muted
  width="720">
</video>

> GitHub のファイルサイズ制限等で再生できない場合があります。その際はダウンロードして再生してください。

## 🎯 背景と目的（Why）
- 見せ場重視のポートフォリオ用デモとして、研究室メンバーがすぐに楽しめる体験を作る。
- よく利用する「研究室」をステージ化し、身の回りのモノを3Dモデル（GLB）として取り込み、積んで遊べるようにする。
- 実機（Android）で軽快に動くことを重視。環境構築よりも体験・工夫の説明を重視。

## 🧠 工夫した点（How）
- ステージ最適化（Blender）
  - ポリゴン数の削減、テクスチャ解像度のダウンサンプリング、不要要素の削除でモバイルでも軽量化。
- 実物モデルの取り込み
  - GLB（glTF）をそのまま読み込み可能。研究室のオブジェクトを簡単にゲーム内へ持ち込める。
  - Android 端末ストレージからのファイル選択 UI（SimpleFileBrowser）を用意。
- 遊びやすさ
  - 三人称視点＋トップダウン視点の切替／移動操作。モードは ScoreAttack / VS を想定。
  - 仮想スティック（Joystick Pack）は再配布不可のため「各自インポート」で利用可能。未導入時はキーボード操作に自動フォールバック。

## 🧰 使用技術（Tech Stack）
- Unity 6000.0.48f1（URP 17.x）
- glTFast（GLB 読み込み）
- SimpleFileBrowser（Android ストレージからのファイル選択）
- TextMesh Pro（UI）
- Starter Assets（カメラ・入力のベース）
- 物理挙動（Rigidbody / Collider / PhysicsMaterial）

詳細なライセンスと出典は `ThirdPartyNotices.md` を参照してください。

## ▶ Quick Play
1. Unity Hub でプロジェクトを開く。
2. シーン `Assets/Scenes/Home.unity` を開く。
3. 再生ボタンで開始（キーボード操作／仮想スティックは任意導入）。

## 📦 Quick Build (Android)
- Platform: Android
- Scripting Backend: IL2CPP / Mono（どちらでも可）
- SDK/NDK/JDK: Unity Hub 管理の推奨

## 🗂️ フォルダ構成（抜粋）
- `Assets/Scenes` Home / GameScene
- `Assets/Scripts` ゲームロジック（GameManager など）
- `Assets/Animals` 同梱モデル（出典確認中のため最小限に整理）
- `Assets/Plugins` SimpleFileBrowser など
- `Assets/StarterAssets` カメラ・入力のベース

## 🧩 外部アセットの導入（再配布不可のもの）
- SlimUI Modern Menu 1
  - Asset Store の EULA により再配布不可のため、必要な方は各自インポートしてください。
  - インポート後は `Home.unity` / `GameScene.unity` の参照が解決されます。
  - TextMesh Pro を使用している場合は Window > TextMeshPro > Import TMP Essential Resources も実行してください。
- Joystick Pack（任意）
  - リポジトリには含めていません（EULA のため）。導入手順は `docs/controls.md` を参照。
  - 定義シンボル `JOYSTICK_PACK` を設定すると `GameManager` が自動参照。未導入時はキーボード操作にフォールバックします。

## 📜 ライセンス
- MIT License（`LICENSE`）
- 付属アセットの出典・ライセンスは `ThirdPartyNotices.md` を参照

---
補足：動画プレビューはファイルサイズにより GitHub 上で再生できない場合があります。`docs/movie/demo.mp4` をローカル再生するか、軽量プレビュー動画を用意してください。
