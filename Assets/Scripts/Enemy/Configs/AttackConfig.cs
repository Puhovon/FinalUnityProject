using System;
using UnityEngine;

namespace Assets.Scripts.Enemy.Configs
{
    [Serializable]
    public class AttackConfig
    {
        [field: SerializeField] public float Damage;
        [field: SerializeField] public float TimeToNextAttack;
        [field: SerializeField] public float DistanceToAttack;
    }
}