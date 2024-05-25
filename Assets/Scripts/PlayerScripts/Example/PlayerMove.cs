using UnityEngine;

namespace Assets.Scripts.PlayerScripts.Example
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] private PlayerInput input;
        [SerializeField] private CharacterController controller;
        [SerializeField] private float speed;
        [SerializeField] private PlayerView view;

        private Vector3 direction = Vector3.zero;

        private void Awake()
        {
            view.Initialize();
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            direction = new Vector3(input.direction.x,
                direction.y,
                input.direction.y);
            if (direction != Vector3.zero)
            {
                view.IdlingStop();
                view.RunningStart();
            }
            else
            {
                view.RunningStop();
                view.IdlingStart();
            }
            controller.Move(direction * speed * Time.deltaTime);
        }
    }
}