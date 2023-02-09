using Game.Grid.Data;
using UnityEngine;

namespace Game.Grid
{
    public interface IGridRepository
    {
        ICell GetCell(Vector2Int position);
        bool TrySetBuildingClipboard(IBuilding building);
        bool TryGetBuildingClipboard(out IBuilding building);
        bool TrySetBuildingFromClipboard(Vector2Int position);
        bool TrySetBuilding(IBuilding building, Vector2Int position);
    }
}