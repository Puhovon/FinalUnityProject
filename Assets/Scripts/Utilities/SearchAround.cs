using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Abstractions;
using UnityEngine;

namespace Utilities
{
    public class SearchAround : ICharacterFinder
    {
        private Transform _center;
        private float _radius;
        private string[] searchTag;

        public SearchAround(Transform center, float radius)
        {
            _center = center;
            _radius = radius;
        }
        
        public IEnumerable<IEntity> Find()
        {
            Collider[] colliders = Physics.OverlapSphere(_center.position, _radius);
            List<IEntity> findedCharacters = new List<IEntity>();

            foreach (var collider in colliders)
            {
                if (!collider.TryGetComponent(out IEntity entity))
                    continue;
                findedCharacters.Add(entity);
            }

            return findedCharacters;
        }
    }
}