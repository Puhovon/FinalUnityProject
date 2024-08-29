using System.Collections;
using System.Linq;
using Assets.Scripts.Abstractions;
using Assets.Scripts.Enemy.Configs;
using Assets.Scripts.Enemy.StateMachine.States.Abstracts;
using UnityEngine;
using Utilities;

namespace Assets.Scripts.Enemy.StateMachine.States
{
    public class AttackState : DetectedState
    {
        private readonly AttackConfig _config;
        private readonly Enemy _enemy;
        private bool _canAttack = true;
        private bool _seePlayer;

        public AttackState(IStateSwitcher stateSwitcher, EnemyStateData data, Enemy enemy, SearchAround searchAround)
            : base(stateSwitcher, data, enemy, searchAround)
        {
            _enemy = enemy;
            _config = enemy.Config.AttackConfig;
        }

        public override void Enter()
        {
            base.Enter();
            View.IdlingStart();
        }

        public override void Exit()
        {
            base.Exit();
            View.IdlingStop();
        }

        public override void Update()
        {
            base.Update();
            var finded = SearchAround.Find().FirstOrDefault(f => f is PlayerScripts.Player);

            if (finded == null)
                StateSwitcher.SwitchState<LoseState>();

            IsCanAttack(finded);
        }

        private void IsCanAttack(IEntity finded)
        {
            if ((_enemy.transform.position - finded.Transform.position).magnitude <= _config.DistanceToAttack) {
                _enemy.NavMeshAgent.isStopped = true;
                Attack(finded);
            } else
            {
                _enemy.NavMeshAgent.isStopped = false;
                _enemy.NavMeshAgent.destination = (finded.Transform.position);
            }
        }
        
        private void Attack(IEntity finded)
        {
            if (_canAttack && finded.Transform.TryGetComponent(out IDamagable damagable))
            {
                View.Shoot();
                _enemy.StartCoroutine(Reload(damagable));
            }
        }

        private IEnumerator Reload(IDamagable damagable)
        {
            _canAttack = false;
            yield return new WaitForSeconds(_config.TimeToNextAttack);
            damagable.Rpc_TakeDamage(_config.Damage);
            _canAttack = true;
        }
    }
}
