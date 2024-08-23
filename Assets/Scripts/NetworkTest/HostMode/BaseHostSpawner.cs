using System.Collections.Generic;
using Fusion;
using UnityEngine;

public class BaseHostSpawner : NetworkBehaviour, IPlayerJoined, IPlayerLeft
{
    private NetworkRunner _runner;
    [SerializeField] private NetworkPrefabRef _playerPrefab;
    private Dictionary<PlayerRef, NetworkObject> _spawnedCharacters = new Dictionary<PlayerRef, NetworkObject>();

    public int PlayerCount => _spawnedCharacters.Count;
    
    // public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    // {
    //     if (runner.IsServer)
    //     {
    //         Vector3 spawnPosition = new Vector3((player.RawEncoded % runner.Config.Simulation.PlayerCount) * 3, 1, 0);
    //         NetworkObject networkPlayerObject = runner.Spawn(_playerPrefab, spawnPosition, Quaternion.identity, player);
    //         _spawnedCharacters.Add(player, networkPlayerObject);
    //     }
    // }
    //
    // public void OnInput(NetworkRunner runner, NetworkInput input)
    // {
    //     
    // }
    //
    // public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
    // {
    //     if (_spawnedCharacters.TryGetValue(player, out NetworkObject networkObject))
    //     {
    //         runner.Despawn(networkObject);
    //         _spawnedCharacters.Remove(player);
    //     }
    // }
    //
    
    public void PlayerJoined(PlayerRef player)
    {
        Vector3 spawnPosition = new Vector3((player.RawEncoded % Runner.Config.Simulation.PlayerCount) * 3, 1, 0);
        NetworkObject networkPlayerObject = Runner.Spawn(_playerPrefab, spawnPosition, Quaternion.identity, player);
        _spawnedCharacters.Add(player, networkPlayerObject);
        Runner.SetPlayerObject(player, networkPlayerObject);
    }

    public void PlayerLeft(PlayerRef player)
    {
        if (Runner.TryGetPlayerObject(player, out var spaceshipNetworkObject))
        {
            Runner.Despawn(spaceshipNetworkObject);
        }

        Runner.SetPlayerObject(player, null);
    }
}
