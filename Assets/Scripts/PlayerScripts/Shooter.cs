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
            print(_config.distance);
        }

        private void OnShoot(PlayerStateData data)
        {
            ammo = data.Ammo;
            if (!_canShoot)
                return;
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
            if (Physics.Raycast(transform.position, transform.forward, out hit, _config.distance))
            {
                if (hit.transform.TryGetComponent(out IDamagable damagable))
                {
                    print("HIT");
                    damagable.TakeDamage(_config.damage);
                    return;
                }
                print("AAAAA");
                _missParticle.transform.position = hit.transform.position;
                _missParticle.Play();
                return;
            }
            print("Miss");


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

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(transform.position, (transform.forward)* _config.distance);
        }
    }
}