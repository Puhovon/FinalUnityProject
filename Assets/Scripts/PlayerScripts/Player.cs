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
        [SerializeField] private CameraFollow _cameraFollow;
        
        [Networked] public NetworkButtons ButtonsPrevious { get; set; }
        
        private PlayerStateMachine _stateMachine;
        private NetworkCharacterController _controller;

        public NetworkCharacterController CharacterController => _controller;
        public PlayerConfig Config => _config;
        
        public PlayerView View => _view;

        public Transform Transform => transform;
        public PlayerStateMachine StateMachine => _stateMachine;


        public override void Spawned()
        {
            _view.Initialize();
            _shooter.Initialize();
            _controller = GetComponent<NetworkCharacterController>();
            // _controller.rotationSpeed = 0;
            _stateMachine = new PlayerStateMachine(this, _shooter, _config);
            // _cameraFollow.Init(transform);
        }
        public override void FixedUpdateNetwork()
        {
            print(HasStateAuthority);
            if (HasStateAuthority)
            {
                _stateMachine.HandleInput();
            }
            _stateMachine.Update();
        }
    }
}