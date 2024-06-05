using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.PlayerScripts
{
    public class PlayerRotation : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private Camera _camera;
        float rotationFactorPerFrame = 15.0f;

        private void Update()
        {

            Vector2 mousePosition = (_player.Input.Movement.MousePosition.ReadValue<Vector2>());
            transform.LookAt(new Vector3(mousePosition.x, 0, mousePosition.y));
        }
    }
}
