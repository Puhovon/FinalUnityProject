﻿using Assets.Scripts.Abstractions;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Enemy.StateMachine.States;
using Assets.Scripts.PlayerScripts;
using UnityEngine;
using Utilities;

namespace Assets.Scripts.Enemy.StateMachine
{
    public class EnemyStateMachine : IStateSwitcher
    {
        private Shooter _shooter;
        private List<IState> _states;
        private IState _currentState;
        private Transform _playerTransform;

        public EnemyStateMachine(Enemy enemy, Shooter shooter, EnemyConfigs config, Transform playerTransform,
            EnemyStateData enemyStateData)
        {
            _shooter = shooter;
            _playerTransform = playerTransform;
            
            SearchAround searchAround = new SearchAround(enemy.transform, config.PatrollingConfig.DistanceToDetect);
            _states = new List<IState>()
            {
                new PatrollingState(this, enemyStateData, enemy, playerTransform, searchAround),
                new AttackState(this, enemyStateData, enemy, _playerTransform, searchAround),
                new LoseState(this, enemyStateData, enemy, playerTransform, searchAround),
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
