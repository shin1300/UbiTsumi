# UbiTsumi

[![Unity](https://img.shields.io/badge/Unity-6000.0.48f1-blue?logo=unity)](#)
![Platform](https://img.shields.io/badge/Platform-Android-lightgrey)
![License](https://img.shields.io/badge/License-MIT-green)
![Status](https://img.shields.io/badge/Status-Active-brightgreen)

> **NOTE**  
> 研究室を舞台にした「動物タワー風」3Dゲーム（Unity）。研究室にあるモノを GLB として読み込んで積んで遊べる、デモ兼ポートフォリオです。

---

## Table of Contents
- [Demo](#demo)
- [Overview](#overview)
- [Quick Start](#quick-start)
- [Features](#features)
- [Controls](#controls)
- [Tech Stack](#tech-stack)
- [Build (Android)](#build-android)
- [Folder Structure](#folder-structure)
- [External Assets](#external-assets)
- [License](#license)
- [Project Status](#project-status)
- [Author](#author)

---

## Demo
[![Demo](docs/images/demo.gif)](https://github.com/user-attachments/assets/ad2d3c38-0f14-4bed-9956-113ea5e775a8)

> **TIP**  
> 画像をクリックすると GitHub 内の動画プレイヤーが開きます。再生できない場合はリンク先でダウンロードしてください。

---

## Overview
- 研究室空間をシーン化し、**身近なモノをゲームオブジェクトとして積める**。
- **GLB（glTF）取込対応**：Android 端末ストレージから選ぶだけでゲームに参加。
- **視点切替**（俯瞰/肩越し）＋**安定判定→次スポーン**のテンポ重視。

> **STATUS**  
> 動作対象：Android / Unity 6000.0.48f1（URP）。シーンは `Home.unity` → `GameScene.unity`。

---

## Quick Start
1. Unity Hub でプロジェクトを開く  
2. `Assets/Scenes/Home.unity` を開く  
3. ▶ を押して実行（仮想スティック未導入でもキーボードで動作）

> **TIP**  
> Joystick Pack を未導入でもフォールバックします。操作は下記「Controls」を参照。

---

## Features
- **GLB 取込**：glTFast で端末から `.glb` を読み込み、スケーリング調整後にプール追加
- **モード**：ScoreAttack（総ドロップ数） / VS（手番交代）
- **視点/操作**：俯瞰 ↔ 肩越し、回転・リセット、仮想スティック（任意）
- **パフォーマンス配慮**：Blender でポリゴン/テクスチャ最適化、物理は `Rigidbody/Collider/PhysicsMaterial`

> **NOTE**  
> 一部アセットは再配布不可のため各自インポートが必要です（下記「External Assets」を参照）。

---

## Controls
- **待機中**：仮想スティックで左右/前後移動  
- **落下**：ボタンで投下 → 静止で安定判定 → 次スポーン  
- **視点**：ワンタッチ切替（俯瞰 / 肩越し）

> **TIP**  
> キーボード操作の最小セットを `docs/controls.md` に記載予定。仮想スティック未導入でもテスト可能です。

---

## Tech Stack
- Unity 6000.0.48f1（URP 17.x）  
- glTFast（GLB 読み込み）  
- SimpleFileBrowser（Android ファイル選択）  
- TextMesh Pro（UI）  
- Starter Assets（入力/カメラ）  
- Physics：Rigidbody / Collider / PhysicsMaterial

> **NOTE**  
> 出典・ライセンスは `ThirdPartyNotices.md` を参照してください。

---

## Build (Android)
```yaml
Platform: Android
Scripting Backend: IL2CPP（推奨） / Mono
SDK/NDK/JDK: Unity Hub 管理のものを使用
```

> **TIP**  
> IL2CPP + ARM64 を推奨。`docs/build-notes.md` に詳細を追記予定です。

---

## Folder Structure
```yaml
Assets/
├─ Scenes/ # Home / GameScene
├─ Scripts/ # ゲームロジック (GameManager ほか)
├─ Animals/ # サンプルモデル
├─ Plugins/ # 外部プラグイン
└─ StarterAssets/ # 入力・カメラのベース
```


> **NOTE**  
> `.meta` は GUID 維持のため必ず保持してください。不要アセットは削除済み。

---

## External Assets
- **SlimUI Modern Menu 1**（再配布不可）  
  - 各自インポート後、`Home.unity` / `GameScene.unity` の参照が解決されます。  
  - TextMesh Pro 使用時は `Window > TextMeshPro > Import TMP Essential Resources` を実行。  
- **Joystick Pack**（任意・再配布不可）  
  - `docs/controls.md` の手順に沿って導入。定義シンボル `JOYSTICK_PACK` を設定すると自動参照。未導入時はキーボードにフォールバック。

> **WARNING**  
> ライセンス上、当リポジトリには含めていません。導入は各自のライセンス範囲で行ってください。

---

## License
- MIT License（`LICENSE`）  
- 付属アセットの出典・ライセンスは `ThirdPartyNotices.md`

---

## Project Status
| 項目 | 状態 |
|--|--|
| 開発 | Active（軽量化・UI整理を継続） |
| テスト | Android 実機で動作確認 |
| 今後 | GLB 取込 UX、スコア画面、ドキュメント更新 |

> **STATUS**  
> ブランチ運用：`develop`（作業）→ `main`（取り込み）。`main` は PR 必須。

---

## Author
Shintaro Niwamoto / [@shin1300](https://github.com/shin1300)  
`shintaro.niwamoto@ubi-lab.com`

> **TIP**  
> Issue / Pull Request での質問・提案歓迎です。再現手順・端末情報があると助かります。
