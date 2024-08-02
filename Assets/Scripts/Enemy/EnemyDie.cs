using Assets.Scripts.Buffs.Fabric;
using Assets.Scripts.Global;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Enemy
{
    public class EnemyDie : MonoBehaviour
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
            _health.Die -= Die;
            Destroy(gameObject);
        }
    }
}
