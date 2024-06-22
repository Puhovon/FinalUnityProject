using Assets.Scripts.Abstractions;
using UnityEngine;
using Utilities;
using Zenject;

namespace Assets.Scripts.Enemy.StateMachine.States.Abstracts
{
    public abstract class DetectedState : IState
    {
        protected readonly IStateSwitcher StateSwitcher;
        protected readonly EnemyStateData Data;

        private readonly Enemy _enemy;
        [Inject]
        private readonly Transform _playerTransform;
        protected SearchAround SearchAround;

        protected EnemyView View => _enemy.View;
        protected Transform PlayerTransform => _playerTransform;

        public DetectedState(IStateSwitcher stateSwitcher, EnemyStateData data, Enemy enemy, SearchAround searchAround)
        {
            StateSwitcher = stateSwitcher;
            _enemy = enemy;
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
