using System;
using Game.Buildings;
using Game.Buildings.Data;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Game.Grid.Data.Impl
{
    public class Building : IBuilding
    {
        private readonly BuildingComponent _buildingComponent;

        private int _level;

        public int Level => _level;
        public BuildingType Type { get; }

        public Building(BuildingComponent buildingComponent)
        {
            _buildingComponent = buildingComponent;
        }

        public void SetPosition(Vector3 position)
        {
            _buildingComponent.transform.position = position;
        }

        public void ResetRigidbody()
        {
            _buildingComponent.DisableRigidbody();
        }

        public void SetCollisions(bool enabled)
        {
            _buildingComponent.SetCollisions(enabled);
        }

        public void Upgrade()
        {
            _level++;
            _buildingComponent.SetLevel(_level);
        }

        public bool CanBeMergedWith(IBuilding building)
        {
            return Type == building.Type && Level == building.Level;
        }

        public Rigidbody GetRigidbody()
        {
            return _buildingComponent.GetRigidbody();
        }

        public void Dispose()
        {
            Object.Destroy(_buildingComponent.gameObject);
        }
    }
}