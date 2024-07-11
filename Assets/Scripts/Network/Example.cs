using System;
using System.Linq;
using System.Threading.Tasks;
using Fusion;
using Fusion.Sockets;
using UnityEngine;

public class Example : MonoBehaviour
{
    public NetworkRunner runnerPrefab;

    private NetworkRunner _runner;
    void Start()
    {
        _runner = Instantiate(runnerPrefab);
        _runner.name = "NetworkRunner";

        //var clientTask = InitializeNetworkRunner(_runner, GameMode.AutoHostOrClient, NetAddress.Any(),
        //    (SceneRef)SceneManager.GetActiveScene(), null);
    }

    protected virtual Task InitializeNetworkRunner(NetworkRunner runner, GameMode gameMode, NetAddress address,
        SceneRef scene, Action<NetworkRunner> initialized)
    {
        var sceneManager =
            runner.GetComponents(typeof(MonoBehaviour)).OfType<INetworkSceneManager>().FirstOrDefault() ??
            runner.gameObject.AddComponent<NetworkSceneManagerDefault>();

        runner.ProvideInput = true;

        return runner.StartGame(new StartGameArgs
        {
            GameMode = gameMode,
            Address = address,
            Scene = scene,
            SessionName = "TestRoom",
            SceneManager = sceneManager,
        });
    }

}
