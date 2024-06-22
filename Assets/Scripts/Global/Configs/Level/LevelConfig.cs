using UnityEngine;

namespace Assets.Scripts.Global.Configs
{
    [CreateAssetMenu(menuName = "Configs/Game", fileName = "LevelConfig")]
    public class LevelConfig : ScriptableObject
    {
        [SerializeField] private WaveToRangeConfig _range;
        [SerializeField] private WaveToHeavyConfig _heavy;
        [SerializeField] private WaveToLiteConfig _lite;

        public WaveToRangeConfig RangeWaveConfig => _range;
        public WaveToHeavyConfig HeavyWaveConfig => _heavy;
        public WaveToLiteConfig LiteWaveConfig => _lite;
    }
}
