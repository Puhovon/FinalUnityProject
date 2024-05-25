using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.PlayerScripts.Example
{
    public class PlayerInput : MonoBehaviour, MainInputActions.IMovementActions
    {
        public Vector2 direction; 
        private MainInputActions input;

        private void Awake()
        {
            input = new MainInputActions();
            input.Movement.SetCallbacks(this);
        }

        private void OnEnable()
        {
            input.Enable();
        }

        private void OnDisable()
        {
            input.Disable();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            direction = context.ReadValue<Vector2>();
        }

        public void OnShoot(InputAction.CallbackContext context)
        {
            throw new NotImplementedException();
        }
    }
}
