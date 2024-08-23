using System;
using Assets.Scripts.Enemy.EnemySpawner;
using Fusion;
using UnityEngine;

namespace Assets.Scripts.Global
{
    public class Wave : NetworkBehaviour
    {
        [SerializeField] private float _timeToNextWave;

        [SerializeField] private float _currentTime;
        [SerializeField] private EnemySpawner _spawner;
        private bool waweInvoked;
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
                if(!waweInvoked)
                    _spawner.Spawn();
                waweInvoked = true;
                _currentTime = 10000;
                waweInvoked = false;
            }
        }
    }
}
