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
            Debug.Log("Exit");
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
                Debug.Log("Wait");
                yield return new WaitForSeconds(1);
            }
            Debug.Log("Lose");
            StateSwitcher.SwitchState<PatrollingState>();
        }

        public LoseState(IStateSwitcher stateSwitcher, EnemyStateData data, Enemy enemy, Transform playerTransform,
            SearchAround searchAround)
            : base(stateSwitcher, data, enemy, playerTransform, searchAround) => _enemy = enemy;
    }
}
