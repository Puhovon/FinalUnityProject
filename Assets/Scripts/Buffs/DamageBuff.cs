using Assets.Scripts.Abstractions;
using Assets.Scripts.PlayerScripts;
using UnityEngine;

namespace Assets.Scripts.Buffs
{
    public class DamageBuff : Buff
    {
        [SerializeField] private int _damageMagnifier;

        public override void StartBuff()
        {
            base.StartBuff();
            Shooter.DamageMagnifier += _damageMagnifier;
        }
        
        public override void EndBuff()
        {
            Shooter.DamageMagnifier -= _damageMagnifier;
            base.EndBuff();
        }
    }
}
