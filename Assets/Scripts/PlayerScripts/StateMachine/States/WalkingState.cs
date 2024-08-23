using Assets.Scripts.Abstractions;
using Assets.Scripts.PlayerScripts.Configs;

namespace Assets.Scripts.PlayerScripts.StateMachine.States
{
    public class WalkingState : MovementState
    {
        
        private readonly WalkingStateConfig _config;

        public WalkingState(IStateSwitcher stateSwitcher, PlayerStateData data, Player player, Shooter shooter) : base(stateSwitcher,
            data, player, shooter)
        {
            _config = player.Config.WalkingStateConfig;
        }

        public override void Enter()
        {
            base.Enter();
            View.RunningStart();
            Data.Speed = _config.Speed;
        }

        public override void Exit()
        {
            if (!Player.HasInputAuthority)
                return;
            base.Exit();
            View.RunningStop();
        }

        public override void Update()
        {
            base.Update();
            if(isShooting())
                Shooter.Shoot?.Invoke(Data);
            if(IsInputZero())
                StateSwitcher.SwitchState<IdlingState>();
        }

    }
}