using Fusion;
using UnityEngine;

public class CameraFollow : NetworkBehaviour
{
    [SerializeField] private Transform _player;

    [SerializeField] private Vector3 offset;

    public void Init(Transform player)
    {
        if(!HasInputAuthority)
            return;
        _player = player;
        offset = new Vector3(_player.position.x, 20, _player.position.z);
    }

    public override void FixedUpdateNetwork()
    {
        if (!HasInputAuthority || _player == null)
            return;
        transform.position = _player.position + offset;
    }
}
