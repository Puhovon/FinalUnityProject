using Assets.Scripts.NetworkTest;
using Assets.Scripts.PlayerScripts.Configs;
using Fusion;
using UnityEngine;

public class PlayerMove : NetworkBehaviour
{
    [SerializeField] private NetworkCharacterController _cc;
    [SerializeField] private int speed;

    
    
    public void Init(PlayerConfig config)
    {
        
    }

    public override void FixedUpdateNetwork()
    {
        if(Runner.TryGetInputForPlayer<NetworkInputData>(Object.InputAuthority, out NetworkInputData data))
        {
            _cc.Move(data.movement * speed * Runner.DeltaTime);
        }
    }
}
