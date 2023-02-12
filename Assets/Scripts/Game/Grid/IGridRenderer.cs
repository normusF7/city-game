using Game.Grid.Data.Impl;
using UnityEngine;

namespace Game.Grid
{
    public interface IGridRenderer
    {
        void ResetHighlight();
        void SetHighlightAtPosition(Vector2Int position, HighlightType highlightType);
    }
}