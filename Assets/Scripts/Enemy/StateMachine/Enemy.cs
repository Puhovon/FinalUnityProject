using Assets.Scripts.PlayerScripts;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Enemy.StateMachine
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private Transform _playerTransform;
        [SerializeField]private EnemyConfigs _config;
        private CharacterController _characterController;
        private NavMeshAgent _navMeshAgent;
        private EnemyView _view;
        private EnemyStateMachine _stateMachine;

        public CharacterController СharacterController => _characterController;
        public NavMeshAgent NavMeshAgent => _navMeshAgent;
        public EnemyView View => _view;
        public EnemyConfigs Config => _config;

        private void Awake()
        {
            _stateMachine = new EnemyStateMachine(this, new Shooter(), _config, _playerTransform);
        }

        private void Update()
        {
            _stateMachine.Update();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(transform.position, _config.PatrollingConfig.DistanceToDetect);
        }
    }
}