using System.Linq;
using Game.Grid.Data.Impl;
using UnityEngine;

namespace Game.Grid.Impl
{
    public class GridRenderer : IGridRenderer
    {
        private readonly Material _gridMaterial;
        private readonly HighlightColorLibrary _highlightColorLibrary;

        public GridRenderer(Material gridMaterial, HighlightColorLibrary highlightColorLibrar)
        {
            _gridMaterial = gridMaterial;
            _highlightColorLibrary = highlightColorLibrar;
        }

        public void ResetHighlight()
        {
            _gridMaterial.SetVector("_SelectedPosition", -Vector4.one);
        }

        public void SetHighlightAtPosition(Vector2Int position, HighlightType highlightType)
        {
            var color = _highlightColorLibrary.HighlightColors.FirstOrDefault(x => x.HighlightType == highlightType)
                .Color;
            
            _gridMaterial.SetVector("_SelectedPosition", new Vector4(position.x, position.y, 0, 0));
            _gridMaterial.SetColor("_SelectedColor", color);
        }
    }
}