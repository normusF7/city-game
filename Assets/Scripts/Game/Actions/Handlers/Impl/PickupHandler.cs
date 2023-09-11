using Game.Actions.StateMachine.Impl;
using Game.Grid;
using Game.Input;
using UnityEngine;

namespace Game.Actions.Handlers.Impl
{
    public class PickupHandler : IActionHandler
    {
        private const string InteractableTag = "Interactable";
        private const float HoldTime = 0.5f;

        private readonly IGridService _gridService;
        private readonly IInputService _inputService;
        private readonly IActionsContext _actionsContext;
        private readonly DraggingState.Factory _draggingStateFactory;
        
        private float _currentHoldTime;

        public int Priority => 1;
        
        public PickupHandler(
            IGridService gridService,
            IInputService inputService,
            IActionsContext actionsContext, 
            DraggingState.Factory draggingStateFactory)
        {
            _gridService = gridService;
            _inputService = inputService;
            _actionsContext = actionsContext;
            _draggingStateFactory = draggingStateFactory;
        }

        public bool Handle(RaycastHit hit)
        {
            if (!_inputService.IsTouching.Value)
            {
                _currentHoldTime = 0;
            }
            
            if (_actionsContext.CurrentState is DraggingState)
            {
                return true;
            }
            
            if (!hit.transform || !hit.transform.CompareTag(InteractableTag))
            {
                return false;
            }

            _currentHoldTime += Time.deltaTime;
            
            if(_currentHoldTime >= HoldTime && _gridService.TryGetBuildingAtPosition(hit.point, out var building))
            {
                var gridPos = _gridService.GridPositionFromWorld(hit.point);
                
                _actionsContext.ChangeState(_draggingStateFactory.Create(gridPos, building));
                return true;
            }

            return false;
        }
    }
}