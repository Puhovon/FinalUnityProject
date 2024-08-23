using Assets.Scripts.Abstractions;
using Assets.Scripts.NetworkTest;
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
        protected NetworkBehaviour Input => _player;
        protected NetworkCharacterController CharacterController => _player.CharacterController;
        protected PlayerView View => _player.View;
        protected Player Player => _player;

        public virtual void Enter()
        {
        }

        public virtual void Exit()
        {
        }

        public virtual void Update()
        {
            if(IsInputZero())
                return;
            Vector3 velocity = GetConvertedVelocity();
            Vector3 dir = Data.Quanternion;
            dir.Normalize();
            
            CharacterController.Move(velocity * Player.Runner.DeltaTime);
            // Player.transform.forward = velocity;
        }

        private Vector3 GetConvertedVelocity() => new Vector3(Data.Velocity.x, 0, Data.Velocity.y);

        public void HandleInput()
        {
            Data.InputValue = ReadInput();
            Data.Velocity = Data.InputValue * Data.Speed;
        }

        
        
        private float2 ReadInput()
        {
            if (Input.Runner.TryGetInputForPlayer<NetworkInputData>(Input.Object.InputAuthority, out NetworkInputData data))
                return new float2(data.movement.x, data.movement.z);
            return float2.zero;
        }
        protected bool IsInputZero() => Data.InputValue == Vector2.zero;
        protected bool isShooting() {
            if(Input.Runner.TryGetInputForPlayer<NetworkInputData>(Input.Object.InputAuthority, out NetworkInputData data))
            {
                var pressed = data.buttons.GetPressed(Player.ButtonsPrevious);
                Player.ButtonsPrevious = data.buttons;
                if (pressed.IsSet(MyButtons.Fire))
                {
                    return true;
                }
            }
            return false;
        }
    }
}