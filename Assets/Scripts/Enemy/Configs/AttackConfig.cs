using System;
using UnityEngine;

namespace Assets.Scripts.Enemy.Configs
{
    [Serializable]
    public class AttackConfig
    {
        [field: SerializeField, Range(1, 10)] public int Damage;
        [field: SerializeField, Range(0.2f, 10)] public float TimeToNextAttack;
        [field: SerializeField] public float DistanceToAttack;
    }
}