using UnityEngine;

namespace Game.Physics
{
    public interface IRaycastRepository
    {
        public RaycastHit CurrentHit { get; }
        public RaycastHit LastHit { get; }

        public void SetCurrentHit(RaycastHit hit);
    }
}
