using Assets.Scripts.Abstractions;
using Assets.Scripts.Buffs.Fabric;
using Assets.Scripts.Utilities;
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

        [Networked] public Vector3 pointToMove { get; set; }
        
        [Header("Settings")]

        [SerializeField] private EnemyConfigs _config;
        [SerializeField] private EnemyView _view;
        [SerializeField] private EnemyDie _die;
        
        public Vector3 _currentTransfrom;
        
        private EnemyStateMachine _stateMachine;
        public Transform Transform => transform;

        public NavMeshAgent NavMeshAgent => _navMeshAgent;
        public EnemyView View => _view;
        public EnemyConfigs Config => _config;
        private bool _spawned;

        private void Awake()
        {
            InitializeDeps();
        }

        public override void Spawned()
        {
            _navMeshAgent.speed = _config.PatrollingConfig.Speed;
            _spawned = true;
            _die.Init(new BuffFactory(), _view);
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
            if(_spawned)
                _stateMachine.Update();
        }

        [Rpc(RpcSources.StateAuthority, RpcTargets.All)]
        private void RpcSetPatrollingPoint()
        {
            var point = RandomPointToMove.GetRandomPoint(Transform, Config.PatrollingConfig.MaxDistanceToMove,
                NavMeshAgent);
            pointToMove = point;
            NavMeshAgent.SetDestination(pointToMove);
            Transform.LookAt(pointToMove);
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

        public void InvokeRpcSetPatrollingPoint()
        {
            if(!HasStateAuthority)
                return;
            RpcSetPatrollingPoint();
        }
    }
}