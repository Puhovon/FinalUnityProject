using Assets.Scripts.Abstractions;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

#pragma warning disable CS0649 // Field is never assigned to, and will always have its default value

namespace Assets.Scripts.Enemy.StateMachine
{
    public class Enemy : MonoBehaviour, IEntity
    {
        [Header("Links")]
        [SerializeField] private NavMeshAgent _navMeshAgent;

        [Header("Settings")]

        [SerializeField] private EnemyConfigs _config;
        [SerializeField] private EnemyType _type;
        [SerializeField] private EnemyView _view;

        private EnemyStateMachine _stateMachine;
        private Transform _playerTransform;
        public Transform Transform => transform;

        public NavMeshAgent NavMeshAgent => _navMeshAgent;
        public EnemyView View => _view;
        public EnemyConfigs Config => _config;

        private void Awake()
        {
            _view.Initialize();
            InitializeDeps();
            _navMeshAgent.speed = _config.PatrollingConfig.Speed;
        }

        [Inject]
        public void Constructor(Transform playerTransform)
        {
            _playerTransform = playerTransform;
        }

        private void InitializeDeps()
        {
            var data = new EnemyStateData(_config.PatrollingConfig.Speed,
                _config.PatrollingConfig.ChillTime);
            _stateMachine = new EnemyStateMachine(this,
                _config,
                data, _navMeshAgent);
        }

        private void Update()
        {
            _stateMachine.Update();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(transform.position, _config.PatrollingConfig.DistanceToDetect);

            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position, _config.AttackConfig.DistanceToAttack);

            Gizmos.color = Color.green;
            Gizmos.DrawSphere(transform.position, _config.PatrollingConfig.MaxDistanceToMove);
        }

    }
}