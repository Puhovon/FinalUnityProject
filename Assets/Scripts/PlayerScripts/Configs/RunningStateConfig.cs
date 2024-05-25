using System;
using UnityEngine;

namespace Assets.Scripts.PlayerScripts.Configs
{
    [Serializable]
    public class RunningStateConfig
    {
        [field: SerializeField, Range(0, 10)] public float Speed { get; private set; }
    }
}