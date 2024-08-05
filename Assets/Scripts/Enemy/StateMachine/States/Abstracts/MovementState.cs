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

        public MovementState(IStateSwitcher stateSwitcher, EnemyStateData data, Enemy enemy, SearchAround searchAround)
        {
            StateSwitcher = stateSwitcher;
            SearchAround = searchAround;
            _enemy = enemy;
            Data = data;
        }

        protected EnemyView View => _enemy.View;
        protected Enemy Enemy => _enemy;

        

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
