using Assets.Scripts.Global;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Enemy
{
    public class EnemyDie : MonoBehaviour
    {
        [SerializeField] private Health _health;
        [SerializeField] private GameObject[] _abilities;
        
        private void Start()
        {
            _health.Die += Die;
        }

        private void Die()
        {

        }
    }
}
