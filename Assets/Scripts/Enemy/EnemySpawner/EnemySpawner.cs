using System;
using System.Collections;
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

        private int _currentWaveRange;
        [SerializeField] private int _currentWaveHeavy;
        private int _currentWaveLite;

        private EnemyFactory _factory;

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
            
            _currentWaveHeavy = _levelConfig.HeavyWaveConfig.StartCount;
            _currentWaveLite = _levelConfig.LiteWaveConfig.StartCount;
            _currentWaveRange = _levelConfig.RangeWaveConfig.StartCount;
            _wave.SpawnNewWave += Spawn;
        }

        private void Spawn()
        {
            if (HasStateAuthority)
            {
                StartCoroutine(SpawnEnemyByType(_currentWaveHeavy, EnemyType.HeavyMelly, IncrementHeavyCount));
                //StartCoroutine(SpawnEnemyByType(_currentWaveLite, EnemyType.HeavyMelly, IncrementLiteCount));
                //StartCoroutine(SpawnEnemyByType(_currentWaveRange, EnemyType.Range, IncrementRangeCount));
            }
        }

        private IEnumerator SpawnEnemyByType(int currentLength, EnemyType type, Action incrementCount)
        {
            for (int i = 0; i < currentLength; i++)
            {
                RpcSpawnEnemy(type);
                yield return new WaitForSeconds(0.5f);
            }
            incrementCount();
        }

        [Rpc(RpcSources.StateAuthority, RpcTargets.All)]
        private void RpcSpawnEnemy(EnemyType type)
        {
            var enemy = _factory.Spawn(type, spawnPoint);
            Runner.Spawn(enemy, spawnPoint.position, Quaternion.identity);
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
