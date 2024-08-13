using Assets.Scripts.Buffs.Fabric;
using Assets.Scripts.Global;
using Fusion;
using UnityEngine;
using Zenject;

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
            var obj = transform.parent.GetComponent<NetworkObject>();
            _factory.GetRandomBuff(transform.position, this);
            _health.Die -= Die;
            Runner.Despawn(obj);
        }
    }
}
