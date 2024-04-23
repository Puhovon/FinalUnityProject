using Player.Configs;

namespace Player.StateMachine.States
{
    public class RunningState : MovementState
    {
        private readonly RunningStateConfig _config;

        public RunningState(IStateSwitcher stateSwitcher, PlayerStateData data, Player player) : base(stateSwitcher,
            data, player)
            => _config = player.Config.RunningStateConfig;
        public override void Enter()
        {
            base.Enter();
            View.RunningStart();
            Data.Speed = _config.Speed;
        }

        public override void Exit()
        {
            base.Exit();
            View.RunningStop();
        }

        public override void Update()
        {
            base.Update();
            if(isShooting())
                StateSwitcher.SwitchState<WalkingState>();
            if(!IsInputZero())
                return;
            StateSwitcher.SwitchState<IdlingState>();
        }
    }
}