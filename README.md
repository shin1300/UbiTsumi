# UbiTsumi

[![Unity](https://img.shields.io/badge/Unity-6000.0.48f1-blue?logo=unity)](#)
![Platform](https://img.shields.io/badge/Platform-Android-lightgrey)
![License](https://img.shields.io/badge/License-MIT-green)
![Status](https://img.shields.io/badge/Status-Active-brightgreen)

研究室を舞台にした「動物タワー風」3Dゲーム（Unity）。研究室にあるモノを読み込んで積んで遊べるゲームです。

---

## Table of Contents
- [Demo](#demo)
- [Overview](#overview)
- [Quick Start](#quick-start)
- [Features](#features)
- [Controls](#controls)
- [Build (Android)](#build-android)
- [Folder Structure](#folder-structure)
- [External Assets](#external-assets)
- [License](#license)
- [Author](#author)

---

## Demo
[![Demo](docs/images/demo.gif)](https://github.com/user-attachments/assets/ad2d3c38-0f14-4bed-9956-113ea5e775a8)

---

## Overview
- 研究室空間をシーン化し、**身近なモノをゲームオブジェクトとして積める**。
- 物体スキャンは**別アプリ**で行う必要あり

---

## Quick Start
1. Unity Hub でプロジェクトを開く  
2. `Assets/Scenes/Home.unity` を開く  
3. ▶ を押して実行

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

## Author
Shintaro Niwamoto / [@shin1300](https://github.com/shin1300)  
`shintaro.niwamoto@ubi-lab.com`

