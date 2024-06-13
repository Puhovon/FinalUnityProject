using System;
using Assets.Scripts.Abstractions;
using UnityEngine;

namespace Assets.Scripts.Global
{
    public class Health : MonoBehaviour, IDamagable
    {
        [SerializeField] private GlobalConfig _config;
        
        [SerializeField] private int _health;

        [SerializeField] private int _damageReduction;

        public int DamageReduction
        {
            get => _damageReduction;
            set => _damageReduction = value;
        }
        public int HealthPoints
        {
            get => _health;
            set => _health = value;
        }

        public event Action HealthChanged;
        public event Action Die;

        private void Start()
        {
            _health = _config.Health;
        }

        public void TakeDamage(int damage)
        {
            if (damage <= 0)
                throw new ArgumentOutOfRangeException("damage must be greater than 0");
            _health -= (damage - _damageReduction);
            HealthChanged?.Invoke();
            if (_health <= 0)
                Die?.Invoke();
        }
    }
}