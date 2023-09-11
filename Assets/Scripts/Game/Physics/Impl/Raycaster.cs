using Game.Camera;
using Game.Input;
using System;
using Zenject;

namespace Game.Physics.Impl
{
    public class Raycaster : IRaycaster, IInitializable, IDisposable, ITickable
    {
        private readonly IInputService _inputService;
        private readonly ICameraDecorator _cameraDecorator;
        private readonly IRaycastRepository _raycastRepository;

        public Raycaster(
            IInputService inputService, 
            ICameraDecorator cameraDecorator,
            IRaycastRepository raycastRepository)
        {
            _inputService = inputService;
            _cameraDecorator = cameraDecorator;
            _raycastRepository = raycastRepository;
        }

        public void Initialize()
        {
            _inputService.IsTouching.Observe(IsTappingChanged);
        }

        public void Dispose()
        {
            _inputService.IsTouching.UnObserve(IsTappingChanged);
        }

        public void Tick()
        {
            PerformRaycast();
        }

        private void IsTappingChanged(bool value)
        {
            if(value)
            {
                PerformRaycast();
            }
        }

        private void PerformRaycast()
        {
            var ray = _cameraDecorator.ScreenPointToRay(_inputService.TouchPosition);
            UnityEngine.Physics.Raycast(ray, out var hit);
            _raycastRepository.SetCurrentHit(hit);
        }
    }
}
