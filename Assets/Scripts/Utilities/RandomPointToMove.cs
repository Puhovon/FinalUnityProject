using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Utilities
{
    public class RandomPointToMove
    {
        private Transform _center;
        private float _radius;
        private NavMeshAgent _agent;
        private NavMeshPath _path;
        private Vector3 _point;
        public RandomPointToMove(NavMeshAgent agent,Transform center, float radius)
        {
            _agent = agent;
            _center = center;
            _radius = radius;
            _path = new NavMeshPath();
        }

        public Vector3 GetRandomPoint()
        {
            bool isCorrectedPoint = false;
            while (!isCorrectedPoint)
            {
                NavMeshHit hit;
                NavMesh.SamplePosition(Random.insideUnitSphere * _radius + _center.position, out hit, _radius,
                    NavMesh.AllAreas);
                _point = hit.position;
                _agent.CalculatePath(_point, _path);
                if (_path.status == NavMeshPathStatus.PathComplete) isCorrectedPoint = true;
            }

            return _point;
        }
    }
}
