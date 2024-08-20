using System;
using Assets.Scripts.PlayerScripts;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class SettingsUI : MonoBehaviour
    {
        [SerializeField] private Slider _soundsSlider;
        [SerializeField] private Slider _musikSlider;
        [SerializeField] private Bus _bus;

        public void Initialize(Shooter shooter)
        {
            print("Init");
        }
        private void Awake()
        {
            _soundsSlider.onValueChanged.AddListener(ChangeSoundVolume);
            _musikSlider.onValueChanged.AddListener(ChangeMusikVolume);
            _musikSlider.value = _bus.GetMusikVolume();
            _soundsSlider.value = _bus.GetSoundsVolume();
        }

        private void ChangeSoundVolume(float value)
        {
            _bus.SetSoundsVolume(value);
        }
        
        private void ChangeMusikVolume(float value)
        {
            _bus.SetMusikVolume(value);
        }
    }
}