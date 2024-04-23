using Player.Configs;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player.StateMachine.States
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/Player")]
    public class PlayerConfig : ScriptableObject
    {
        [SerializeField] private RunningStateConfig _runningStateConfig;
        [SerializeField] private WalkingStateConfig _walkingStateConfig;
        [SerializeField] private ReloadingStateConfig _reloadingStateConfig;
        
        public RunningStateConfig RunningStateConfig => _runningStateConfig;
        public WalkingStateConfig WalkingStateConfig => _walkingStateConfig;
        public ReloadingStateConfig ReloadingStateConfig => _reloadingStateConfig;
    }
}