using System.IO;
using Fusion;
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

        public BuffFactory()
        {
            Load();
        }

        public void GetRandomBuff(Vector3 pos, NetworkBehaviour _behaviour)
        {
            var index = Random.Range(0, _buffs.Length-1);
            Debug.Log(_buffs[index].name);
            _behaviour.Runner.Spawn(_buffs[index], _behaviour.transform.position);
        }

        private void Load()
        {
            _buffs = Resources.LoadAll<GameObject>(Path.Combine(BuffsPath));
            Debug.Log(_buffs.Length);
        }
    }
}
