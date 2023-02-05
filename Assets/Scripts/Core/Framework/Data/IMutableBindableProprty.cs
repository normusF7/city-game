namespace Core.Framework.Data
{
    public interface IMutableBindableProprty<T> : IBindableProperty<T>
    {
        public new T Value { get; set; }
    }
}
