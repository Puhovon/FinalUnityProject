using UnityEngine;

namespace Enemy.Melee
{
    public class MeleeEnemy : MonoBehaviour, IMovable
    {
        [SerializeField] private float speed;

        private IMover _mover;
        
        public Transform Transform => transform;
        
        public float Speed => speed;
        
        private void Update()
        {
            _mover.Update();
        }
        
        public void SetMover(IMover mover)
        {
            _mover?.StopMove();
            _mover = mover;
            _mover.StartMove();
        }
    }
}