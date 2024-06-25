using System;
using System.Collections;
using Assets.Scripts.Global;
using Assets.Scripts.Global.Configs;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Enemy.EnemySpawner
{
    public class EnemySpawner : MonoBehaviour
    {
        [Header("Level Config")]
        [SerializeField] private LevelConfig _levelConfig;
        [SerializeField] private Wave _wave;
        [SerializeField] private Transform spawnPoint;

        private int _currentWaveRange;
        private int _currentWaveHeavy;
        private int _currentWaveLite;

        private EnemyFactory _factory;

        [Inject]
        public void Construct(EnemyFactory factory)
        {
            _factory = factory;
        }

        private void Awake()
        {
            _currentWaveHeavy = _levelConfig.HeavyWaveConfig.StartCount;
            _currentWaveLite = _levelConfig.LiteWaveConfig.StartCount;
            _currentWaveRange = _levelConfig.RangeWaveConfig.StartCount;
            _wave.SpawnNewWave += Spawn;
            print(_factory is null);
        }

        private void Spawn()
        {
            StartCoroutine(SpawnEnemyByType(_currentWaveHeavy, EnemyType.HeavyMelly, SpawnHeavy));
            //StartCoroutine(SpawnEnemyByType(_currentWaveRange, EnemyType.Range, SpawnRange));
            //StartCoroutine(SpawnEnemyByType(_currentWaveHeavy, EnemyType.HeavyMelly, SpawnRange));
        }

        private IEnumerator SpawnEnemyByType(int currentLength,EnemyType type, Action a)
        {
            Debug.Log(_currentWaveRange);
            for (int i = 0; i < currentLength; i++)
            {
                _factory.Spawn(type, transform);
                yield return new WaitForSeconds(0.5f);
            }

            a();
        }

        private void SpawnRange() {
            _currentWaveRange += _levelConfig.RangeWaveConfig.WaveMagnifier;
        }        
        private void SpawnHeavy()
        {
            _currentWaveHeavy += _levelConfig.HeavyWaveConfig.WaveMagnifier;
        }
        private void SpawnLite()
        {
            _currentWaveLite += _levelConfig.LiteWaveConfig.WaveMagnifier;
        }
    }
}
