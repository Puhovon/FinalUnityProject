using System;
using UnityEngine;

namespace Assets.Scripts.Global.Configs
{
    [Serializable]
    public class WaveToHeavyConfig
    {
        [field: SerializeField] public int StartCount;
        [field: SerializeField] public int WaveMagnifier;
    }
}