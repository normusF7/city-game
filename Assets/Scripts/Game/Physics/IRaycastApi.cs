using UnityEngine;

namespace Game.Physics
{
    internal interface IRaycastApi
    {
        public bool IsHit { get; }
        public RaycastHit currentHit { get; }
        public RaycastHit lastHit { get; }
    }
}
