using Fusion;
using TMPro;
using UnityEngine;

public class LobbyCanvas : MonoBehaviour
{
    [SerializeField] private TMP_InputField _room;
    [SerializeField] private NetworkRunner _networkRunnerPrefab = null;
    [SerializeField] private string _gameSceneName;
    
    private GameMode _gameMode;
    private NetworkRunner _runnerInstance = null;
    
    public void StartHost()
    {
        StartGame(GameMode.AutoHostOrClient, _room.text, _gameSceneName);
    }

    public void StartClient()
    {
        StartGame(GameMode.Client, _room.text, _gameSceneName);
    }

    public void StartSingle()
    {
        StartGame(GameMode.Single, _room.text, _gameSceneName);
    }
    
    private async void StartGame(GameMode mode, string roomName, string sceneName)
    {
        _runnerInstance = FindObjectOfType<NetworkRunner>();
        if (_runnerInstance == null)
        {
            _runnerInstance = Instantiate(_networkRunnerPrefab);
        }

        // Let the Fusion Runner know that we will be providing user input
        _runnerInstance.ProvideInput = true;

        var startGameArgs = new StartGameArgs()
        {
            GameMode = mode,
            SessionName = roomName,
        };

        await _runnerInstance.StartGame(startGameArgs);

        if (_runnerInstance.IsServer)
        {
            _runnerInstance.LoadScene(sceneName);
        }
    }
}
