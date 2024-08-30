
using UnityEngine;

namespace Assets.Scripts.Buffs
{
    public class HealthBuff : Buff
    {
        [SerializeField] private int _healthToAdd;

        public override void StartBuff()
        {
            base.StartBuff();
            Buffable.HealthPoints += _healthToAdd;
        }
    }
}
