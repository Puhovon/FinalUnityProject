using System.Collections.Generic;
using System.Linq;
using Player.StateMachine.States;

namespace Player.StateMachine
{
    public class PlayerStateMachine : IStateSwitcher
    {
        private Shooter _shooter;
        private List<IState> _states;
        private IState _currentState;
        
        public PlayerStateMachine(Player player, Shooter shooter, PlayerConfig config)
        {
            PlayerStateData data = new PlayerStateData(config.WalkingStateConfig.MaxAmmo);
            _shooter = shooter;
            _states = new List<IState>()
            {
                new IdlingState(this, data, player),
                new RunningState(this, data, player),
                new WalkingState(this, data, player, _shooter),
                new ReloadingState(this, data, player),
            };
            _currentState = _states[0];
            _currentState.Enter();
        }
        
        public void SwitchState<T>() where T : IState
        {
            IState state = _states.FirstOrDefault(state => state is T);
            
            _currentState.Exit();
            _currentState = state;
            _currentState?.Enter();
        }

        public void HandleInput() => _currentState.HandleInput();

        public void Update() => _currentState.Update();
    }
}