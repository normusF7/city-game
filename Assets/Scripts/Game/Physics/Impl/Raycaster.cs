using Game.Camera;
using Game.Input;
using System;
using UnityEngine;
using Zenject;

namespace Game.Physics.Impl
{
    public class Raycaster : IRaycaster, IInitializable, IDisposable, ITickable
    {
        private readonly IInputApi _inputApi;
        private readonly ICameraDecorator _cameraDecorator;
        private readonly IRaycastRepository _raycastRepository;

        public Raycaster(
            IInputApi inputApi, 
            ICameraDecorator cameraDecorator,
            IRaycastRepository raycastRepository)
        {
            _inputApi = inputApi;
            _cameraDecorator = cameraDecorator;
            _raycastRepository = raycastRepository;
        }

        public void Initialize()
        {
            _inputApi.isTapping.Bind(IsTappingChanged);
        }

        public void Dispose()
        {
            _inputApi.isTapping.UnBind(IsTappingChanged);
        }

        public void Tick()
        {
            PerformRaycast();
        }

        public void IsTappingChanged(bool value)
        {
            if(value)
            {
                PerformRaycast();
            }
        }

        private void PerformRaycast()
        {
            var ray = _cameraDecorator.ScreenPointToRay(_inputApi.TouchPosition);
            UnityEngine.Physics.Raycast(ray, out var hit);
            _raycastRepository.SetCurrentHit(hit);
        }
    }
}
