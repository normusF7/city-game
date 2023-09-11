using UnityEngine;

namespace Game.Physics
{
    public interface IRaycastService
    {
        public bool IsHit { get; }
        public RaycastHit CurrentHit { get; }
        public RaycastHit LastHit { get; }
    }
}
