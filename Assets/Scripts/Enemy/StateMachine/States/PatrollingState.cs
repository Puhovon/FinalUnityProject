using System.Collections;
using System.Linq;
using Assets.Scripts.Abstractions;
using Assets.Scripts.Enemy.StateMachine.States.Abstracts;
using Assets.Scripts.Utilities;
using UnityEngine;
using Utilities;

namespace Assets.Scripts.Enemy.StateMachine.States
{
    internal class PatrollingState : MovementState
    {
        private readonly SearchAround _searchAround;
        private bool _isChilling = false;

        public override void Enter()
        {
            base.Enter();
            View.RunningStart();
            if(Enemy.HasStateAuthority)
            {
                SetNewPatrollingPoint();
            }
        }

        public override void Exit()
        {
            base.Exit();
            View.RunningStop();
        }

        public override void Update()
        {
            if (!Enemy.HasStateAuthority)
                return;
            IsPlayerOnDetectedDistance();
            IsCharacterOnPatrolPoint();
        }

        private void IsCharacterOnPatrolPoint()
        {
            if ((Data.PatrollingPoint - Enemy.transform.position).magnitude < 0.1f && !_isChilling)
            {
                SetNewPatrollingPoint();
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
        private void SetNewPatrollingPoint()
        {
            Debug.LogError("SetNewOatrollingPoint");
            Data.PatrollingPoint = RandomPointToMove.GetRandomPoint(Enemy.Transform, Enemy.Config.PatrollingConfig.MaxDistanceToMove, Enemy.NavMeshAgent);
            Enemy.InvokeRpcSetPatrollingPoint(Data.PatrollingPoint);
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
            Enemy.NavMeshAgent.destination = Data.PatrollingPoint;
        }

        public PatrollingState(IStateSwitcher stateSwitcher,
            EnemyStateData data,
            Enemy enemy,
            SearchAround searchAround)
            : base(stateSwitcher, data, enemy, searchAround)
        {
            _searchAround = searchAround;
        }
    }
}
