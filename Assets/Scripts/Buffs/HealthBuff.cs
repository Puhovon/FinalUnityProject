using Assets.Scripts.Abstractions;
using Assets.Scripts.Global;
using UnityEngine;

namespace Assets.Scripts.Buffs
{
    public class HealthBuff : MonoBehaviour, IBuff
    {
        [SerializeField] private Health _playerHealth;
        [SerializeField] private int _healthToAdd;

        public void StartBuff()
        {
            _playerHealth.HealthPoints += _healthToAdd;
        }

        public void EndBuff()
        {
            if (_playerHealth.HealthPoints - _healthToAdd <= 0)
            {
                _playerHealth.HealthPoints = 1;
                return;
            }
            _playerHealth.HealthPoints -= _healthToAdd;
        }
    }
}
