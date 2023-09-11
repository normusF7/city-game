using Game.Buildings.Data.Impl;

namespace Game.Grid.Data
{
    public interface IPlacedBuilding
    {
        int Level { get; }
        public BuildingType Type { get; } 
        
        void Upgrade();
        bool CanBeMergedWith(IBuilding building);
    }
}