using UnityEngine;

namespace Game.Physics.Impl
{
    internal class RaycastService : IRaycastService
    {
        private readonly IRaycastRepository _raycastRepository;

        public bool IsHit => _raycastRepository.CurrentHit.transform;
        public RaycastHit CurrentHit => _raycastRepository.CurrentHit;
        public RaycastHit LastHit => _raycastRepository.LastHit;
        
        public RaycastService(IRaycastRepository raycastRepository)
        {
            _raycastRepository = raycastRepository;
        }
    }
}
