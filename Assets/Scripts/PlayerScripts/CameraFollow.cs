using Fusion;
using UnityEngine;

public class CameraFollow : NetworkBehaviour
{
    [SerializeField] private Transform player;

    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - player.position;
    }

    public override void FixedUpdateNetwork()
    {
        if (!Object.HasInputAuthority)
            return;
        transform.position = player.position + offset;
    }
}
