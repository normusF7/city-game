using Core.Framework.Data;
using Core.Framework.Data.Impl;
using UnityEngine;

namespace Game.Input.Impl
{
    public class InputService : IInputService
    {
        private readonly IMutableObservableProperty<bool> _isTouching = new ObservableProperty<bool>();

        private Vector2 _touchDelta;
        private Vector2 _touchPosition;

        public IMutableObservableProperty<bool> IsTouching => _isTouching;
        public Vector2 TouchDelta { get => _touchDelta; set => _touchDelta = value; }
        public Vector2 TouchPosition { get => _touchPosition; set => _touchPosition = value; }
    }
}
