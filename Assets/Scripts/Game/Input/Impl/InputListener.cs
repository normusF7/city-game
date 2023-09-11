using UnityEngine.InputSystem;
using UnityEngine;
using Zenject;
using System;
using UnityEngine.EventSystems;

namespace Game.Input.Impl
{
    public class InputListener : IInputListener, IInitializable, IDisposable, ITickable
    {
        private readonly PlayerActions _playerActions;
        private readonly IInputService _inputService;

        private InputListener(IInputService inputService)
        {
            _playerActions = new PlayerActions();
            _inputService = inputService;
        }

        private void OnTouchPress(InputAction.CallbackContext context)
        {
            _inputService.IsTouching.Value = context.ReadValueAsButton();
        }

        public void Initialize()
        {
            _playerActions.Enable();
            _playerActions.Touch.TouchPress.started += OnTouchPress;
            _playerActions.Touch.TouchPress.canceled += OnTouchPress;
        }

        public void Dispose()
        {
            _playerActions.Touch.TouchPress.started -= OnTouchPress;
            _playerActions.Touch.TouchPress.canceled -= OnTouchPress;
            _playerActions.Disable();
        }

        public void Tick()
        {
            _inputService.TouchDelta = _playerActions.Touch.TouchDelta.ReadValue<Vector2>();
            _inputService.TouchPosition = _playerActions.Touch.TouchPosition.ReadValue<Vector2>();
        }
    }
}
