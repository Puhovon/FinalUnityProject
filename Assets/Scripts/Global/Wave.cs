using System;
using Fusion;
using UnityEngine;

namespace Assets.Scripts.Global
{
    public class Wave : NetworkBehaviour
    {
        [SerializeField] private float _timeToNextWave;

        [SerializeField] private float _currentTime;
        public event Action SpawnNewWave;

        private void Awake()
        {
            _currentTime = _timeToNextWave;
            // SpawnNewWave?.Invoke();
        }

        public override void FixedUpdateNetwork()
        {
            if (!HasStateAuthority)
                return;
            _currentTime -= Runner.DeltaTime;
            if (_currentTime <= 0)
            {
                SpawnNewWave?.Invoke();
                _currentTime = 10000;
            }
        }
    }
}
