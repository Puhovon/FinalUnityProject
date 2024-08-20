using System;
using Fusion;
using FMODUnity;
using UnityEngine;
using System.Collections;
using Assets.Scripts.Abstractions;
using Assets.Scripts.PlayerScripts.Configs;
using Assets.Scripts.PlayerScripts.StateMachine;
using Assets.Scripts.UI;

namespace Assets.Scripts.PlayerScripts
{
    public class Shooter : NetworkBehaviour
    {
        [SerializeField] private PlayerConfig _config;
        [SerializeField] private ParticleSystem _missParticle;
        [SerializeField] private StudioEventEmitter _emitter;
        [SerializeField] private int _ammo;

        private int _damageMagnifier = 0;
        private float _timeToNextShoot;
        private bool _canShoot = true;
        private AmmoUI _ui;
        
        public Action<PlayerStateData> Shoot;

        public StudioEventEmitter Emmiter => _emitter;
        
         
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
            FindObjectOfType<SettingsUI>().Initialize(this);
            _ui = FindObjectOfType<AmmoUI>();
            _ui.onAmmoChanged?.Invoke(_config.WalkingStateConfig.MaxAmmo);
        }

        private void OnShoot(PlayerStateData data)
        {
            _ammo = data.Ammo;
            if (!_canShoot)
                return;
            Attack();
            _canShoot = false;
            data.Ammo -= 1;
            _ui.onAmmoChanged?.Invoke(data.Ammo);
            StartCoroutine(data.Ammo <= 0 ? Reload(data) : CalculateTimeToNextShoot());
        }

        private void Attack()
        {
            RaycastHit hit;
            _emitter.Play();
            if (Runner.GetPhysicsScene().Raycast(transform.position, transform.forward, out hit, _config.distance))
            {
                if (hit.transform.TryGetComponent(out IDamagable damagable))
                {
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
            for (int i = 1; i <= _config.ReloadingStateConfig.TimeToReload; i++)
            {
                yield return new WaitForSeconds(1);
                _ui.Reload((float)i, _config.ReloadingStateConfig.TimeToReload);
            }
            _canShoot = true;
            data.Ammo = data.MaxAmmo;
            _ui.onAmmoChanged?.Invoke(data.Ammo);
        }

        private IEnumerator CalculateTimeToNextShoot()
        {
            yield return new WaitForSeconds(_timeToNextShoot);
            _canShoot = true;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(transform.position, transform.forward * _config.distance);
        }
    }
}