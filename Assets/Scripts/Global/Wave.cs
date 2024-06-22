using System;
using UnityEngine;

namespace Assets.Scripts.Global
{
    public class Wave : MonoBehaviour
    {
        [SerializeField] private float _timeToNextWave;

        [SerializeField] private float _currentTime;
        public event Action SpawnNewWave;

        private void Awake()
        {
            _currentTime = _timeToNextWave;
            SpawnNewWave?.Invoke();
        }

        private void Update()
        {
            _currentTime -= Time.deltaTime;
            if (_currentTime <= 0)
            {
                SpawnNewWave?.Invoke();
                _currentTime = _timeToNextWave;
            }
        }
    }
}
