namespace Game.Grid.Data.Impl
{
    public class Cell : IMutableCell
    {
        private IBuilding _building;
        
        public IBuilding Building { get; set; }
    }
}