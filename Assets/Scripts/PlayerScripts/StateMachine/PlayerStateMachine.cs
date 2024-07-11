using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Abstractions;
using Assets.Scripts.PlayerScripts.Configs;
using Assets.Scripts.PlayerScripts.StateMachine.States;

namespace Assets.Scripts.PlayerScripts.StateMachine
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
                new IdlingState(this, data, player, _shooter),
                new WalkingState(this, data, player, _shooter),
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