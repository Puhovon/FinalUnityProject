using Assets.Scripts.Abstractions;
using Assets.Scripts.Global;
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
        
        private CoroutineTimer _timer;
        
        private IBufuble _bufuble;

        protected IBufuble Buffable => _bufuble;

        private void Start()
        {
            _timer = new CoroutineTimer(_timeToEnd, EndBuff);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _bufuble = other.GetComponent<IBufuble>();
                StartBuff();
                StartCoroutine(_timer.Timer());
            }
        }

        public virtual void StartBuff()
        {
            Rpc_Hide();
        }

        [Rpc(RpcSources.All, RpcTargets.All)]
        private void Rpc_Hide()
        {
            _transform.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), 1).onComplete = () => Debug.LogError("End DOSCALE");
        }
        
        public virtual void EndBuff()
        {
            var obj = transform.GetComponent<NetworkObject>();
            Runner.Despawn(obj);
        }
    }
}