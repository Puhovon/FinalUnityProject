using Assets.Scripts.Abstractions;
using Assets.Scripts.PlayerScripts.Configs;
using Assets.Scripts.PlayerScripts.StateMachine;
using Fusion;
using UnityEngine;

namespace Assets.Scripts.PlayerScripts
{
    public class Player : NetworkBehaviour, IEntity
    {
        [SerializeField] private PlayerConfig _config;
        [SerializeField] private PlayerView _view;
        [SerializeField] private Shooter _shooter;
        
        [Networked] public NetworkButtons ButtonsPrevious { get; set; }
        
        private PlayerStateMachine _stateMachine;
        private NetworkCharacterController _controller;

        public NetworkCharacterController CharacterController => _controller;
        public PlayerConfig Config => _config;
        
        public PlayerView View => _view;

        public Transform Transform => transform;


        public override void Spawned()
        {
            _view.Initialize();
            _shooter.Initialize();
            _controller = GetComponent<NetworkCharacterController>();
            _stateMachine = new PlayerStateMachine(this, _shooter, _config);
        }
        public override void FixedUpdateNetwork()
        {
            if (HasStateAuthority)
            {
                _stateMachine.HandleInput();
            }
            _stateMachine.Update();
        }
    }
}