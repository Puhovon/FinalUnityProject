using Assets.Scripts.PlayerScripts;
using Assets.Scripts.Abstractions;
using System;
using UnityEngine;
namespace Assets.Scripts.Buffs
{
    internal class SpeedBuff : Buff
    {
        [SerializeField] private int speedMagnifier;
        public override void StartBuff()
        {
            base.StartBuff();
            Player.CharacterController.maxSpeed += speedMagnifier;
        }

        public override void EndBuff()
        {
            Player.CharacterController.maxSpeed -= speedMagnifier;
            base.EndBuff();
        }
    }
}
