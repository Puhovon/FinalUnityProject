using System.Collections;
using Assets.Scripts.Lobby;
using Fusion;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class LevelManager : NetworkSceneManagerDefault
    {
        [SerializeField] private FusionLauncher _launcher;
        protected override IEnumerator LoadSceneCoroutine(SceneRef sceneRef, NetworkLoadSceneParameters sceneParams)
        {
            GameManager.Instance.SetGameState(GameManager.GameState.Loading);
            _launcher.SetConnectionStatus(FusionLauncher.ConnectionStatus.Loading, "");
            yield return new WaitForSeconds(1f);
            yield return base.LoadSceneCoroutine(sceneRef, sceneParams);
            _launcher.SetConnectionStatus(FusionLauncher.ConnectionStatus.Loaded, "");
            yield return new WaitForSeconds(1f);
        }
    }
}