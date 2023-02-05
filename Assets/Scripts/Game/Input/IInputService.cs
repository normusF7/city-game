
using Core.Framework.Data;
using UnityEngine;

namespace Game.Input
{
    public interface IInputService
    {
        public IMutableBindableProprty<bool> isTapping { get; }
        public Vector2 TouchDelta { get; set; }
        public Vector2 TouchPosition { get; set; }
    }
}
