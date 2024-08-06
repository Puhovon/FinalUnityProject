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
        [SerializeField] private GameObject[] _abilities;
        private BuffFactory _factory;


        private void Start()
        {
            _health.Die += Die;
        }

        // [Inject]
        // public void Construct(BuffFactory factory)
        // {
        //     _factory = factory;
        // }

        private void Die()
        {
            var obj = transform.parent.GetComponent<NetworkObject>();
            _health.Die -= Die;
            Runner.Despawn(obj);
        }
    }
}
