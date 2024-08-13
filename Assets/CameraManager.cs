using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Camera _camera;

    public Camera GetCamera => _camera;
    public void SetTarget(Transform target) => _player = target;

    private void Update()
    {
        if(_player == null)
            return;
        var pos = _player.transform.position;
        transform.position = new Vector3(pos.x, 20, pos.z);
    }
}
