using Assets.Scripts.Abstractions;
using Assets.Scripts.Global;
using Assets.Scripts.Utilities;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Buffs
{
    public class ShieldBuff : MonoBehaviour, IBuff
    {
        [Inject]
        private IBufuble _bufuble;
        
        [SerializeField] private int _damageReduction;
        [SerializeField] private int _timeToEnd;
        private CoroutineTimer _timer;

        private void Start()
        {
            _timer = new CoroutineTimer(_timeToEnd, EndBuff);
        }

        private void OnTriggerEnter(Collider other) 
        {
            if (other.CompareTag("Player"))
            {
                StartBuff();
                StartCoroutine(_timer.Timer());
            }
        }

        public void StartBuff() {
            _bufuble.DamageReduction += _damageReduction;
            transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), 1);
        }
        

        public void EndBuff()
        {
            _bufuble.DamageReduction -= _damageReduction;
            if (_bufuble.DamageReduction < 0)
            {
                _bufuble.DamageReduction = 0;
            }
            Destroy(gameObject);
        }

    }
}
