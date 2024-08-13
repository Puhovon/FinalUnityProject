using Assets.Scripts.NetworkTest;
using Fusion;
using UnityEngine;

namespace Assets.Scripts.PlayerScripts
{
    public class PlayerRotation : NetworkBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private CameraManager _cameraManager;
        float rotationFactorPerFrame = 15.0f;

        public override void Spawned()
        {
            if (HasInputAuthority)
            {
                _cameraManager = FindObjectOfType<CameraManager>();
                _cameraManager.SetTarget(transform);
                _camera = _cameraManager.GetCamera;

            }
            Debug.LogError(_camera);
        }

        public override void FixedUpdateNetwork()
        {
            if(_camera == null)
            {
                if(!HasInputAuthority)
                    return;
                _cameraManager = FindObjectOfType<CameraManager>();
                _cameraManager.SetTarget(transform);
                _camera = _cameraManager.GetCamera;
            }
            if(Runner.TryGetInputForPlayer<NetworkInputData>(Object.InputAuthority, out NetworkInputData data) && _camera != null)
            {
                CalculateRotation(data);
            }
        }

        private void CalculateRotation(NetworkInputData data)
        {
            Ray ray = _camera.ScreenPointToRay(new Vector3(data.lookRotation.x, data.lookRotation.y, 0));

            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            float rayDistance;

            if (groundPlane.Raycast(ray, out rayDistance))
            {
                Vector3 point = ray.GetPoint(rayDistance);
                Vector3 direction = (point - transform.position).normalized;

                RpcRotatePlayer(direction);
            }
        }

        [Rpc(RpcSources.StateAuthority, RpcTargets.All)]
        private void RpcRotatePlayer(Vector3 direction)
        {
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = lookRotation;
        }
    }
}
