using System;
using UnityEngine;

namespace Assets.Scripts.Enemy.Configs
{
    [Serializable]
    public class PatrollingConfig
    {
        [field: SerializeField] public float Speed;
        [field: SerializeField] public float DistanceToDetect;
        [field: SerializeField] public float ChillTime;
        [field: SerializeField] public float MaxDistanceToMove;
    }
}
