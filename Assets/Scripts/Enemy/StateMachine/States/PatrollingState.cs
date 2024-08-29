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
        private bool _isChilling = false;

        public override void Enter()
        {
            base.Enter();
            View.RunningStart();
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
            if(!Enemy.HasStateAuthority)
                return;
            if ((Enemy.pointToMove - Enemy.transform.position).magnitude < 0.1f && !_isChilling || Enemy.pointToMove == Vector3.zero)
            {
                Enemy.StartCoroutine(Chill());
            }
        }

        private void IsPlayerOnDetectedDistance()
        {
            if(!Enemy.HasStateAuthority)
                return;
            var finded = _searchAround.Find().FirstOrDefault(r => r is PlayerScripts.Player);
            if (finded != null)
            {
                StateSwitcher.SwitchState<AttackState>();
            }
        }
        private void SetNewPatrollingPoint()
        {
            if(!Enemy.HasStateAuthority)
                return;
            Enemy.InvokeRpcSetPatrollingPoint();
        }

        private IEnumerator Chill()
        {
            if(Enemy.HasStateAuthority)
            {
                _isChilling = true;
                View.RunningStop();
                View.IdlingStart();
                for (int i = 0; i < Data.ChillTime; i++)
                {
                    yield return new WaitForSeconds(1);
                }
                View.IdlingStop();
                View.RunningStart();
                _isChilling = false;
                SetNewPatrollingPoint();
            }
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
