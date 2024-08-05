using Assets.Scripts.Abstractions;
using Fusion;
using UnityEngine;
using UnityEngine.AI;

#pragma warning disable CS0649 // Field is never assigned to, and will always have its default value

namespace Assets.Scripts.Enemy.StateMachine
{
    public class Enemy : NetworkBehaviour, IEntity
    {
        [Header("Links")]
        [SerializeField] private NavMeshAgent _navMeshAgent;

        [Header("Settings")]

        [SerializeField] private EnemyConfigs _config;
        [SerializeField] private EnemyType _type;
        [SerializeField] private EnemyView _view;

        private EnemyStateMachine _stateMachine;
        public Transform Transform => transform;

        public NavMeshAgent NavMeshAgent => _navMeshAgent;
        public EnemyView View => _view;
        public EnemyConfigs Config => _config;
        public Vector3 PatrollingPoint { get; set; }
        public override void Spawned()
        {
            base.Spawned();
            _view.Initialize();
            InitializeDeps();
            _navMeshAgent.speed = _config.PatrollingConfig.Speed;
        }

        private void InitializeDeps()
        {
            var data = new EnemyStateData(_config.PatrollingConfig.Speed,
                _config.PatrollingConfig.ChillTime);
            _stateMachine = new EnemyStateMachine(this,
                _config,
                data, _navMeshAgent);
        }

        public override void FixedUpdateNetwork()
        {
            _stateMachine.Update();
        }

        [Rpc(RpcSources.StateAuthority, RpcTargets.All)]
        private void RpcSetPatrollingPoint(Vector3 newPatrollingPoint)
        {
            PatrollingPoint = newPatrollingPoint;
            NavMeshAgent.destination = newPatrollingPoint;
        }

        public void InvokeRpcSetPatrollingPoint(Vector3 newPatrollingPoint)
        {
            RpcSetPatrollingPoint(newPatrollingPoint);
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