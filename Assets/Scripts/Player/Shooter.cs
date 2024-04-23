using System;
using UnityEngine;

namespace Player
{
    public class Shooter : MonoBehaviour
    {
        public Action shoot;
        public Action reload;

        public void Initialize()
        {
            shoot += () => Debug.Log("Shoot");
        }
    }
}