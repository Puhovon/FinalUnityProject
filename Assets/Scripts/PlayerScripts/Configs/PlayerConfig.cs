using UnityEngine;

namespace Assets.Scripts.PlayerScripts.Configs
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/Player")]
    public class PlayerConfig : ScriptableObject
    {
        [SerializeField] private RunningStateConfig _runningStateConfig;
        [SerializeField] private WalkingStateConfig _walkingStateConfig;
        [SerializeField] private ReloadingStateConfig _reloadingStateConfig;
        [field: SerializeField] public float distance;
        [field: SerializeField] public int damage;

        public RunningStateConfig RunningStateConfig => _runningStateConfig;
        public WalkingStateConfig WalkingStateConfig => _walkingStateConfig;
        public ReloadingStateConfig ReloadingStateConfig => _reloadingStateConfig;
    }
}