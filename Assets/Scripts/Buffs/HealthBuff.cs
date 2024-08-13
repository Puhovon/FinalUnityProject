
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

        public override void EndBuff()
        {
            if (Buffable.HealthPoints - _healthToAdd <= 0)
            {
                Buffable.HealthPoints = 1;
            } else 
                Buffable.HealthPoints -= _healthToAdd;
            base.EndBuff();
        }
    }
}
