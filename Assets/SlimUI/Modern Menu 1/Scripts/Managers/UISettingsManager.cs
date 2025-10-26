using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

namespace SlimUI.ModernMenu
{
    public class UISettingsManager : MonoBehaviour
    {
        public enum Platform { Desktop, Mobile };
        public Platform platform;

        [Header("MOBILE SETTINGS")]
        public GameObject mobileSFXtext;
        public GameObject mobileMusictext;
        // public GameObject mobileShadowofftextLINE; // 削除
        // public GameObject mobileShadowlowtextLINE;  // 削除
        // public GameObject mobileShadowhightextLINE; // 削除

        [Header("VIDEO SETTINGS")]
        public GameObject fullscreentext;
        public GameObject ambientocclusiontext;
        // public GameObject shadowofftextLINE;      // 削除
        // public GameObject shadowlowtextLINE;      // 削除
        // public GameObject shadowhightextLINE;     // 削除
        // public GameObject aaofftextLINE;          // 削除
        // public GameObject aa2xtextLINE;           // 削除
        // public GameObject aa4xtextLINE;           // 削除
        // public GameObject aa8xtextLINE;           // 削除
        public GameObject vsynctext;
        public GameObject motionblurtext;
        // public GameObject texturelowtextLINE;     // 削除
        // public GameObject texturemedtextLINE;     // 削除
        // public GameObject texturehightextLINE;    // 削除
        public GameObject cameraeffectstext;

        [Header("GAME SETTINGS")]
        public GameObject showhudtext;
        public GameObject tooltipstext;
        public GameObject difficultynormaltext;
        public GameObject difficultyhardcoretext;

        [Header("CONTROLS SETTINGS")]
        public GameObject invertmousetext;

        // sliders
        public GameObject musicSlider;
        public GameObject sensitivityXSlider;
        public GameObject sensitivityYSlider;
        public GameObject mouseSmoothSlider;

        private float sliderValueXSensitivity = 0.0f;
        private float sliderValueYSensitivity = 0.0f;
        private float sliderValueSmoothing = 0.0f;


        public void Start()
        {
            // check slider values
            musicSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("MusicVolume");
            sensitivityXSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("XSensitivity");
            sensitivityYSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("YSensitivity");
            mouseSmoothSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("MouseSmoothing");

            // check full screen
            if (Screen.fullScreen == true)
            {
                fullscreentext.GetComponent<TMP_Text>().text = "on";
            }
            else if (Screen.fullScreen == false)
            {
                fullscreentext.GetComponent<TMP_Text>().text = "off";
            }

            // check hud value
            if (PlayerPrefs.GetInt("ShowHUD") == 0)
            {
                showhudtext.GetComponent<TMP_Text>().text = "off";
            }
            else
            {
                showhudtext.GetComponent<TMP_Text>().text = "on";
            }

            // check tool tip value
            if (PlayerPrefs.GetInt("ToolTips") == 0)
            {
                tooltipstext.GetComponent<TMP_Text>().text = "off";
            }
            else
            {
                tooltipstext.GetComponent<TMP_Text>().text = "on";
            }

            // check shadow distance/enabled
            if (platform == Platform.Desktop)
            {
                if (PlayerPrefs.GetInt("Shadows") == 0)
                {
                    QualitySettings.shadowCascades = 0;
                    QualitySettings.shadowDistance = 0;
                }
                else if (PlayerPrefs.GetInt("Shadows") == 1)
                {
                    QualitySettings.shadowCascades = 2;
                    QualitySettings.shadowDistance = 75;
                }
                else if (PlayerPrefs.GetInt("Shadows") == 2)
                {
                    QualitySettings.shadowCascades = 4;
                    QualitySettings.shadowDistance = 500;
                }
            }
            else if (platform == Platform.Mobile)
            {
                if (PlayerPrefs.GetInt("MobileShadows") == 0)
                {
                    QualitySettings.shadowCascades = 0;
                    QualitySettings.shadowDistance = 0;
                }
                else if (PlayerPrefs.GetInt("MobileShadows") == 1)
                {
                    QualitySettings.shadowCascades = 2;
                    QualitySettings.shadowDistance = 75;
                }
                else if (PlayerPrefs.GetInt("MobileShadows") == 2)
                {
                    QualitySettings.shadowCascades = 4;
                    QualitySettings.shadowDistance = 100;
                }
            }

            // check vsync
            if (QualitySettings.vSyncCount == 0)
            {
                vsynctext.GetComponent<TMP_Text>().text = "off";
            }
            else if (QualitySettings.vSyncCount == 1)
            {
                vsynctext.GetComponent<TMP_Text>().text = "on";
            }

            // check mouse inverse
            if (PlayerPrefs.GetInt("Inverted") == 0)
            {
                invertmousetext.GetComponent<TMP_Text>().text = "off";
            }
            else if (PlayerPrefs.GetInt("Inverted") == 1)
            {
                invertmousetext.GetComponent<TMP_Text>().text = "on";
            }

            // check motion blur
            if (PlayerPrefs.GetInt("MotionBlur") == 0)
            {
                motionblurtext.GetComponent<TMP_Text>().text = "off";
            }
            else if (PlayerPrefs.GetInt("MotionBlur") == 1)
            {
                motionblurtext.GetComponent<TMP_Text>().text = "on";
            }

            // check ambient occlusion
            if (PlayerPrefs.GetInt("AmbientOcclusion") == 0)
            {
                ambientocclusiontext.GetComponent<TMP_Text>().text = "off";
            }
            else if (PlayerPrefs.GetInt("AmbientOcclusion") == 1)
            {
                ambientocclusiontext.GetComponent<TMP_Text>().text = "on";
            }

            // check texture quality
            if (PlayerPrefs.GetInt("Textures") == 0)
            {
                QualitySettings.globalTextureMipmapLimit = 2;
            }
            else if (PlayerPrefs.GetInt("Textures") == 1)
            {
                QualitySettings.globalTextureMipmapLimit = 1;
            }
            else if (PlayerPrefs.GetInt("Textures") == 2)
            {
                QualitySettings.globalTextureMipmapLimit = 0;
            }
        }

