using UnityEngine;
using Zenject;

namespace Game.Input.Impl
{
    public class CameraController : ICameraController, ITickable
    {
        private readonly CameraControllerComponent _cameraControllerComponent;
        private readonly IInputApi _inputApi;

        public CameraController(CameraControllerComponent cameraControllerComponent, IInputApi inputApi)
        {
            _cameraControllerComponent = cameraControllerComponent;
            _inputApi = inputApi;
        }

        public void Tick()
        {
            if(_inputApi.isTapping.Value)
            {
                _cameraControllerComponent.Move(-_inputApi.TouchDelta * Time.deltaTime);
            }
        }
    }
}
