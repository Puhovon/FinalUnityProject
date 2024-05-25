using System.Linq;
using Assets.Scripts.Abstractions;
using Assets.Scripts.Enemy.StateMachine.States.Abstracts;
using UnityEngine;
using Utilities;

namespace Assets.Scripts.Enemy.StateMachine.States
{
    internal class PatrollingState : MovementState
    {
        private SearchAround _searchAround;
        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            var finded = _searchAround.Find().FirstOrDefault(r => r is PlayerScripts.Player);
            if (finded != null)
            {
                StateSwitcher.SwitchState<AttackState>();
            }
        }

        public PatrollingState(IStateSwitcher stateSwitcher, EnemyStateData data, Enemy enemy, Transform playerTransform, SearchAround searchAround) 
            : base(stateSwitcher, data, enemy, playerTransform, searchAround)
        {
            _searchAround = searchAround;
        }
    }
}
