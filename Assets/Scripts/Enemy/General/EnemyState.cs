using Enemy.Melee;
using UnityEngine;
using Utilities;

namespace Enemy.General
{
    public class EnemyState : MonoBehaviour
    {
        [SerializeField] private float _radius;
        [SerializeField] private IMovable _movable;
        private IEnemyBehavior _behavior;
        private ICharacterFinder _finder;

        private void Start()
        {
            _finder = new SearchAround(transform, _radius);
            _behavior = new MoveToTarget(_movable, transform, new SearchAround(transform, _radius));
        }

        private void Update()
        {
        }
    }
}