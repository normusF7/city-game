using Core.Framework.StateMachine;
using Game.Input;
using UnityEngine;
using Zenject;

namespace Game.Actions.StateMachine.Impl
{
    public class ViewingState : IMutableState
    {
        private readonly CameraControllerComponent _cameraControllerComponent;
        private readonly IInputService _inputService;

        public ViewingState(CameraControllerComponent cameraControllerComponent, IInputService inputService)
        {
            _cameraControllerComponent = cameraControllerComponent;
            _inputService = inputService;
        }

        public void Begin()
        {
            UnityEngine.Debug.Log("Start viewing.");
        }

        public void Update()
        {
            if(_inputService.IsTouching.Value)
            {
                _cameraControllerComponent.Move(-_inputService.TouchDelta * Time.deltaTime);
            }
        }

        public void End()
        {
        }
        
        public class Factory : PlaceholderFactory<ViewingState>
        {
        }
    }
}