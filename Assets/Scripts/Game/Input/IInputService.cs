using Core.Framework.Data;
using UnityEngine;

namespace Game.Input
{
    public interface IInputService
    {
        public IMutableObservableProperty<bool> IsTouching { get; }
        public Vector2 TouchDelta { get; set; }
        public Vector2 TouchPosition { get; set; }
    }
}