        public void Update()
        {
            sliderValueXSensitivity = sensitivityXSlider.GetComponent<Slider>().value;
            sliderValueYSensitivity = sensitivityYSlider.GetComponent<Slider>().value;
            sliderValueSmoothing = mouseSmoothSlider.GetComponent<Slider>().value;
        }

        public void FullScreen()
        {
            Screen.fullScreen = !Screen.fullScreen;

            if (Screen.fullScreen == true)
            {
                fullscreentext.GetComponent<TMP_Text>().text = "on";
            }
            else if (Screen.fullScreen == false)
            {
                fullscreentext.GetComponent<TMP_Text>().text = "off";
            }
        }

        public void MusicSlider()
        {
            PlayerPrefs.SetFloat("MusicVolume", musicSlider.GetComponent<Slider>().value);
        }

        public void SensitivityXSlider()
        {
            PlayerPrefs.SetFloat("XSensitivity", sliderValueXSensitivity);
        }

        public void SensitivityYSlider()
        {
            PlayerPrefs.SetFloat("YSensitivity", sliderValueYSensitivity);
        }

        public void SensitivitySmoothing()
        {
            PlayerPrefs.SetFloat("MouseSmoothing", sliderValueSmoothing);
            Debug.Log(PlayerPrefs.GetFloat("MouseSmoothing"));
        }

        public void ShowHUD()
        {
            if (PlayerPrefs.GetInt("ShowHUD") == 0)
            {
                PlayerPrefs.SetInt("ShowHUD", 1);
                showhudtext.GetComponent<TMP_Text>().text = "on";
            }
            else if (PlayerPrefs.GetInt("ShowHUD") == 1)
            {
                PlayerPrefs.SetInt("ShowHUD", 0);
                showhudtext.GetComponent<TMP_Text>().text = "off";
            }
        }

        public void MobileSFXMute()
        {
            if (PlayerPrefs.GetInt("Mobile_MuteSfx") == 0)
            {
                PlayerPrefs.SetInt("Mobile_MuteSfx", 1);
                mobileSFXtext.GetComponent<TMP_Text>().text = "on";
            }
            else if (PlayerPrefs.GetInt("Mobile_MuteSfx") == 1)
            {
                PlayerPrefs.SetInt("Mobile_MuteSfx", 0);
                mobileSFXtext.GetComponent<TMP_Text>().text = "off";
            }
        }

        public void MobileMusicMute()
        {
            if (PlayerPrefs.GetInt("Mobile_MuteMusic") == 0)
            {
                PlayerPrefs.SetInt("Mobile_MuteMusic", 1);
                mobileMusictext.GetComponent<TMP_Text>().text = "on";
            }
            else if (PlayerPrefs.GetInt("Mobile_MuteMusic") == 1)
            {
                PlayerPrefs.SetInt("Mobile_MuteMusic", 0);
                mobileMusictext.GetComponent<TMP_Text>().text = "off";
            }
        }

        public void ToolTips()
        {
            if (PlayerPrefs.GetInt("ToolTips") == 0)
            {
                PlayerPrefs.SetInt("ToolTips", 1);
                tooltipstext.GetComponent<TMP_Text>().text = "on";
            }
            else if (PlayerPrefs.GetInt("ToolTips") == 1)
            {
                PlayerPrefs.SetInt("ToolTips", 0);
                tooltipstext.GetComponent<TMP_Text>().text = "off";
            }
        }

