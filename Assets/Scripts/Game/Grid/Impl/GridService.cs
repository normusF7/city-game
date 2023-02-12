using Game.Grid.Data;
using Game.Grid.Data.Impl;
using UnityEngine;

namespace Game.Grid.Impl
{
    public class GridService : IGridService
    {
        private readonly IGridRepository _gridRepository;
        private readonly IGridRenderer _gridRenderer;

        public GridService(IGridRepository gridRepository, IGridRenderer gridRenderer)
        {
            _gridRepository = gridRepository;
            _gridRenderer = gridRenderer;
        }

        public bool TryPlaceBuildingAtWorldPosition(IBuilding building, Vector3 worldPosition)
        {
            var gridPosition = _gridRepository.WorldPosToGrid(worldPosition);
            return _gridRepository.TrySetBuilding(building, gridPosition);
        }

        public bool TryPlaceBuildingAtGridPosition(IBuilding building, Vector2Int gridPosition)
        {
            return _gridRepository.TrySetBuilding(building, gridPosition);
        }

        public bool TryGetBuildingAtPosition(Vector3 worldPosition, out IBuilding building)
        {
            var gridPosition = _gridRepository.WorldPosToGrid(worldPosition);
            return _gridRepository.TryGetBuildingAtPosition(gridPosition, out building);
        }

        public bool TryGetPlacedBuildingAtPosition(Vector3 worldPosition, out IPlacedBuilding building)
        {
            var gridPosition = _gridRepository.WorldPosToGrid(worldPosition);
            return _gridRepository.TryGetPlacedBuildingAtPosition(gridPosition, out building);
        }

        public Vector2Int GridPositionFromWorld(Vector3 worldPosition)
        {
            return _gridRepository.WorldPosToGrid(worldPosition);
        }

        public void ResetHighlight()
        {
            _gridRenderer.ResetHighlight();
        }

        public void SetHighlightAtPosition(Vector2Int position, HighlightType highlightType)
        {
            _gridRenderer.SetHighlightAtPosition(position, highlightType);
        }
    }
}