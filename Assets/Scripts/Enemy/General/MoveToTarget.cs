using System;
using UnityEngine;
using Utilities;

namespace Enemy.General
{
    public class MoveToTarget : IEnemyBehavior, IMover
    {
        public Action FindCharacter;
        // Func<List<IEnemyBehavior>> 
        private IMovable _movable;
        private Transform _transform;

        private bool _isMoving;

        public MoveToTarget(IMovable movable, Transform transform, ICharacterFinder finder)
        {
            _movable = movable;
            _transform = transform;
            // _finder = finder;
        }


        public void StartMove() => _isMoving = true;

        public void StopMove() => _isMoving = false;

        public void Update()
        {
            if (_isMoving == false) 
                return;
            
            
        }

        public void Action()
        {
            Update();
            // List<IEntity> entities = new List<IEntity>(_finder.Find());
            // if(entities.Count < 0) 
            //     return;
            // StopMove();
            FindCharacter?.Invoke();
        }
    }
}