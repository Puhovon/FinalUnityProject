using Assets.Scripts.Abstractions;
using UnityEngine;

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
            Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
            if (!Player.Object.HasStateAuthority)
                return;
            base.Update();
            Debug.Log("-------------------------------------");
            if (isShooting())
                Shooter.Shoot?.Invoke(Data);
            if (IsInputZero())
                return;

            StateSwitcher.SwitchState<WalkingState>();
        }
    }
}