using UnityEngine;

namespace Assets.Scripts.Enemy.EnemySpawner
{
    public class EnemySpawner : MonoBehaviour
    {
        private EnemyFactory factory;

        [Header("Configs")]
        [SerializeField] private EnemyConfigs _heavyMelly;
        [SerializeField] private EnemyConfigs _smallMelly;
        [SerializeField] private EnemyConfigs _range;

        private void Awake()
        {
            factory = new EnemyFactory(_heavyMelly, _smallMelly, _range);
        }
    }
}
