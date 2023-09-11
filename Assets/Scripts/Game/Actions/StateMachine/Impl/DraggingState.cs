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
        private readonly IInputService _inputService;
        private readonly IRaycastService _raycastService;
        private readonly IGridService _gridService;
        private readonly IActionsContext _actionsContext;
        private readonly ViewingState.Factory _viewingStateFactory;
        private readonly ICursorService _cursorService;
        
        public DraggingState(
            Vector2Int buildingStartPosition,
            IBuilding draggedBuilding, 
            IInputService inputService, 
            IRaycastService raycastService,
            IGridService gridService,
            IActionsContext actionsContext,
            ViewingState.Factory viewingStateFactory,
            ICursorService cursorService)
        {
            _buildingStartPosition = buildingStartPosition;
            _draggedBuilding = draggedBuilding;
            _inputService = inputService;
            _raycastService = raycastService;
            _gridService = gridService;
            _actionsContext = actionsContext;
            _viewingStateFactory = viewingStateFactory;
            _cursorService = cursorService;
        }

        public void Begin()
        {
            _cursorService.TryConnectToCursor(_draggedBuilding);
        }

        public void Update()
        {
            if (_raycastService.IsHit)
            {
                ProcessHit();
            }
            else
            {
                _gridService.ResetHighlight();
            }

            if (_inputService.IsTouching.Value == false && _raycastService.IsHit)
            {
                PutObjectDown();
            }
        }

        public void End()
        {
            _cursorService.TryReleaseFromCursor(out _);
            _gridService.ResetHighlight();
        }

        private void ProcessHit()
        {
            _cursorService.SetPosition(_raycastService.CurrentHit.point + new Vector3(0, 1.4f, 0));
            if (_gridService.TryGetPlacedBuildingAtPosition(_raycastService.CurrentHit.point, out var builidng))
            {
                if (builidng.CanBeMergedWith(_draggedBuilding))
                {
                    _gridService.SetHighlightAtPosition(_gridService.GridPositionFromWorld(_raycastService.CurrentHit.point),
                        HighlightType.Available);
                }
                else
                {
                    _gridService.SetHighlightAtPosition(_gridService.GridPositionFromWorld(_raycastService.CurrentHit.point),
                        HighlightType.Unavailable);
                }
            }
            else
            {
                _gridService.SetHighlightAtPosition(_gridService.GridPositionFromWorld(_raycastService.CurrentHit.point),
                    HighlightType.Available);
            }
        }
        
        private void PutObjectDown()
        {
            _draggedBuilding.ResetRigidbody();
            
            if (_gridService.TryPlaceBuildingAtWorldPosition(_draggedBuilding, _raycastService.CurrentHit.point))
            {
                _actionsContext.ChangeState(_viewingStateFactory.Create());
            }
            else
            {
                _gridService.TryGetPlacedBuildingAtPosition(_raycastService.CurrentHit.point, out var builidng);

                if (builidng.CanBeMergedWith(_draggedBuilding))
                {
                    builidng.Upgrade();
                    _draggedBuilding.Dispose();
                }
                else
                {
                    _gridService.TryPlaceBuildingAtGridPosition(_draggedBuilding, _buildingStartPosition);
                }

                _actionsContext.ChangeState(_viewingStateFactory.Create());
            }
        }

        public class Factory : PlaceholderFactory<Vector2Int, IBuilding, DraggingState>
        {
        }
    }
}