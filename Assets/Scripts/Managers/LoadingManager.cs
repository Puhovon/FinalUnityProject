using Fusion;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Managers
{
    public class LoadingManager : MonoBehaviour
    {
        public static LoadingManager Instance;
        private int _leveleIndex;

        public void LoadLevel(NetworkRunner runner)
        {
            _leveleIndex = 1;
            string scenePath = System.IO.Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(_leveleIndex));
            runner.LoadScene(scenePath);
        }

        public void LoadMainMenu(NetworkRunner runner)
        {
            _leveleIndex = 0;
            string scenePath = System.IO.Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(_leveleIndex));
            runner.LoadScene(scenePath);
        }
    }
}