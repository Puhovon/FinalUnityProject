using System;
using UnityEngine;

namespace Player.StateMachine
{
    public class PlayerStateData
    {
        public Vector2 Velocity;

        private float _speed;
        private Vector2 _input;

        private int _ammo;
        private int _maxAmmo;

        public int MaxAmmo => _maxAmmo;

        public int Ammo
        {
            get => _ammo;
            set
            {
                if (value < 0 || value > _maxAmmo)
                    throw new ArgumentOutOfRangeException("invalid ammo count");
                _ammo = value;
            }
        }

        public Vector2 InputValue
        {
            get => _input;
            set
            {
                if (value.x < -1 || value.x > 1)
                    throw new ArgumentOutOfRangeException(nameof(value));
                
                if (value.y < -1 || value.y > 1)
                    throw new ArgumentOutOfRangeException(nameof(value));

                _input = value;
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

        public PlayerStateData(int maxAmmo)
        {
            _maxAmmo = maxAmmo;
        }
    }
}