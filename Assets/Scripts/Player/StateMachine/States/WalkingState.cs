using Player.Configs;

namespace Player.StateMachine.States
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
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();
            if(isShooting())
            {
                if (Data.Ammo > 0)
                {
                    _shooter.shoot?.Invoke();
                    Data.Ammo -= 1;
                }
                else 
                    StateSwitcher.SwitchState<ReloadingState>();
                return;
            }
            if(IsInputZero())
                StateSwitcher.SwitchState<IdlingState>();
        }

    }
}