using System.Collections;
using System.Linq;
using Assets.Scripts.Abstractions;
using Assets.Scripts.Enemy.StateMachine.States.Abstracts;
using UnityEngine;
using Utilities;

namespace Assets.Scripts.Enemy.StateMachine.States
{
    internal class PatrollingState : MovementState
    {
        private readonly SearchAround _searchAround;
        private int _currentPoint = 0;
        private bool _isChilling = false;

        public override void Enter()
        {
            base.Enter();
            View.RunningStart();
            Enemy.NavMeshAgent.destination = (Data.PatrollingPoints[_currentPoint].position);
        }

        public override void Exit()
        {
            base.Exit();
            View.RunningStop();
        }

        public override void Update()
        {
            IsPlayerOnDetectedDistance();
            IsCharacterOnPatrolPoint();
        }

        private void IsCharacterOnPatrolPoint()
        {
            if ((Data.PatrollingPoints[_currentPoint].position - Enemy.transform.position).magnitude < 0.1f && !_isChilling)
            {
                if (_currentPoint == Data.PatrollingPoints.Length - 1)
                    _currentPoint = 0;
                else
                    _currentPoint++;
                Enemy.StartCoroutine(Chill());
            }
        }

        private void IsPlayerOnDetectedDistance()
        {
            var finded = _searchAround.Find().FirstOrDefault(r => r is PlayerScripts.Player);
            if (finded != null)
            {
                StateSwitcher.SwitchState<AttackState>();
            }
        }

        private IEnumerator Chill()
        {
            _isChilling = true;

            //View.RunningStop();
            //View.ChillingStart();
            
            for (int i = 0; i < Data.ChillTime; i++)
            {
                yield return new WaitForSeconds(1);
            }
            
            //View.ChillingStop();
            //View.RunningStart();
            
            _isChilling = false;
            Enemy.NavMeshAgent.destination = Data.PatrollingPoints[_currentPoint].position;
        }

        public PatrollingState(IStateSwitcher stateSwitcher,
            EnemyStateData data,
            Enemy enemy,
            Transform playerTransform,
            SearchAround searchAround)
            : base(stateSwitcher, data, enemy, playerTransform, searchAround)
        {
            _searchAround = searchAround;
        }
    }
}