        public void NormalDifficulty()
        {
            PlayerPrefs.SetInt("NormalDifficulty", 1);
            PlayerPrefs.SetInt("HardCoreDifficulty", 0);
        }

        public void HardcoreDifficulty()
        {
            PlayerPrefs.SetInt("NormalDifficulty", 0);
            PlayerPrefs.SetInt("HardCoreDifficulty", 1);
        }

        // ▼▼▼ LINE関連のメソッドをすべて削除 ▼▼▼

        public void ShadowsOff()
        {
            PlayerPrefs.SetInt("Shadows", 0);
            QualitySettings.shadowCascades = 0;
            QualitySettings.shadowDistance = 0;
        }

        public void ShadowsLow()
        {
            PlayerPrefs.SetInt("Shadows", 1);
            QualitySettings.shadowCascades = 2;
            QualitySettings.shadowDistance = 75;
        }

        public void ShadowsHigh()
        {
            PlayerPrefs.SetInt("Shadows", 2);
            QualitySettings.shadowCascades = 4;
            QualitySettings.shadowDistance = 500;
        }

        public void MobileShadowsOff()
        {
            PlayerPrefs.SetInt("MobileShadows", 0);
            QualitySettings.shadowCascades = 0;
            QualitySettings.shadowDistance = 0;
        }

        public void MobileShadowsLow()
        {
            PlayerPrefs.SetInt("MobileShadows", 1);
            QualitySettings.shadowCascades = 2;
            QualitySettings.shadowDistance = 75;
        }

        public void MobileShadowsHigh()
        {
            PlayerPrefs.SetInt("MobileShadows", 2);
            QualitySettings.shadowCascades = 4;
            QualitySettings.shadowDistance = 500;
        }

        public void vsync()
        {
            if (QualitySettings.vSyncCount == 0)
            {
                QualitySettings.vSyncCount = 1;
                vsynctext.GetComponent<TMP_Text>().text = "on";
            }
            else if (QualitySettings.vSyncCount == 1)
            {
                QualitySettings.vSyncCount = 0;
                vsynctext.GetComponent<TMP_Text>().text = "off";
            }
        }

        public void InvertMouse()
        {
            if (PlayerPrefs.GetInt("Inverted") == 0)
            {
                PlayerPrefs.SetInt("Inverted", 1);
                invertmousetext.GetComponent<TMP_Text>().text = "on";
            }
            else if (PlayerPrefs.GetInt("Inverted") == 1)
            {
                PlayerPrefs.SetInt("Inverted", 0);
                invertmousetext.GetComponent<TMP_Text>().text = "off";
            }
        }

        public void MotionBlur()
        {
            if (PlayerPrefs.GetInt("MotionBlur") == 0)
            {
                PlayerPrefs.SetInt("MotionBlur", 1);
                motionblurtext.GetComponent<TMP_Text>().text = "on";
            }
            else if (PlayerPrefs.GetInt("MotionBlur") == 1)
            {
                PlayerPrefs.SetInt("MotionBlur", 0);
                motionblurtext.GetComponent<TMP_Text>().text = "off";
            }
        }

        public void AmbientOcclusion()
        {
            if (PlayerPrefs.GetInt("AmbientOcclusion") == 0)
            {
                PlayerPrefs.SetInt("AmbientOcclusion", 1);
                ambientocclusiontext.GetComponent<TMP_Text>().text = "on";
            }
            else if (PlayerPrefs.GetInt("AmbientOcclusion") == 1)
            {
                PlayerPrefs.SetInt("AmbientOcclusion", 0);
                ambientocclusiontext.GetComponent<TMP_Text>().text = "off";
            }
        }

        public void CameraEffects()
        {
            if (PlayerPrefs.GetInt("CameraEffects") == 0)
            {
                PlayerPrefs.SetInt("CameraEffects", 1);
                cameraeffectstext.GetComponent<TMP_Text>().text = "on";
            }
            else if (PlayerPrefs.GetInt("CameraEffects") == 1)
            {
                PlayerPrefs.SetInt("CameraEffects", 0);
                cameraeffectstext.GetComponent<TMP_Text>().text = "off";
            }
        }

        public void TexturesLow()
        {
            PlayerPrefs.SetInt("Textures", 0);
            QualitySettings.globalTextureMipmapLimit = 2;
        }

        public void TexturesMed()
        {
            PlayerPrefs.SetInt("Textures", 1);
            QualitySettings.globalTextureMipmapLimit = 1;
        }

        public void TexturesHigh()
        {
            PlayerPrefs.SetInt("Textures", 2);
            QualitySettings.globalTextureMipmapLimit = 0;
        }
    }
}