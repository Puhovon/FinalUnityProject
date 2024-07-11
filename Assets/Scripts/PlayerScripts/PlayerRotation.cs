using Fusion;
using UnityEngine;

namespace Assets.Scripts.PlayerScripts
{
    public class PlayerRotation : NetworkBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private Camera _camera;
        [SerializeField] NetworkCharacterController _cc;
        
        float rotationFactorPerFrame = 15.0f;
        public override void FixedUpdateNetwork()
        {
            
            if (!Object.HasInputAuthority)
                return;

            Vector2 mousePosition = _player.Input.Movement.MousePosition.ReadValue<Vector2>();
            Ray ray = _camera.ScreenPointToRay(new Vector3(mousePosition.x, mousePosition.y, 0));

            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            float rayDistance;

            if (groundPlane.Raycast(ray, out rayDistance))
            {
                Vector3 point = ray.GetPoint(rayDistance);
                Vector3 direction = (point - transform.position).normalized;

                Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
                print(lookRotation);
                _cc.transform.rotation =
                    Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
            }
        }
    }
}
