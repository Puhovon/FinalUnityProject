using Assets.Scripts.PlayerScripts;
using Assets.Scripts.Abstractions;
using System;
using UnityEngine;
namespace Assets.Scripts.Buffs
{
    internal class SpeedBuff : Buff
    {
        [SerializeField] private PlayerScripts.Player player;
        [SerializeField] private int speedMagnifier;
        public override void StartBuff()
        {
            base.StartBuff();
            player.CharacterController.maxSpeed += speedMagnifier;
        }

        public override void EndBuff()
        {
            player.CharacterController.maxSpeed -= speedMagnifier;
            base.EndBuff();
        }
    }
}
