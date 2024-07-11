using Assets.Scripts.Abstractions;
using Fusion;
using Unity.Mathematics;
using UnityEngine;

namespace Assets.Scripts.PlayerScripts.StateMachine.States
{
    public abstract class MovementState : IState
    {
        protected readonly IStateSwitcher StateSwitcher;
        protected readonly PlayerStateData Data;
        private Player _player;
        protected readonly Shooter _shooter;

        public MovementState(IStateSwitcher stateSwitcher, PlayerStateData data, Player player, Shooter shooter)
        {
            StateSwitcher = stateSwitcher;
            _player = player;
            Data = data;
            _shooter = shooter;
        }

        protected Shooter Shooter => _shooter;
        protected MainInputActions Input => _player.Input;
        protected NetworkCharacterController CharacterController => _player.CharacterController;
        protected PlayerView View => _player.View;
        protected Player Player => _player;
        
        public virtual void Enter() { }

        public virtual void Exit() { }

        public virtual void Update()
        {
            Vector3 velocity = GetConvertedVelocity();
            Debug.LogWarning(_player.Transform.rotation);
            CharacterController.Move(velocity * Time.deltaTime);
        }

        private Vector3 GetConvertedVelocity() => new Vector3(Data.Velocity.x, 0, Data.Velocity.y);

        public void HandleInput()
        {
            if (!Player.Object.HasInputAuthority)
                return;
            Data.InputValue = ReadInput();
            Data.Velocity = Data.InputValue * Data.Speed;
        }

        private float2 ReadInput() => Input.Movement.Move.ReadValue<Vector2>();
        protected bool IsInputZero() => Data.InputValue == Vector2.zero;
        protected bool isShooting() => Input.Movement.Shoot.IsPressed();
    }
}