using UnityEngine;

namespace Assets.Scripts.NetworkTest.HostMode
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform _player;
        private void Update()
        {
           if(_player == null)
               return;
           var pos = _player.transform.position;
           transform.position = new Vector3(pos.x, 20, pos.z);
        }

        public void SetTarget(Transform target) => _player = target;
    }
}