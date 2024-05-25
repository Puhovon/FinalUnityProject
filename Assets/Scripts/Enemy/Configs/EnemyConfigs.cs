using Assets.Scripts.Enemy.Configs;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyConfig", menuName = "Configs/Enemy")]
public class EnemyConfigs : ScriptableObject
{
    [SerializeField] private PatrollingConfig _patrollingConfig;
    [SerializeField] private DetectedConfig _detectedConfig;
    [SerializeField] private AttackConfig _attackConfig;

    public PatrollingConfig PatrollingConfig => _patrollingConfig;
    public DetectedConfig DetectedConfig => _detectedConfig;
    public AttackConfig AttackConfig => _attackConfig;
}

public enum EnemyType
{
    HeavyMelly,
    LiteMelly,
    Range,
}