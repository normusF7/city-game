namespace Game.Grid.Data.Impl
{
    public interface IMutableCell : ICell
    {
        public IBuilding Building { get; set; }
    }
}