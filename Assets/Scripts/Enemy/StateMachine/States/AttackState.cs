﻿using System.Collections;
using System.Linq;
using Assets.Scripts.Abstractions;
using Assets.Scripts.Enemy.Configs;
using Assets.Scripts.Enemy.StateMachine.States.Abstracts;
using UnityEngine;
using Utilities;

namespace Assets.Scripts.Enemy.StateMachine.States
{
    public class AttackState : DetectedState
    {
        private readonly AttackConfig _config;
        private Enemy _enemy;
        private bool _canAttack;
        private bool _seePlayer;
        public AttackState(IStateSwitcher stateSwitcher, EnemyStateData data, Enemy enemy, Transform playerTransform, SearchAround searchAround)
            : base(stateSwitcher, data, enemy, playerTransform, searchAround)
        {
            _enemy = enemy;
            _config = enemy.Config.AttackConfig;
        }

        public override void Enter()
        {
            base.Enter();
            View.IdlingStart();
        }

        public override void Exit()
        {
            base.Exit();
            View.IdlingStop();
        }

        public override void Update()
        {
            base.Update();
            var finded = SearchAround.Find().FirstOrDefault(f => f is PlayerScripts.Player);

            if (finded == null)
                StateSwitcher.SwitchState<LoseState>();

            _enemy.NavMeshAgent.Move(PlayerTransform.position);
            if (_enemy.NavMeshAgent.destination.magnitude <= _config.DistanceToAttack)
                _canAttack = true;
            if (_canAttack)
            {
                Attack();
            }
        }

        private void Attack()
        {
            Debug.Log("ATTACK");
            _canAttack = false;
        }

        private IEnumerator Reload()
        {
            yield return new WaitForSeconds(_config.TimeToNextAttack);
            _canAttack = true;
        }
    }
}