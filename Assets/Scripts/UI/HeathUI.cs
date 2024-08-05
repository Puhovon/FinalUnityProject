using Assets.Scripts.Global;
using Fusion;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class HeathUI : NetworkBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private Health _health;
            
        private void OnEnable()
        {
            _health.HealthChanged += OnHealthChanged;
            Debug.LogError("Submit to HealthChanged");
        }
            
        private void OnDisable()
        {
            _health.HealthChanged += OnHealthChanged;
        }
        
        private void OnHealthChanged(int healthPoints)
        {
            if (HasStateAuthority)
            {
                _slider.value = healthPoints;
                Debug.Log("Slider value changed");
            }
        }
    }
}