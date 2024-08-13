using Assets.Scripts.PlayerScripts;
using Assets.Scripts.Abstractions;
using System;
using UnityEngine;
namespace Assets.Scripts.Buffs
{
    internal class SpeedBuff : MonoBehaviour, IBuff
    {
        [SerializeField] private PlayerScripts.Player player;
        public void StartBuff()
        {
            //player.CharacterController.velocity
        }

        public void EndBuff()
        {
            // throw new NotImplementedException();
        }
    }
}
