using Core.Framework.StateMachine;
using Game.Cursor;
using Game.Grid;
using Game.Grid.Data;
using Game.Grid.Data.Impl;
using Game.Input;
using Game.Physics;
using UnityEngine;
using Zenject;

namespace Game.Actions.StateMachine.Impl
{
    public class DraggingState : IMutableState
    {
        private readonly Vector2Int _buildingStartPosition;
        private readonly IBuilding _draggedBuilding;
        private readonly IInputApi _inputApi;
        private readonly IRaycastApi _raycastApi;
        private readonly IGridApi _gridApi;
        private readonly IActionsContext _actionsContext;
        private readonly ViewingState.Factory _viewingStateFactory;
        private readonly ICursorApi _cursorApi;
        
        public DraggingState(
            Vector2Int buildingStartPosition,
            IBuilding draggedBuilding, 
            IInputApi inputApi, 
            IRaycastApi raycastApi,
            IGridApi gridApi,
            IActionsContext actionsContext,
            ViewingState.Factory viewingStateFactory,
            ICursorApi cursorApi)
        {
            _buildingStartPosition = buildingStartPosition;
            _draggedBuilding = draggedBuilding;
            _inputApi = inputApi;
            _raycastApi = raycastApi;
            _gridApi = gridApi;
            _actionsContext = actionsContext;
            _viewingStateFactory = viewingStateFactory;
            _cursorApi = cursorApi;
        }

        public void Begin()
        {
            UnityEngine.Debug.Log("Start dragging");
            _cursorApi.TryConnectToCursor(_draggedBuilding);
        }

        public void Update()
        {
            if (_raycastApi.IsHit)
            {
                _cursorApi.SetPosition(_raycastApi.currentHit.point + new Vector3(0, 1.4f, 0));
                if (_gridApi.TryGetPlacedBuildingAtPosition(_raycastApi.currentHit.point, out var builidng))
                {
                    if (builidng.CanBeMergedWith(_draggedBuilding))
                    {
                        _gridApi.SetHighlightAtPosition(_gridApi.GridPositionFromWorld(_raycastApi.currentHit.point), HighlightType.Available);
                    }
                    else
                    {
                        _gridApi.SetHighlightAtPosition(_gridApi.GridPositionFromWorld(_raycastApi.currentHit.point), HighlightType.Unavailable);
                    }
                }
                else
                {
                    _gridApi.SetHighlightAtPosition(_gridApi.GridPositionFromWorld(_raycastApi.currentHit.point), HighlightType.Available);
                }
            }
            else
            {
                _gridApi.ResetHighlight();
            }

            if (_inputApi.isTapping.Value == false && _raycastApi.IsHit)
            {
                _draggedBuilding.ResetRigidbody();
                if(_gridApi.TryPlaceBuildingAtWorldPosition(_draggedBuilding, _raycastApi.currentHit.point))
                {
                    UnityEngine.Debug.Log("Building placed.");
                    _actionsContext.ChangeState(_viewingStateFactory.Create());
                }
                else
                {
                    _gridApi.TryGetPlacedBuildingAtPosition(_raycastApi.currentHit.point, out var builidng);
                    
                    if (builidng.CanBeMergedWith(_draggedBuilding))
                    {
                        builidng.Upgrade();
                        _draggedBuilding.Dispose();
                    }
                    else
                    {
                        _gridApi.TryPlaceBuildingAtGridPosition(_draggedBuilding, _buildingStartPosition);
                    }
                    
                    _actionsContext.ChangeState(_viewingStateFactory.Create());
                }
                
            }
        }

        public void End()
        {
            _cursorApi.TryReleaseFromCursor(out _);
            _gridApi.ResetHighlight();
        }

        public class Factory : PlaceholderFactory<Vector2Int, IBuilding, DraggingState>
        {
        }
    }
}