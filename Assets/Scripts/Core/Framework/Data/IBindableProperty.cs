using System;

namespace Core.Framework.Data
{
    public interface IBindableProperty<T>
    {
        public T Value { get; }
        public void Bind(Action<T> callback, bool initialInvoke = false);
        public void UnBind(Action<T> callback);
    }
}
