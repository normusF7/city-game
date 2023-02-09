using UnityEngine;

namespace Game.Buildings
{
    public class BuildingComponent : MonoBehaviour
    {
        [SerializeField]
        private Collider _collider;

        public bool CollisionsEnabled => _collider.enabled;

        private void Awake()
        {
            _collider = GetComponentInChildren<Collider>();
        }

        public void SetCollisions(bool isEnabled)
        {
            _collider.enabled = isEnabled;
        }

        public void SetPickedUp()
        {
        }
        
        public void SetPlaced()
        {
        }
    }
}