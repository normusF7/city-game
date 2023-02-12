using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Grid.Data.Impl
{
    [CreateAssetMenu(fileName = "Library", menuName = "ScriptableObjects/HighlightColorLibrary", order = 1)]
    public class HighlightColorLibrary : ScriptableObject
    {
        [SerializeField] 
        private List<HighlightColor> _highlightColors;

        public IReadOnlyList<HighlightColor> HighlightColors => _highlightColors;
    }
    
    [Serializable]
    public class HighlightColor
    {
         public HighlightType HighlightType;
         public Color Color;
    }
}