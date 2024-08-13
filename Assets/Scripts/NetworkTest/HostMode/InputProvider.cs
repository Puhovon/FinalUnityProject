using System;
using System.Collections.Generic;
using Fusion;
using Fusion.Sockets;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.NetworkTest.HostMode
{
    public class InputProvider : NetworkBehaviour, INetworkRunnerCallbacks
    {
        [SerializeField] private TMP_Text _text;
        private Messagging _messagging;

        private MainInputActions _playerActionMap;
        private Vector2 _moveInput;
        private Vector2 _mousePosition;
        [Networked] public NetworkButtons ButtonsPrevious { get; set; }

        
        public override void Spawned()
        {
            _playerActionMap = new MainInputActions();
            _messagging = new Messagging(this, _text);
            _playerActionMap.Movement.Move.performed += OnMovePerformed;
            _playerActionMap.Movement.Move.canceled += OnMoveCanceled;
            _playerActionMap.Movement.MousePosition.performed += OnMousePositionPerformed;
            _playerActionMap.Enable();
            Runner.AddCallbacks(this);
        }

        private void OnMousePositionPerformed(InputAction.CallbackContext obj)
        {
            _mousePosition = obj.ReadValue<Vector2>();
        }

        private void OnMoveCanceled(InputAction.CallbackContext obj)
        {
            _moveInput = Vector2.zero;
        }

        private void OnMovePerformed(InputAction.CallbackContext obj)
        {
            _moveInput = obj.ReadValue<Vector2>();
        }

        
        public void OnInput(NetworkRunner runner, NetworkInput input)
        {
            NetworkInputData data = new NetworkInputData
            {
                movement = new Vector3(_moveInput.x, 0, _moveInput.y),
                lookRotation =  _mousePosition,
            };
            data.buttons.Set(MyButtons.Fire, _playerActionMap.Movement.Shoot.IsPressed());
            data.buttons.Set(MyButtons.Help, _playerActionMap.Movement.Help.IsPressed());
            input.Set(data);
            
        }

        
        public override void FixedUpdateNetwork()
        {
            if (Runner.TryGetInputForPlayer<NetworkInputData>(Object.InputAuthority, out NetworkInputData data))
            {
                var pressed = data.buttons.GetPressed(ButtonsPrevious);
                ButtonsPrevious = data.buttons;
               if(pressed.IsSet(MyButtons.Help))
                    _messagging.NeedHelp();
            }
        }

        #region trash 
        
        public void OnObjectExitAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
        {
            
        }

        public void OnObjectEnterAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
        {
        }

        public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
        {
        }

        public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
        {
        }



        public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
        {
        }

        public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
        {
        }

        public void OnConnectedToServer(NetworkRunner runner)
        {
        }

        public void OnDisconnectedFromServer(NetworkRunner runner, NetDisconnectReason reason)
        {
        }

        public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
        {
        }

        public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
        {
        }

        public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
        {
        }

        public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
        {
        }

        public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
        {
        }

        public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
        {
        }

        public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ReliableKey key, ArraySegment<byte> data)
        {
        }

        public void OnReliableDataProgress(NetworkRunner runner, PlayerRef player, ReliableKey key, float progress)
        {
        }

        public void OnSceneLoadDone(NetworkRunner runner)
        {
        }

        public void OnSceneLoadStart(NetworkRunner runner)
        {
        }
        #endregion

        public override void Despawned(NetworkRunner runner, bool hasState)
        {
            if (_playerActionMap != null)
            {
                _playerActionMap.Movement.Move.performed -= OnMovePerformed;
                _playerActionMap.Movement.Move.canceled -= OnMoveCanceled;
                _playerActionMap.Movement.MousePosition.performed += OnMousePositionPerformed;
                Runner.RemoveCallbacks(this);
            }
        }
    }
}