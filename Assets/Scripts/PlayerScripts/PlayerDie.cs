using Assets.Scripts.Global;
using Fusion;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.PlayerScripts
{
    public class PlayerDie : NetworkBehaviour
    {
        [SerializeField] private PlayerView _view;
        [SerializeField] private Health _health;
        private NetworkRunner _runner;
        
        private void Start()
        {
            _health.Die += Die;
            
        }

        private void Die()
        {
            var runner = GameObject.FindGameObjectWithTag("Runner");
            Destroy(runner);
            SceneManager.LoadScene("Achievements");
        }
    }
}
