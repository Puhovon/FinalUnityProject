using Assets.Scripts.Abstractions;
using Assets.Scripts.PlayerScripts;
using UnityEngine;
using UnityEngine.AI;
#pragma warning disable CS0649 // Field is never assigned to, and will always have its default value

namespace Assets.Scripts.Enemy.StateMachine
{
    public class Enemy : MonoBehaviour, IEntity
    {
        [Header("Links")]

        [SerializeField] private Transform _playerTransform;
        [SerializeField] private NavMeshAgent _navMeshAgent;
        
        [Header("Settings")]

        [SerializeField] private EnemyConfigs _config;
        [SerializeField] private EnemyType _type;
        [SerializeField] private EnemyView _view;
        [SerializeField] private Transform[] _patrollingPoints;

        private EnemyStateMachine _stateMachine;

        public NavMeshAgent NavMeshAgent => _navMeshAgent;
        public EnemyView View => _view;
        public EnemyConfigs Config => _config;

        private void Awake()
        {
            _view.Initialize();
            InitializeDeps();
            
            _navMeshAgent.speed = _config.PatrollingConfig.Speed;
        }

        private void InitializeDeps()
        {
            var data = new EnemyStateData(_config.PatrollingConfig.Speed,
                _config.PatrollingConfig.ChillTime,
                _patrollingPoints);

            _stateMachine = new EnemyStateMachine(this,
                new Shooter(),
                _config,
                _playerTransform,
                data);
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
        }

        public Transform Transform { get; }
    }
}