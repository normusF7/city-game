namespace Core.Framework.Data
{
    public interface IMutableObservableProperty<T> : IObservableProperty<T>
    {
        public new T Value { get; set; }
    }
}
