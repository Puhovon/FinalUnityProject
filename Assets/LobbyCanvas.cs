using Assets.Scripts.Lobby;
using Assets.Scripts.Managers;
using Fusion;
using TMPro;
using UnityEngine;

public class LobbyCanvas : MonoBehaviour
{
    [SerializeField] private TMP_InputField _room;
    
    [SerializeField] private FusionLauncher _launcher;
    [SerializeField] private LevelManager _sceneLoader;
    
    private GameMode _gameMode;

    public void Launch()
    {
        if (BaseHostSpawner.LocalRunner.IsClient) return;
        _launcher.Launch(_gameMode, _room.text, _sceneLoader);
        LoadingManager.Instance.LoadLevel(BaseHostSpawner.LocalRunner);
    }

    public void SetGameMode(int gameMode)
    {
        _gameMode = (GameMode)gameMode;
    }
}
