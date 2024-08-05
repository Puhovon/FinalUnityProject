using Fusion;
using UnityEngine;

namespace Assets.Scripts.Enemy.StateMachine
{
    [RequireComponent(typeof(Animator))]
    public class EnemyView : NetworkBehaviour
    {
        private const string isIdling = "IsIdling";
        private const string isRunning = "IsRunning";
        private const string isChilling = "IsChilling";
        
        private Animator _animator;

        public void Initialize()
        {
            _animator = GetComponent<Animator>();
        }

        public void IdlingStop() => _animator.SetBool(isIdling, false);
        public void IdlingStart() => _animator.SetBool(isIdling, true);

        public void RunningStart() => _animator.SetBool(isRunning, true);
        public void RunningStop() => _animator.SetBool(isRunning, false);

        public void ChillingStart() => _animator.SetBool(isChilling, true);
        public void ChillingStop() => _animator.SetBool(isChilling, false);
    }
}