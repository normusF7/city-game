using Game.Grid;
using Game.Grid.Data;
using UnityEngine;
using Zenject;

namespace Game.Debug.Impl
{
    public class DebugBootsrapper : IDebugBootstrapper, IInitializable
    {
        private readonly IGridRepository _gridRepository;
        private readonly IFactory<IBuilding> _buildingFactory;

        public DebugBootsrapper(IGridRepository gridRepository, IFactory<IBuilding> buildingFactory)
        {
            _gridRepository = gridRepository;
            _buildingFactory = buildingFactory;
        }
        
        public void Initialize()
        {
            _gridRepository.TrySetBuilding(_buildingFactory.Create(), Vector2Int.zero);
        }
    }
}