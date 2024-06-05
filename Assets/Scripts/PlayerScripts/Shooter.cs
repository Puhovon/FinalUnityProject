using System;
using System.Collections;
using Assets.Scripts.Abstractions;
using Assets.Scripts.PlayerScripts.Configs;
using Assets.Scripts.PlayerScripts.StateMachine;
using UnityEngine;

namespace Assets.Scripts.PlayerScripts
{
    public class Shooter : MonoBehaviour
    {
        [SerializeField] private PlayerConfig _config;
        [SerializeField] private int ammo;
        [SerializeField] private ParticleSystem _missParticle;
        public Action<PlayerStateData> Shoot;

        private bool _canShoot = true;
        private float _timeToNextShoot;
        private float _currentTime;
        
        public void Initialize()
        {
            _timeToNextShoot = _config.WalkingStateConfig.TimeToNextShoot;
            _currentTime = 0;
            Shoot += OnShoot;
        }

        private void OnShoot(PlayerStateData data)
        {
            ammo = data.Ammo;
            if (!_canShoot)
                return;
            print("SHOOOOOOT");
            Attack();
            _canShoot = false;
            data.Ammo -= 1;
            if (data.Ammo <= 0)
                StartCoroutine(Reload(data));
            else
                StartCoroutine(CalculateTimeToNextShoot());
        }

        private void Attack()
        {
            RaycastHit hit;
            if (!Physics.Raycast(transform.position, transform.forward, out hit, _config.distance))
                return;
            if (!hit.transform.TryGetComponent(out IDamagable damagable))
            {
                _missParticle.transform.position = hit.transform.position;
                print(hit.transform.position);
                _missParticle.Play();
                print("Miss");
                return;
            }
            
            damagable.TakeDamage(_config.damage);
        }

        private IEnumerator Reload(PlayerStateData data)
        {
            yield return new WaitForSeconds(_config.ReloadingStateConfig.TimeToReload);
            _canShoot = true;
            data.Ammo = data.MaxAmmo;
        }

        private IEnumerator CalculateTimeToNextShoot()
        {
            yield return new WaitForSeconds(_timeToNextShoot);
            _canShoot = true;
        }
    }
}