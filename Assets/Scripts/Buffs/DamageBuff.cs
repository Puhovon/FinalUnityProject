using Assets.Scripts.Abstractions;
using Assets.Scripts.PlayerScripts;
using UnityEngine;

namespace Assets.Scripts.Buffs
{
    public class DamageBuff : Buff
    {
        [SerializeField] private Shooter _shooter;
        [SerializeField] private int _damageMagnifier;

        public override void StartBuff()
        {
            base.StartBuff();
            _shooter.DamageMagnifier += _damageMagnifier;
        }


        public override void EndBuff()
        {
            _shooter.DamageMagnifier -= _damageMagnifier;
            base.EndBuff();
        }
    }
}
