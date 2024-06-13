using Assets.Scripts.Abstractions;
using Assets.Scripts.Global;
using UnityEngine;

namespace Assets.Scripts.Buffs
{
    public class ShieldBuff : MonoBehaviour, IBuff
    {
        [SerializeField] private Health _playerHealth;
        [SerializeField] private int _damageReduction;
        
        public void StartBuff() => _playerHealth.DamageReduction += _damageReduction;
        

        public void EndBuff() => _playerHealth.DamageReduction -= _damageReduction;
        
    }
}
