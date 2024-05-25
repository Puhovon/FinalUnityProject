namespace Assets.Scripts.Abstractions
{
    public interface IState
    {
        void Enter();
        void Exit();
        void Update();
        void HandleInput();
    }
}