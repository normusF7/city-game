using Core.Framework.Data;
using Core.Framework.Data.Impl;
using UnityEngine;

namespace Game.Input.Impl
{
    public class InputService : IInputService
    {
        private readonly IMutableBindableProprty<bool> _isTapping = new BindableProperty<bool>();

        private Vector2 _touchDelta;
        private Vector2 _touchPosition;

        public IMutableBindableProprty<bool> isTapping => _isTapping;
        public Vector2 TouchDelta { get => _touchDelta; set => _touchDelta = value; }
        public Vector2 TouchPosition { get => _touchPosition; set => _touchPosition = value; }
    }
}
