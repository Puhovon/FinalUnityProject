namespace Assets.Scripts.Abstractions
{
    public interface IStateSwitcher
    {
        void SwitchState<T>() where T : IState;
    }
}