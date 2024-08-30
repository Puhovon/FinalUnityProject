using System;
using Fusion;
using UnityEngine;

namespace Assets.Scripts.Enemy.StateMachine
{
    [RequireComponent(typeof(Animator))]
    public class EnemyView : NetworkBehaviour
    {
        [SerializeField] private Animator _animator;

        private const string isIdling = "IsIdling";
        private const string isRunning = "IsRunning";
        private const string isChilling = "IsChilling";
        private const string Punch = "Punch";

        public void IdlingStop()
        {
            if (HasStateAuthority)
            {
                Rpc_SetIdling(false);
            }
        }

        public void IdlingStart()
        {
            if (HasStateAuthority)
            {
                Rpc_SetIdling(true);
            }
        }

        public void RunningStart()
        {
            if (HasStateAuthority)
            {

                Rpc_SetRunning(true);
            }
        }

        public void RunningStop()
        {
            if (HasStateAuthority)
            {
                Rpc_SetRunning(false);
            }
        }

        public void Dying()
        {
            if (HasStateAuthority)
            {
                Rpc_Die();
            }
        }

       
        
        // public void ChillingStart()
        // {
        //     if (HasStateAuthority)
        //     {
        //
        //     }
        // }
        //
        // public void ChillingStop()
        // {
        //     if (HasStateAuthority)
        //     {
        //
        //     }
        // }

        public void Shoot()
        {
            if (HasStateAuthority)
            {
                Rpc_Shoot();
            }
        }
        
        [Rpc(RpcSources.StateAuthority, RpcTargets.All)]
        private void Rpc_SetIdling(bool IsIdling)
        {
            _animator.SetBool(isIdling, IsIdling);
        }

        [Rpc(RpcSources.StateAuthority, RpcTargets.All)]
        private void Rpc_SetRunning(bool IsRunning)
        {
            _animator.SetBool(isRunning, IsRunning);
        }

        [Rpc(RpcSources.StateAuthority, RpcTargets.All)]
        private void Rpc_Shoot()
        {
            _animator.SetTrigger(Punch);   
        }
        
        [Rpc(RpcSources.StateAuthority, RpcTargets.All)]
        private void Rpc_Die()
        {
            _animator.SetTrigger("Die");
        }
    }
}