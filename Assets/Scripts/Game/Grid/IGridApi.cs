using Game.Grid.Data;
using Game.Grid.Data.Impl;
using UnityEngine;

namespace Game.Grid
{
    public interface IGridApi
    {
        bool TryPlaceBuildingAtWorldPosition(IBuilding building, Vector3 worldPosition);
        bool TryPlaceBuildingAtGridPosition(IBuilding building, Vector2Int gridPosition);
        bool TryGetBuildingAtPosition(Vector3 worldPosition, out IBuilding building);
        bool TryGetPlacedBuildingAtPosition(Vector3 worldPosition, out IPlacedBuilding building);
        Vector2Int GridPositionFromWorld(Vector3 worldPosition);
        void ResetHighlight();
        void SetHighlightAtPosition(Vector2Int position, HighlightType highlightType);
    }
}