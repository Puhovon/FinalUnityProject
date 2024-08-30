using System.Collections;
using Assets.Scripts.Buffs.Fabric;
using Assets.Scripts.Enemy.StateMachine;
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
        private EnemyView _view;
        
        public void Init(BuffFactory factory, EnemyView view)
        {
            _view = view;
             _health.Die += Die;
             _factory = factory;
             print("Init die");
        }
        
        private void Die()
        {
            StartCoroutine(DieCor());
            _view.Dying();
            print("Despawned");
        }

        private IEnumerator DieCor()
        {
            yield return new WaitForSeconds(2);
            var obj = transform.GetComponent<NetworkObject>();
            Rpc_SpawnBuff();
            _health.Die -= Die;
            Runner.Despawn(obj);
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
