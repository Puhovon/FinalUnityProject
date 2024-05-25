using Assets.Scripts.Abstractions;
using UnityEngine;
using Utilities;

namespace Assets.Scripts.Enemy.StateMachine.States.Abstracts
{
    public abstract class DetectedState : IState
    {
        protected readonly IStateSwitcher StateSwitcher;
        protected readonly EnemyStateData Data;

        private readonly Enemy _enemy;
        private readonly Transform _playerTransform;
        protected SearchAround SearchAround;
        protected CharacterController CharacterController => _enemy.СharacterController;
        protected EnemyView View => _enemy.View;
        protected Transform PlayerTransform => _playerTransform;

        public DetectedState(IStateSwitcher stateSwitcher, EnemyStateData data, Enemy enemy, Transform playerTransform, SearchAround searchAround)
        {
            StateSwitcher = stateSwitcher;
            _enemy = enemy;
            _playerTransform = playerTransform;
            SearchAround = searchAround;
            Data = data;

        }

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

        public virtual void HandleInput() { }
    }
}
