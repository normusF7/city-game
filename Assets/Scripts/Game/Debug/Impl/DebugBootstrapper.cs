using Game.Grid;
using Game.Grid.Data;
using UnityEngine;
using Zenject;

namespace Game.Debug.Impl
{
    public class DebugBootstrapper : IDebugBootstrapper, IInitializable
    {
        private readonly IGridRepository _gridRepository;
        private readonly IFactory<IBuilding> _buildingFactory;

        public DebugBootstrapper(IGridRepository gridRepository, IFactory<IBuilding> buildingFactory)
        {
            _gridRepository = gridRepository;
            _buildingFactory = buildingFactory;
        }
        
        public void Initialize()
        {
            _gridRepository.TrySetBuilding(_buildingFactory.Create(), Vector2Int.zero);
            _gridRepository.TrySetBuilding(_buildingFactory.Create(), new Vector2Int(0, 1));
            _gridRepository.TrySetBuilding(_buildingFactory.Create(), new Vector2Int(0, 2));
            _gridRepository.TrySetBuilding(_buildingFactory.Create(), new Vector2Int(0, 3));
        }
    }
}