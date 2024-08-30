using Assets.Scripts.Global;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class HeathUI : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private Health _health;

        private void Start()
        {
            _slider = FindObjectOfType<Slider>();
        }

        private void OnEnable()
        {
            _health.HealthChanged += OnHealthChanged;
        }
            
        private void OnDisable()
        {
            _health.HealthChanged += OnHealthChanged;
        }
        
        private void OnHealthChanged(int healthPoints)
        {
            _slider.value = healthPoints;
        }
    }
}