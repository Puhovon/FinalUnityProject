using System;
using UnityEngine;

namespace Assets.Scripts.Enemy.Configs
{

    [Serializable]
    public class DetectedConfig
    {
        [field: SerializeField] public float Speed;
        [field: SerializeField] public int TimeToLosePlayer;
    }
}