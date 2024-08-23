using Fusion;
using UnityEngine;

namespace Assets.Scripts.NetworkTest
{
    public struct NetworkInputData : INetworkInput
    {
        public Vector3 movement;
        public NetworkButtons buttons;
        public Vector2 lookRotation;
    }

    public enum MyButtons
    {
        Fire,
        Help,
    }
}
