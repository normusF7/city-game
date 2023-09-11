namespace Game.Grid.Data
{
    public interface IMutableCell : ICell
    {
        public new IBuilding Building { get; set; }
    }
}