using System.Collections;
using System.Linq;
using Assets.Scripts.Abstractions;
using Assets.Scripts.Enemy.StateMachine.States.Abstracts;
using UnityEngine;
using Utilities;

namespace Assets.Scripts.Enemy.StateMachine.States
{
    public class LoseState : DetectedState
    {
        private Enemy _enemy;

        public override void Enter()
        {
            base.Enter();
            _enemy.StartCoroutine(LoseTimer());
        }

        public override void Exit()
        {
            base.Exit();
            _enemy.StopCoroutine(LoseTimer());
        }

        public override void Update()
        {
            base.Update();
            
            var finded = SearchAround.Find().FirstOrDefault(f => f is PlayerScripts.Player);
            
            if(finded != null)
                StateSwitcher.SwitchState<AttackState>();
        }

        private IEnumerator LoseTimer()
        {
            for (int i = 0; i < _enemy.Config.DetectedConfig.TimeToLosePlayer; i++)
            {
                yield return new WaitForSeconds(1);
            }
            StateSwitcher.SwitchState<PatrollingState>();
        }

        public LoseState(IStateSwitcher stateSwitcher, EnemyStateData data, Enemy enemy,
            SearchAround searchAround)
            : base(stateSwitcher, data, enemy, searchAround) => _enemy = enemy;
    }
}
