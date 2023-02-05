using Core.Framework.Data;
using UnityEngine;

namespace Game.Input.Impl
{
    public class InputApi : IInputApi
    {
        private readonly IInputService _inputService;

        public IBindableProperty<bool> isTapping => _inputService.isTapping;
        public Vector2 TouchDelta => _inputService.TouchDelta;
        public Vector2 TouchPosition => _inputService.TouchPosition;

        public InputApi(IInputService inputService)
        {
            _inputService = inputService;
        }
    }
}
