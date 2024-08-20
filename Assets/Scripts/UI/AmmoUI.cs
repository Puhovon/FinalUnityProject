using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class AmmoUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text _ammoCount;
        [SerializeField] private Image _image;
        private const string Ammo = "ammo";

        public Action<int> onAmmoChanged;

        private void Start()
        {
            onAmmoChanged += ChangeAmmoCount;
        }

        private void ChangeAmmoCount(int ammo)
        {
            _ammoCount.gameObject.SetActive(true);
            _image.gameObject.SetActive(false);
            _ammoCount.text = $"{Ammo}: {ammo}";
        }

        public void Reload(float f, float amount)
        {
            _image.gameObject.SetActive(true);
            _ammoCount.gameObject.SetActive(false);
            _image.fillAmount = f/amount;
        } 
    }
}