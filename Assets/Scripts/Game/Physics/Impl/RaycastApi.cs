using UnityEngine;

namespace Game.Physics.Impl
{
    internal class RaycastApi : IRaycastApi
    {
        private readonly IRaycastRepository _raycastRepository;

        public RaycastApi(IRaycastRepository raycastRepository)
        {
            _raycastRepository = raycastRepository;
        }

        public bool IsHit => _raycastRepository.CurrentHit.transform;
        public RaycastHit currentHit => _raycastRepository.CurrentHit;
        public RaycastHit lastHit => _raycastRepository.LastHit;
    }
}
