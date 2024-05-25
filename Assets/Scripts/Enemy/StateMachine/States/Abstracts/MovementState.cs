using Assets.Scripts.Abstractions;
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

        public MovementState(IStateSwitcher stateSwitcher, EnemyStateData data, Enemy enemy, Transform playerTransform, SearchAround searchAround)
        {
            StateSwitcher = stateSwitcher;
            SearchAround = searchAround;
            _enemy = enemy;
            _playerTransform = playerTransform;
            Data = data;
        }

        protected CharacterController CharacterController => _enemy.СharacterController;
        protected EnemyView View => _enemy.View;
        protected Transform PlayerTransform => _playerTransform;

        public virtual void Enter()
        {
            Debug.Log(GetType());

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
