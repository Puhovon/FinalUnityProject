using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.PlayerScripts
{
    public class PlayerRotation : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private Camera _camera;
        float rotationFactorPerFrame = 15.0f;

        private void Update()
        {
            Vector2 mousePosition = _player.Input.Movement.MousePosition.ReadValue<Vector2>();
            Ray ray = _camera.ScreenPointToRay(new Vector3(mousePosition.x, mousePosition.y, 0));

            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            float rayDistance;

            if (groundPlane.Raycast(ray, out rayDistance))
            {
                Vector3 point = ray.GetPoint(rayDistance);
                Vector3 direction = (point - transform.position).normalized;

                Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
            }
        }
    }
}
