using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Utilities
{
    public static class RandomPointToMove
    {
        public static Vector3 GetRandomPoint(Transform _center, float _radius, NavMeshAgent _agent)
        {
            var _path = new NavMeshPath();
            Vector3 _point = Vector3.zero;
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
