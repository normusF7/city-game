using Game.Actions.StateMachine.Impl;
using Game.Input;
using UnityEngine;

namespace Game.Actions.Handlers.Impl
{
    public class ViewingHandler : IActionHandler
    {
        private readonly IActionsContext _actionsContext;
        private readonly CameraControllerComponent _cameraController;
        private readonly IInputApi _inputApi;

        public ViewingHandler(IActionsContext actionsContext, CameraControllerComponent cameraController, IInputApi inputApi)
        {
            _actionsContext = actionsContext;
            _cameraController = cameraController;
            _inputApi = inputApi;
        }

        public int Priority => 0;
        public bool Handle(RaycastHit hit)
        {
            if (_actionsContext.CurrentState.GetType() == typeof(ViewingState))
            {
                return false;
            }
            
            if (_actionsContext.CurrentState.GetType() == typeof(ViewingState))
            {
                return true;
            }

            _actionsContext.ChangeState(new ViewingState(_cameraController, _inputApi));
            return true;
        }
    }
}