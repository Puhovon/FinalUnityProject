using Assets.Scripts.Abstractions;
using Assets.Scripts.PlayerScripts.Configs;
using UnityEngine;

namespace Assets.Scripts.PlayerScripts.StateMachine.States
{
    public class WalkingState : MovementState
    {
        
        private readonly WalkingStateConfig _config;
        private readonly Shooter _shooter;

        public WalkingState(IStateSwitcher stateSwitcher, PlayerStateData data, Player player, Shooter shooter) : base(stateSwitcher,
            data, player)
        {
            _config = player.Config.WalkingStateConfig;
            _shooter = shooter;
        }

        public override void Enter()
        {
            base.Enter();
            View.RunningStart();
            Data.Speed = _config.Speed;
            Debug.Log(Data.Ammo);
        }

        public override void Exit()
        {
            base.Exit();
            View.RunningStop();

        }

        public override void Update()
        {
            base.Update();
            
            if(IsInputZero())
                StateSwitcher.SwitchState<IdlingState>();
        }

    }
}