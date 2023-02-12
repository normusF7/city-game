using Game.Actions.StateMachine.Impl;
using Game.Grid;
using Game.Input;
using UnityEngine;

namespace Game.Actions.Handlers.Impl
{
    public class PickupHandler : IActionHandler
    {
        private const float HoldTime = 0.5f;

        private readonly IGridApi _gridApi;
        private readonly IInputApi _inputApi;
        private readonly IActionsContext _actionsContext;
        private readonly DraggingState.Factory _draggingStateFactory;
        
        private float _currentHoldTime;

        public int Priority => 1;
        
        public PickupHandler(
            IGridApi gridApi,
            IInputApi inputApi,
            IActionsContext actionsContext, 
            DraggingState.Factory draggingStateFactory)
        {
            _gridApi = gridApi;
            _inputApi = inputApi;
            _actionsContext = actionsContext;
            _draggingStateFactory = draggingStateFactory;
        }

        public bool Handle(RaycastHit hit)
        {
            if (!_inputApi.isTapping.Value)
            {
                _currentHoldTime = 0;
            }
            
            if (_actionsContext.CurrentState.GetType() == typeof(DraggingState))
            {
                return true;
            }
            
            if (!hit.transform || !hit.transform.CompareTag("Interactable"))
            {
                return false;
            }

            _currentHoldTime += Time.deltaTime;
            
            if(_currentHoldTime >= HoldTime && _gridApi.TryGetBuildingAtPosition(hit.point, out var building))
            {
                var gridPos = _gridApi.GridPositionFromWorld(hit.point);
                
                _actionsContext.ChangeState(_draggingStateFactory.Create(gridPos, building));
                return true;
            }

            return false;
        }
    }
}