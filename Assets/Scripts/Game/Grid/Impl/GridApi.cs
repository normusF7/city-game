using Game.Grid.Data;
using Game.Grid.Data.Impl;
using UnityEngine;

namespace Game.Grid.Impl
{
    public class GridApi : IGridApi
    {
        private readonly IGridService _gridService;

        public GridApi(IGridService gridService)
        {
            _gridService = gridService;
        }
        
        public bool TryPlaceBuildingAtWorldPosition(IBuilding building, Vector3 worldPosition)
        {
            return _gridService.TryPlaceBuildingAtWorldPosition(building, worldPosition);
        }

        public bool TryPlaceBuildingAtGridPosition(IBuilding building, Vector2Int gridPosition)
        {
            return _gridService.TryPlaceBuildingAtGridPosition(building, gridPosition);
        }

        public bool TryGetBuildingAtPosition(Vector3 worldPosition, out IBuilding building)
        {
            return _gridService.TryGetBuildingAtPosition(worldPosition, out building);
        }

        public bool TryGetPlacedBuildingAtPosition(Vector3 worldPosition, out IPlacedBuilding building)
        {
            return _gridService.TryGetPlacedBuildingAtPosition(worldPosition, out building);
        }

        public Vector2Int GridPositionFromWorld(Vector3 worldPosition)
        {
            return _gridService.GridPositionFromWorld(worldPosition);
        }

        public void ResetHighlight()
        {
            _gridService.ResetHighlight();
        }

        public void SetHighlightAtPosition(Vector2Int position, HighlightType highlightType)
        {
            _gridService.SetHighlightAtPosition(position, highlightType);
        }
    }
}