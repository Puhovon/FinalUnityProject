using Assets.Scripts.Abstractions;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Enemy.StateMachine.States;
using Assets.Scripts.PlayerScripts;
using Assets.Scripts.Utilities;
using UnityEngine;
using UnityEngine.AI;
using Utilities;

namespace Assets.Scripts.Enemy.StateMachine
{
    public class EnemyStateMachine : IStateSwitcher
    {
        private List<IState> _states;
        private IState _currentState;

        public EnemyStateMachine(Enemy enemy, EnemyConfigs config,
            EnemyStateData enemyStateData, NavMeshAgent agent)
        {
            SearchAround searchAround = new SearchAround(enemy.transform, config.PatrollingConfig.DistanceToDetect);
            RandomPointToMove randomPointToMove =
                new RandomPointToMove(agent, enemy.Transform, config.PatrollingConfig.MaxDistanceToMove);
            _states = new List<IState>()
            {
                new PatrollingState(this, enemyStateData, enemy, searchAround, randomPointToMove),
                new AttackState(this, enemyStateData, enemy, searchAround),
                new LoseState(this, enemyStateData, enemy, searchAround),
            };
            _currentState = _states[0];
            _currentState.Enter();
        }

        public void SwitchState<T>() where T : IState
        {
            IState state = _states.FirstOrDefault(state => state is T);

            _currentState.Exit();
            _currentState = state;
            _currentState?.Enter();
        }

        public void Update() => _currentState.Update();
    }
}
