using System;
using UnityEngine;

namespace Player.Configs
{
    [Serializable]
    public class WalkingStateConfig
    {
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField, Range(0, 100)] public int MaxAmmo { get; private set; }
        [field: SerializeField, Range(0, 100)] public int Ammo { get; set; }
    }
}