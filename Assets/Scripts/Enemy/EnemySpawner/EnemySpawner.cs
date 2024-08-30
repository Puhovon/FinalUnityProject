using Assets.Scripts.Buffs.Fabric;
using Assets.Scripts.Global;
using Assets.Scripts.Global.Configs;
using Fusion;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Enemy.EnemySpawner
{
    public class EnemySpawner : NetworkBehaviour
    {
        [Header("Level Config")]
        [SerializeField] private LevelConfig _levelConfig;
        [SerializeField] private Wave _wave;
        [SerializeField] private Transform spawnPoint;

        [SerializeField] private int _currentWaveRange;
        [SerializeField] private int _currentWaveHeavy;
        [SerializeField] private int _currentWaveLite;
        [SerializeField] private int _currentLength;
        private EnemyFactory _factory;
        private BuffFactory _factoryBuff;
        
        [Inject]
        public void Construct(EnemyFactory factory)
        {
            _factory = factory;
        }
        
        private static EnemySpawner _instance;
        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }

            _factoryBuff = new BuffFactory();
            _currentLength = 2;
            _currentWaveHeavy = _levelConfig.HeavyWaveConfig.StartCount;
            _currentWaveLite = _levelConfig.LiteWaveConfig.StartCount;
            _currentWaveRange = _levelConfig.RangeWaveConfig.StartCount;
            _wave.SpawnNewWave += Spawn;
        }

        public void Spawn()
        {
            if (Runner.IsServer)
            {
                SpawnEnemyByType(_currentLength);
            }
        }

        private void SpawnEnemyByType(int currentLength)
        {
            _currentLength = currentLength;
            print(currentLength);
            for (int i = 0; i < currentLength; i++)
            {
                SpawnEnemy(EnemyType.HeavyMelly);
                SpawnEnemy(EnemyType.LiteMelly);
                SpawnEnemy(EnemyType.Range);
            }

            _currentLength += 1;
        }

        private void SpawnEnemy(EnemyType type)
        {
            var prefab = _factory.Spawn(type, spawnPoint, this);
            if(Runner.IsServer)
            {
                Runner.Spawn(prefab);
                // prefab.GetComponentInChildren<EnemyDie>().Init(_factoryBuff);
            }
        }

        private void IncrementRangeCount()
        {
            _currentWaveRange += _levelConfig.RangeWaveConfig.WaveMagnifier;
        }
        private void IncrementHeavyCount()
        {
            _currentWaveHeavy += _levelConfig.HeavyWaveConfig.WaveMagnifier;
        }
        private void IncrementLiteCount()
        {
            _currentWaveLite += _levelConfig.LiteWaveConfig.WaveMagnifier;
        }
    }
}
