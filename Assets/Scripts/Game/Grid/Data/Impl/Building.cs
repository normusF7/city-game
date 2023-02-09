using Game.Buildings;
using UnityEngine;
using Zenject;

namespace Game.Grid.Data.Impl
{
    public class Building : IBuilding
    {
        private readonly BuildingComponent _buildingComponent;
        
        public Building(BuildingComponent buildingComponent)
        {
            _buildingComponent = buildingComponent;
        }
        
        // public class Factory : PlaceholderFactory<IBuilding>, RootCoreInstaller.IBuildingFactory
        // {
        //     private readonly GameObject _prefab;
        //     private readonly IGridRepository _gridRepository;
        //     
        //     public Factory(GameObject prefab, IGridRepository gridRepository)
        //     {
        //         _prefab = prefab;
        //         _gridRepository = gridRepository;
        //     }
        // }

        public void SetPosition(Vector3 position)
        {
            _buildingComponent.transform.position = position;
        }
    }
}