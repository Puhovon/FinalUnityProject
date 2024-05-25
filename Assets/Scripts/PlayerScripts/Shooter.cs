using System;
using Assets.Scripts.PlayerScripts.Configs;
using Assets.Scripts.PlayerScripts.StateMachine;
using UnityEngine;

namespace Assets.Scripts.PlayerScripts
{
    public class Shooter : MonoBehaviour
    {
        [SerializeField] private PlayerConfig _config;
        public Action<PlayerStateData> shoot;

        private bool _canShoot = true;
        private float _timeToNextShoot;
        private float _currentTime;
        public void Initialize()
        {
            _timeToNextShoot = _config.WalkingStateConfig.TimeToNextShoot;
            _currentTime = 0;
            shoot += Shoot;
        }

        private void Shoot(PlayerStateData data)
        {
            if(_canShoot)
            {
                _canShoot = false;
                data.Ammo -= 1;
            }
        }

        private void Update()
        {
            _currentTime -= Time.deltaTime;
            if (_currentTime <= 0f)
            {
                _canShoot = true;
                _currentTime = _timeToNextShoot;
            }
        }
    }
}