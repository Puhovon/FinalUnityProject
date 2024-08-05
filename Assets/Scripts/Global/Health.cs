using System;
using Assets.Scripts.Abstractions;
using Fusion;
using UnityEngine;

namespace Assets.Scripts.Global
{
    public class Health : NetworkBehaviour, IDamagable, IBufuble
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

        public event Action<int> HealthChanged;
        public event Action Die;

        private void Start()
        {
            _health = _config.Health;
        }
        
        [Rpc(RpcSources.StateAuthority, RpcTargets.All)]
        public void Rpc_TakeDamage(int damage)
        {
            if(!HasStateAuthority)
                return;
            if (damage <= 0)
                throw new ArgumentOutOfRangeException("damage must be greater than 0");
            _health -= (damage - _damageReduction);
            HealthChanged?.Invoke(_health);
            if (_health <= 0)
                Die?.Invoke();
        }
    }
}