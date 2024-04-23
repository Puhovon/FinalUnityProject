namespace Player.StateMachine.States
{
    public interface IStateSwitcher
    {
        void SwitchState<T>() where T : IState;
    }
}