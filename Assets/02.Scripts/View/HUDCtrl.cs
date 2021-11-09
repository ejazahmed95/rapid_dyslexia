using System;
using EAUtils;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace _02.Scripts.View {
    public class HUDCtrl: MonoBehaviour {
        [SerializeField] private Button _languageToggle;
        [SerializeField] private Image _stressFg;
        [SerializeField] private Image _stressBg;

        private float maxWidth = 300;
        private float height = 50;
        private void Start(){
            _languageToggle.onClick.AddListener(ToggleLang);
            maxWidth = _stressBg.GetComponent<RectTransform>().rect.width;
            height = _stressBg.GetComponent<RectTransform>().rect.height;
            UpdateStress(DI.Get<StatsController>().GetStressMeter());
            DI.Get<StatsController>()._onStressUpdate.AddListener(UpdateStress);
        }

        void UpdateStress(float newStress){
            newStress = Mathf.Clamp(newStress, 0, 100);
            _stressFg.GetComponent<RectTransform>().sizeDelta = new Vector2(maxWidth * newStress / 100, height);
        }
        
        void ToggleLang(){
            var lType = (DI.Get<GameSettings>().languageType == LanguageType.English) ? LanguageType.Mandarin: LanguageType.English;
            DI.Get<AppManager>().SetLocale(lType);
        }
    }
}