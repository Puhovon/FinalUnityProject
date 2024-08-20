using Assets.Scripts.Abstractions;
using Assets.Scripts.Global;
using Assets.Scripts.PlayerScripts;
using Assets.Scripts.Utilities;
using DG.Tweening;
using Fusion;
using UnityEngine;

namespace Assets.Scripts.Buffs
{
    public abstract class Buff : NetworkBehaviour, IBuff
    {
        [SerializeField] private int _timeToEnd;
        [SerializeField] private NetworkTransform _transform;
        [SerializeField] private GameObject _object;
        private CoroutineTimer _timer;
        private Collider _collider;
        private IBufuble _bufuble;

        protected IBufuble Buffable => _bufuble;
        protected Shooter Shooter;
        protected Player Player;

        private void Start()
        {
            _timer = new CoroutineTimer(_timeToEnd, EndBuff);
            _collider = GetComponent<Collider>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _bufuble = other.GetComponent<IBufuble>();
                Shooter = other.GetComponent<Shooter>();
                Player = other.GetComponent<Player>();
                StartBuff();
                StartCoroutine(_timer.Timer());
            }
        }

        public virtual void StartBuff()
        {
            Rpc_Hide();
            _object.SetActive(false);
            _collider.enabled = false;
        }

        [Rpc(RpcSources.All, RpcTargets.All)]
        private void Rpc_Hide()
        {
            _object.SetActive(false);
            _collider.enabled = false;
        }
        
        public virtual void EndBuff()
        {
            var obj = transform.GetComponent<NetworkObject>();
            Runner.Despawn(obj);
        }
    }
}