using Game.Grid.Data;
using Game.Grid.Data.Impl;
using UnityEngine;
using Zenject;

namespace Game.Buildings.Impl
{
    public class BuildingFactory : IFactory<IBuilding>
    {
        private readonly GameObject _prefab;

        public BuildingFactory(GameObject prefab)
        {
            _prefab = prefab;
        }

        public IBuilding Create()
        {
            var gameObject = Object.Instantiate(_prefab, Vector3.zero, Quaternion.Euler(new Vector3(-90, 0, 0)));
            return new Building(gameObject.GetComponent<BuildingComponent>());
        }
    }
}
