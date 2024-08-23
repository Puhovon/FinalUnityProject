using Fusion;
using UnityEngine;

namespace Assets.Scripts.Lobby
{
    public class FusionLauncher : MonoBehaviour
    {
        private ConnectionStatus _status;
        private NetworkRunner _runner;
        public enum ConnectionStatus
        {
            Disconnected,
            Connecting,
            Loading,
            Loaded
        }
        
        public async void Launch(GameMode mode, string room,
            INetworkSceneManager sceneLoader)
        {
            SetConnectionStatus(ConnectionStatus.Connecting, "");

            if (_runner == null)
                _runner = gameObject.AddComponent<NetworkRunner>();
            _runner.name = name;
            _runner.ProvideInput = mode != Fusion.GameMode.Server;
            await _runner.StartGame(new StartGameArgs()
            {
                GameMode = mode,
                SessionName = room,
                SceneManager = sceneLoader
            });
        }

        public void SetConnectionStatus(ConnectionStatus status, string message)
        {
            _status = status;
        }
    }
}