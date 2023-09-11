using System;

namespace Core.Framework.Data
{
    public interface IObservableProperty<T>
    {
        public T Value { get; }
        public void Observe(Action<T> callback, bool initialInvoke = false);
        public void UnObserve(Action<T> callback);
    }
}
