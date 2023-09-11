using System.Linq;
using Game.Grid.Data.Impl;
using UnityEngine;

namespace Game.Grid.Impl
{
    public class GridRenderer : IGridRenderer
    {
        private static readonly int SelectedPosition = Shader.PropertyToID("_SelectedPosition");
        private static readonly int SelectedColor = Shader.PropertyToID("_SelectedColor");
        
        private readonly Material _gridMaterial;
        private readonly HighlightColorLibrary _highlightColorLibrary;

        public GridRenderer(Material gridMaterial, HighlightColorLibrary highlightColorLibrar)
        {
            _gridMaterial = gridMaterial;
            _highlightColorLibrary = highlightColorLibrar;
        }

        public void ResetHighlight()
        {
            _gridMaterial.SetVector(SelectedPosition, -Vector4.one);
        }

        public void SetHighlightAtPosition(Vector2Int position, HighlightType highlightType)
        {
            var color = _highlightColorLibrary.HighlightColors.FirstOrDefault(x => x.HighlightType == highlightType).Color;
            
            _gridMaterial.SetVector(SelectedPosition, new Vector4(position.x, position.y, 0, 0));
            _gridMaterial.SetColor(SelectedColor, color);
        }
    }
}