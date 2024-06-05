using System;
using Assets.Scripts.Abstractions;
using UnityEngine;

namespace Assets.Scripts.Global
{
    public class Health : MonoBehaviour, IDamagable
    {
        [SerializeField] private GlobalConfig _config;
        
        [SerializeField] private int _health;

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
            _health -= damage;
            HealthChanged?.Invoke();
            if (_health <= 0)
                Die?.Invoke();
            Debug.Log($"I {transform.name} have damage: {damage}");
        }

        
    }
}