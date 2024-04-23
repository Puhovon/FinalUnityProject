using Player.Configs;
using UnityEngine;

namespace Player.StateMachine.States
{
    public class ReloadingState : MovementState
    {
        private readonly ReloadingStateConfig _config;

        private float _currentTime;
        public ReloadingState(IStateSwitcher stateSwitcher, PlayerStateData data, Player player) : base(stateSwitcher,
            data, player) =>
            _config = player.Config.ReloadingStateConfig;

        public override void Enter()
        {
            base.Enter();
            _currentTime = _config.TimeToReload;
        }

        public override void Exit()
        {
            base.Exit();
            Debug.Log("ReloadDone");
        }

        public override void Update()
        {
            base.Update();
            if(_currentTime <= 0)
            {
                Data.Ammo = Data.MaxAmmo;
                StateSwitcher.SwitchState<WalkingState>();
            }
            _currentTime -= Time.deltaTime;
        }
        
        
    }
}