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

        private void Start()
        {
            _health.Die += Die;
             _factory = new BuffFactory();
        }
        
        private void Die()
        {
            Rpc_SpawnBuff();
            var obj = transform.parent.GetComponent<NetworkObject>();
            _health.Die -= Die;
            Runner.Despawn(obj);
        }

        [Rpc(RpcSources.StateAuthority, RpcTargets.All)]
        private void Rpc_SpawnBuff()
        {
            var index = Random.Range(0, _factory.GetBuffsCount());
            Runner.Spawn(_factory.GetRandomBuff(index), transform.position);
        }
    }
}
