using System;
using UnityEngine;

namespace Assets.Scripts.PlayerScripts.Configs
{
    [Serializable]
    public class ReloadingStateConfig
    {
        [field: SerializeField, Range(0, 5)] public float TimeToReload { get; private set; }
    }
}