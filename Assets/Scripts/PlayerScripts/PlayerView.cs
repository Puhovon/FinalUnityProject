using FMOD.Studio;
using Fusion;
using UnityEngine;

namespace Assets.Scripts.PlayerScripts
{
    [RequireComponent(typeof(Animator))]
    public class PlayerView : NetworkBehaviour
    {
        [SerializeField] private Animator _animator;

        private const string IsIdling = "IsIdling";
        private const string IsRunning = "IsRunning";
        

        
        public void Initialize()
        {
            // _animator = GetComponent<Animator>();
        }

        public void IdlingStop()
        {
            if (HasStateAuthority)
            {
                RPC_SetIdling(false);
            }
        }

        public void IdlingStart()
        {
            if (HasStateAuthority)
            {
                RPC_SetIdling(true);
            }
        }

        public void RunningStart()
        {
            if (HasStateAuthority)
            {
                RPC_SetRunning(true);
            }
        }

        public void RunningStop()
        {
            if (HasStateAuthority)
            {
                RPC_SetRunning(false);
            }
        }

        [Rpc(RpcSources.StateAuthority, RpcTargets.All)]
        private void RPC_SetIdling(bool isIdling)
        {
            _animator.SetBool(IsIdling, isIdling);
        }

        [Rpc(RpcSources.StateAuthority, RpcTargets.All)]
        private void RPC_SetRunning(bool isRunning)
        {
            _animator.SetBool(IsRunning, isRunning);
        }
    }
}