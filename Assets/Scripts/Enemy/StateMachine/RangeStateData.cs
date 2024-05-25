using System;

namespace Assets.Scripts.Enemy.StateMachine
{
    internal class RangeStateData : EnemyStateData
    {
        private int _ammo;
        private int _maxAmmo;

        public int MaxAmmo => _maxAmmo;

        public int Ammo
        {
            get => _ammo;
            set
            {
                if (value < 0 || value > _maxAmmo)
                    throw new ArgumentOutOfRangeException("invalid ammo count");
                _ammo = value;
            }
        }

    }
}
