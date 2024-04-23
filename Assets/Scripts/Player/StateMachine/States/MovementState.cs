﻿using Unity.Mathematics;
using UnityEngine;

namespace Player.StateMachine.States
{
    public abstract class MovementState : IState
    {
        protected readonly IStateSwitcher StateSwitcher;
        protected readonly PlayerStateData Data;
        private Player _player;
        
        public MovementState(IStateSwitcher stateSwitcher, PlayerStateData data, Player player)
        {
            StateSwitcher = stateSwitcher;
            _player = player;
            Data = data;
        }

        protected MainInputActions Input => _player.Input;
        protected CharacterController CharacterController => _player.CharacterController;
        protected PlayerView View => _player.View;
        
        public virtual void Enter()
        {

        }

        public virtual void Exit()
        {
        }

        public virtual void Update()
        {
            Vector3 velocity = GetConvertedVelocity();
            CharacterController.Move(velocity * Time.deltaTime);
        }

        private Vector3 GetConvertedVelocity() => new Vector3(Data.Velocity.x, 0, Data.Velocity.y);

        public void HandleInput()
        {
            Data.InputValue = ReadInput();
            Data.Velocity = Data.InputValue * Data.Speed;
        }

        private float2 ReadInput() => Input.Movement.Move.ReadValue<Vector2>();
        protected bool IsInputZero() => Data.InputValue == Vector2.zero;
        protected bool isShooting() => Input.Movement.Shoot.IsPressed();
    }
}