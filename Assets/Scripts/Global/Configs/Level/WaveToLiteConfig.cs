using System;
using UnityEngine;

namespace Assets.Scripts.Global.Configs
{
    [Serializable]
    public class WaveToLiteConfig
    {
        [field: SerializeField] public int StartCount;
        [field: SerializeField] public int WaveMagnifier;
    }
}