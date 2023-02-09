using Core.Framework.StateMachine;
using Game.Input;
using UnityEngine;

namespace Game.Actions.StateMachine.Impl
{
    public class ViewingState : IMutableState
    {
        private readonly CameraControllerComponent _cameraControllerComponent;
        private readonly IInputApi _inputApi;

        public ViewingState(CameraControllerComponent cameraControllerComponent, IInputApi inputApi)
        {
            _cameraControllerComponent = cameraControllerComponent;
            _inputApi = inputApi;
        }

        public void Begin()
        {
            UnityEngine.Debug.Log("Start viewing.");
        }

        public void Update()
        {
            if(_inputApi.isTapping.Value)
            {
                _cameraControllerComponent.Move(-_inputApi.TouchDelta * Time.deltaTime);
            }
        }

        public void End()
        {
        }
    }
}