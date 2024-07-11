using Assets.Scripts.Abstractions;

namespace Assets.Scripts.PlayerScripts.StateMachine.States
{
    public class IdlingState : MovementState
    {
        public IdlingState(IStateSwitcher stateSwitcher, PlayerStateData data, Player player, Shooter shooter) : base(stateSwitcher, data, player, shooter)
        {
        }

        public override void Enter()
        {
            base.Enter();
            View.IdlingStart();
        }

        public override void Exit()
        {
            base.Exit();
            View.IdlingStop();
        }

        public override void Update()
        {
            if (!Player.Object.HasInputAuthority)
                return;
            base.Update();
            if (isShooting())
                Shooter.Shoot?.Invoke(Data);
            if (IsInputZero())
                return;

            StateSwitcher.SwitchState<WalkingState>();
        }
    }
}