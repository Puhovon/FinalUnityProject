using System;
using Player.StateMachine;
using Player.StateMachine.States;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(CharacterController))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerConfig _config;
        [SerializeField] private PlayerView _view;
        [SerializeField] private Shooter _shooter;
        private MainInputActions _input;
        private PlayerStateMachine _stateMachine;
        private CharacterController _controller;

        public MainInputActions Input => _input;
        public CharacterController CharacterController => _controller;
        public PlayerConfig Config => _config;
        
        public PlayerView View => _view;
        
        private void Awake()
        {
            _view.Initialize();
            _shooter.Initialize();
            _input = new MainInputActions();
            _controller = GetComponent<CharacterController>();
            _stateMachine = new PlayerStateMachine(this, _shooter, _config);
        }

        private void Update()
        {
            _stateMachine.HandleInput();
            _stateMachine.Update();
        }

        private void OnEnable() => _input.Enable();

        private void OnDisable() => _input.Disable();
    }
}