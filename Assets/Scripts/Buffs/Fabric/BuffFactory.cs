using System.IO;
using Fusion;
using UnityEngine;

namespace Assets.Scripts.Buffs.Fabric
{
    public class BuffFactory
    {
        private const string BuffsPath = "Buffs";

        private GameObject[] _buffs;

        public BuffFactory()
        {
            Load();
        }
        
        public NetworkObject GetRandomBuff(int index)
        {
            return _buffs[index].GetComponent<NetworkObject>();
        }

        public int GetBuffsCount() => _buffs.Length;
        
        private void Load()
        {
            _buffs = Resources.LoadAll<GameObject>(Path.Combine(BuffsPath));
            Debug.Log("Load buffs");
        }
    }
}
