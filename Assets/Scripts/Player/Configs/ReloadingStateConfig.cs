using System;
using UnityEngine;

namespace Player.Configs
{
    [Serializable]
    public class ReloadingStateConfig
    {
        [field: SerializeField, Range(0, 5)] public float TimeToReload { get; private set; }
    }
}