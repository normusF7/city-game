using UnityEngine;

namespace Game.Physics.Impl
{
    internal class RaycastRepository : IRaycastRepository
    {
        private RaycastHit _currentHit;
        private RaycastHit _lastHit;

        public RaycastHit CurrentHit => _currentHit;
        public RaycastHit LastHit => _lastHit;

        public void SetCurrentHit(RaycastHit raycastHit)
        {
            _lastHit = CurrentHit;
            _currentHit = raycastHit;
        }
    }
}
