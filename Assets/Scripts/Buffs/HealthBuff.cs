using Assets.Scripts.Abstractions;
using Assets.Scripts.Global;
using Assets.Scripts.Utilities;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Buffs
{
    public class HealthBuff : MonoBehaviour, IBuff
    {
        [SerializeField] private int _healthToAdd;
        [SerializeField] private int _timeToEnd;
        private CoroutineTimer _timer;

        [Inject] private IBufuble _bufuble;

        private void Start()
        {
            if (_bufuble is null)
                print("NULLL");
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

        public void StartBuff()
        {
            _bufuble.HealthPoints += _healthToAdd;
            transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), 1);
        }

        public void EndBuff()
        {
            if (_bufuble.HealthPoints - _healthToAdd <= 0)
            {
                _bufuble.HealthPoints = 1;
                return;
            }
            _bufuble.HealthPoints -= _healthToAdd;
            Destroy(gameObject);
        }
    }
}
