using Assets.Scripts.Abstractions;
using Assets.Scripts.PlayerScripts.Configs;
using Assets.Scripts.PlayerScripts.StateMachine;
using Fusion;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.PlayerScripts
{
    public class Player : NetworkBehaviour, IEntity
    {
        [SerializeField] private PlayerConfig _config;
        [SerializeField] private PlayerView _view;
        [SerializeField] private Shooter _shooter;
        [SerializeField] private Messagging _messagging;

        [Inject] private MainInputActions _input;

        private PlayerStateMachine _stateMachine;
        private CharacterController _controller;

        public MainInputActions Input => _input;
        public CharacterController CharacterController => _controller;
        public PlayerConfig Config => _config;
        
        public PlayerView View => _view;

        public Transform Transform => transform;
        public PlayerStateMachine StateMachine => _stateMachine;

        private void Awake()
        {
            _view.Initialize();
            _shooter.Initialize();
            _controller = GetComponent<CharacterController>();
            _input = new MainInputActions();
            _stateMachine = new PlayerStateMachine(this, _shooter, _config);
            _messagging.Construct(Input);
        }

        public override void FixedUpdateNetwork()
        {
            if (HasStateAuthority)
            {
                _stateMachine.HandleInput();
            }
            _stateMachine.Update();
        }

        private void OnEnable() => _input.Enable();

        private void OnDisable() => _input.Disable();
    }
}