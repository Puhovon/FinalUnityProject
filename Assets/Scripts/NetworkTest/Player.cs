using Fusion;

namespace Assets.Scripts.NetworkTest
{
    internal class Player : NetworkBehaviour
    {
        private NetworkCharacterController _cc;

        private void Awake()
        {
            _cc = GetComponent<NetworkCharacterController>();
        }

        public override void FixedUpdateNetwork()
        {
            if (GetInput(out NetworkInputData data))
            {
                print($"input is {data.direction}");
                data.direction.Normalize();
                _cc.Move(5 * data.direction * Runner.DeltaTime);
            }
        }
    }
}
