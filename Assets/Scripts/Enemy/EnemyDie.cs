using Assets.Scripts.Buffs.Fabric;
using Assets.Scripts.Global;
using Fusion;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Enemy
{
    public class EnemyDie : NetworkBehaviour
    {
        [SerializeField] private Health _health;
        private BuffFactory _factory;

        public void Init(BuffFactory factory)
        {
             _health.Die += Die;
             _factory = factory;
             print("Init die");
        }
        
        private void Die()
        {
            print("Die");
            Rpc_SpawnBuff();
            var obj = transform.parent.GetComponent<NetworkObject>();
            _health.Die -= Die;
            Runner.Despawn(obj);
            print("Despawned");
        }

        [Rpc(RpcSources.StateAuthority, RpcTargets.All)]
        private void Rpc_SpawnBuff()
        {
            var index = Random.Range(0, _factory.GetBuffsCount());
            Runner.Spawn(_factory.GetRandomBuff(index), transform.position);
            print("Buff spawned");
        }
    }
}
