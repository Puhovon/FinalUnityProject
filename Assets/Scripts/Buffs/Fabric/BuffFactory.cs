using System;
using System.IO;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Buffs.Fabric
{
    public class BuffFactory
    {
        private const string BuffsPath = "Buffs";

        private IInstantiator _instantiator;
        private GameObject[] _buffs;

        public BuffFactory(IInstantiator instantiator)
        {
            _instantiator = instantiator;
            Load();
        }
        
        public void GetRandomBuff( Vector3 pos)
        {
            var index = Random.Range(0, _buffs.Length);
            _instantiator.InstantiatePrefab(_buffs[index], pos, Quaternion.identity, null);
        }

        private void Load()
        {
            _buffs = Resources.LoadAll<GameObject>(Path.Combine(BuffsPath));
            Debug.Log(_buffs.Length);
        }
    }
}
