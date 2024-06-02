using System;
using UnityEngine;

namespace Assets.Scripts.Enemy.StateMachine
{
    public class EnemyStateData
    {
        public Vector2 Velocity;

        private float _speed;
        private float _chillTime;

        private Transform[] _patrollingPoints;


        public float ChillTime
        {
            get => _chillTime;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                _chillTime = value;
            }
        }

        public Transform[] PatrollingPoints
        {
            get => _patrollingPoints;
            set
            {
                if (value.Length <= 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                _patrollingPoints = value;
            }
        }

        public float Speed
        {
            get => _speed;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                _speed = value;
            }
        }

        public EnemyStateData(float speed, float chillTime, Transform[] patrollingPoints)
        {
            _speed = speed;
            _chillTime = chillTime;
            _patrollingPoints = patrollingPoints;
        }
    }
}
