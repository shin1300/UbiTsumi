# UbiTsumi

[![Unity](https://img.shields.io/badge/Unity-6000.0.48f1-blue?logo=unity)](#)
![Platform](https://img.shields.io/badge/Platform-Android-lightgrey)
![License](https://img.shields.io/badge/License-MIT-green)

Unity 製「動物タワー風」3Dゲーム。  
研究室を舞台に、身の回りのモノを積み上げて遊べる軽量デモプロジェクトです。

---

## 📽️ Demo
[![Demo](docs/images/demo.gif)](https://github.com/user-attachments/assets/ad2d3c38-0f14-4bed-9956-113ea5e775a8)

---

## 🧭 Overview
UbiTsumi は、研究室メンバー間の技術コンペ用に開発されたミニゲームです。  
各自が研究で使う技術を題材に作品を制作する中で、  
「身近な空間（研究室）をステージにし、実際のモノを積んで遊ぶ」ことをテーマにしています。

- **舞台:** 研究室を再現した 3D シーン  
- **操作:** 仮想スティックまたはキーボードで操作し、オブジェクトを落として積む  
- **目的:** 安定させて積み上げる（ScoreAttack / VS モード対応）  
- **拡張性:** glTFast により任意の `.glb` モデルを Android 端末から読み込める  

> [!Note]  
> 実際の物体スキャンには **Polycam** などの外部アプリを使用します。  
> UbiTsumi はそれらで作成した GLB を読み込み、ゲームに組み込むためのベースです。

---

## 🚀 Quick Start
1. Unity Hub でプロジェクトを開く  
2. `Assets/Scenes/Home.unity` を開く  
3. ▶ を押して実行（仮想スティック未導入でもキーボード操作可）

---

## 🧰 Tech Stack
- **Engine:** Unity 6000.0.48f1  
- **Runtime:** URP / IL2CPP 対応  
- **Libraries:**  
  - [glTFast](https://github.com/atteneder/glTFast) – GLB 読み込み  
  - [SimpleFileBrowser](https://github.com/yasirkula/UnitySimpleFileBrowser) – Android ファイル選択  
  - [TextMesh Pro](https://docs.unity3d.com/Packages/com.unity.textmeshpro@latest/) – UI 表示  
  - Starter Assets（入力・カメラ制御）  
- **Physics:** Rigidbody / Collider / PhysicsMaterial  

> [!Note]  
> 各アセットの出典・ライセンス詳細は `ThirdPartyNotices.md` を参照してください。

---

## 🏗️ Build (Android)
```yaml
Platform: Android
Scripting Backend: IL2CPP（推奨） / Mono
SDK/NDK/JDK: Unity Hub 管理のものを使用
```

> [!Tip] 
> IL2CPP + ARM64 を推奨。`docs/build-notes.md` に詳細を追記予定です。

---

## Folder Structure
```yaml
Assets/
├─ Scenes/ # Home / GameScene
├─ Scripts/ # ゲームロジック 
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
- **Joystick Pack**（任意・再配布不可）  
  - `docs/controls.md` の手順に沿って導入。

> [!Warning]
> ライセンス上、当リポジトリには含めていません。導入は各自のライセンス範囲で行ってください。
> HomeSceneでは、glbファイルをアップロードしなければゲーム画面に移る際に詰まります。

---

## License
- MIT License（`LICENSE`）  
- 付属アセットの出典・ライセンスは `ThirdPartyNotices.md`



