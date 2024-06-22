using Assets.Scripts.Abstractions;
using Assets.Scripts.Utilities;
using UnityEngine;
using Utilities;

namespace Assets.Scripts.Enemy.StateMachine.States.Abstracts
{
    public abstract class MovementState : IState
    {
        protected readonly IStateSwitcher StateSwitcher;
        protected readonly EnemyStateData Data;
        protected readonly SearchAround SearchAround;

        private readonly Enemy _enemy;
        private readonly Transform _playerTransform;
        private readonly RandomPointToMove _randomPointToMove;

        public MovementState(IStateSwitcher stateSwitcher, EnemyStateData data, Enemy enemy, SearchAround searchAround, RandomPointToMove randomMove)
        {
            StateSwitcher = stateSwitcher;
            SearchAround = searchAround;
            _enemy = enemy;
            Data = data;
            _randomPointToMove = randomMove;
        }

        protected EnemyView View => _enemy.View;
        protected Enemy Enemy => _enemy;

        protected RandomPointToMove RandomPointToMove => _randomPointToMove;

        public virtual void Enter()
        {

        }

        public virtual void Exit()
        {
        }

        public virtual void Update()
        {
            
        }

        public void HandleInput() { }


    }
}
