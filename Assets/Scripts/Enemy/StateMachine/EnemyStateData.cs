using System;
using UnityEngine;

namespace Assets.Scripts.Enemy.StateMachine
{
    public class EnemyStateData
    {
        public Vector2 Velocity;

        private float _speed;
        private Vector2 _input;

        
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
    }
}
