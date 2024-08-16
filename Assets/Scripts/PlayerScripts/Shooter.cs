using System;
using System.Collections;
using Assets.Scripts.Abstractions;
using Assets.Scripts.PlayerScripts.Configs;
using Assets.Scripts.PlayerScripts.StateMachine;
using FMODUnity;
using Fusion;
using UnityEngine;

namespace Assets.Scripts.PlayerScripts
{
    public class Shooter : NetworkBehaviour
    {
        [SerializeField] private PlayerConfig _config;
        [SerializeField] private int _ammo;
        [SerializeField] private ParticleSystem _missParticle;
        private int _damageMagnifier = 0;
        private float _timeToNextShoot;
        private bool _canShoot = true;
        private StudioEventEmitter _emitter;
        public Action<PlayerStateData> Shoot;
         
        public int DamageMagnifier
        {
            get => _damageMagnifier;
            set => _damageMagnifier = value;
        }

        public void Initialize()
        {
            _timeToNextShoot = _config.WalkingStateConfig.TimeToNextShoot;
            Shoot += OnShoot;
            _emitter = FindObjectOfType<StudioEventEmitter>();
        }

        private void OnShoot(PlayerStateData data)
        {
            print("SHOOT");
            _ammo = data.Ammo;
            if (!_canShoot)
                return;
            Attack();
            _emitter.Play();
            _canShoot = false;
            data.Ammo -= 1;
            StartCoroutine(data.Ammo <= 0 ? Reload(data) : CalculateTimeToNextShoot());
        }

        private void Attack()
        {
            RaycastHit hit;
            if (Runner.GetPhysicsScene().Raycast(transform.position, transform.forward, out hit, _config.distance))
            {
                print("Find");
                if (hit.transform.TryGetComponent(out IDamagable damagable))
                {
                    print("Damagable");
                    damagable.Rpc_TakeDamage(_config.damage + _damageMagnifier);
                }
                _missParticle.transform.position = hit.point;
                _missParticle.transform.rotation = Quaternion.LookRotation(hit.normal);

                _missParticle.Play();
                return;
            }
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