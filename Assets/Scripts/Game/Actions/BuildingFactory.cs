// using Game.Buildings;
// using Game.Grid;
// using Game.Grid.Data;
// using Game.Grid.Data.Impl;
// using UnityEngine;
// using Zenject;
//
// namespace Game.Actions
// {
//     public class BuildingFactory : IFactory<IBuilding>
//     {
//         private readonly GameObject _prefab;
//         private readonly IGridRepository _gridRepository;
//             
//         public BuildingFactory(GameObject prefab, IGridRepository gridRepository)
//         {
//             _prefab = prefab;
//             _gridRepository = gridRepository;
//         }
//
//         public IBuilding Create()
//         {
//             var gameObject = Object.Instantiate(_prefab, Vector3.zero, Quaternion.identity);
//             return new Building(gameObject.GetComponent<BuildingComponent>());
//         }
//         
//     }
// }