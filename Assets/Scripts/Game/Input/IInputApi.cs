using Core.Framework.Data;
using UnityEngine;

namespace Game.Input
{
    public interface IInputApi
    {
        public IBindableProperty<bool> isTapping { get; }
        public Vector2 TouchDelta { get;}
        public Vector2 TouchPosition { get; }
    }
}
