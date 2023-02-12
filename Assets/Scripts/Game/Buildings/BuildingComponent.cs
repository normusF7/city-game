using Game.Buildings.Data;
using UnityEngine;

namespace Game.Buildings
{
    public class BuildingComponent : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody _rigidbody;
        [SerializeField]
        private Transform _prefabSocket;
        [SerializeField]
        private GameObject _currentPrefab;
        [SerializeField]
        private BuildingsModelLibrary _buildingsModelLibrary;
        
        private Collider _collider;

        public bool CollisionsEnabled => _collider.enabled;

        private void Awake()
        {
            _collider = GetComponentInChildren<Collider>();
            _rigidbody.isKinematic = true;
            SetLevel(0);
        }

        public void SetCollisions(bool isEnabled)
        {
            _collider.enabled = isEnabled;
        }

        public void SetPickedUp()
        {
            SetCollisions(false);
        }
        
        public void SetPlaced()
        {
            SetCollisions(true);
        }

        public Rigidbody GetRigidbody()
        {
            _rigidbody.isKinematic = false;
            return _rigidbody;
        }

        public void SetLevel(int level)
        {
            if (_currentPrefab)
            {
                _currentPrefab.transform.SetParent(null);
                Destroy(_currentPrefab);
            }

            _currentPrefab = Instantiate(_buildingsModelLibrary.HousePrefabs[level], _prefabSocket);
            _collider = GetComponentInChildren<Collider>();
        }
        
        public void DisableRigidbody()
        {
            _rigidbody.isKinematic = true;
            transform.eulerAngles = new Vector3(-90, 0, 0);
        }
    }
}