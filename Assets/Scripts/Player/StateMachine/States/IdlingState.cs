namespace Player.StateMachine.States
{
    public class IdlingState : MovementState
    {
        public IdlingState(IStateSwitcher stateSwitcher, PlayerStateData data, Player player) : base(stateSwitcher, data, player)
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
            base.Update();

            if(isShooting())
                StateSwitcher.SwitchState<WalkingState>();
            if (IsInputZero())
                return;
            StateSwitcher.SwitchState<RunningState>();

        }
    }
}