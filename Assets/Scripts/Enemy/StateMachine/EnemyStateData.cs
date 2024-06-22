using System;
using UnityEngine;

namespace Assets.Scripts.Enemy.StateMachine
{
    public class EnemyStateData
    {
        public Vector2 Velocity;

        private float _speed;
        private float _chillTime;

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

        public Vector3 PatrollingPoint { get; set; }

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

        public EnemyStateData(float speed, float chillTime)
        {
            _speed = speed;
            _chillTime = chillTime;
        }
    }
}
