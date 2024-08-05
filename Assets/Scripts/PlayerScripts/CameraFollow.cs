using Fusion;
using UnityEngine;

public class CameraFollow : NetworkBehaviour
{
    [SerializeField] private Transform player;

    [SerializeField]private Vector3 offset = new Vector3(0,10,0);

    

    public override void FixedUpdateNetwork()
    {
        if (!HasStateAuthority)
            return;
        transform.position = player.position + offset;
    }
}
