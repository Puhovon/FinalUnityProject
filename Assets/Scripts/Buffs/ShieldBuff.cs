using UnityEngine;

namespace Assets.Scripts.Buffs
{
    public class ShieldBuff : Buff
    {
        [SerializeField] private int _damageReduction;

        public override void StartBuff() {
            base.StartBuff();
            Buffable.DamageReduction += _damageReduction;
        }

        public override void EndBuff()
        {
            Buffable.DamageReduction -= _damageReduction;
            if (Buffable.DamageReduction < 0)
            {
                Buffable.DamageReduction = 0;
            }
            base.EndBuff();
        }
    }
}
