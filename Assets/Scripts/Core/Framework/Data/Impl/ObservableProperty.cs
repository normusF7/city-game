using System;

namespace Core.Framework.Data.Impl
{
    public class ObservableProperty<T> : IMutableObservableProperty<T>
    {
        private T _value;
        private Action<T> _callbacks = delegate { };

        public ObservableProperty()
        {
        }

        public ObservableProperty(T value)
        {
            Value = value;
        }

        public T Value
        {
            get => _value;

            set
            {
                if (_value.Equals(value))
                {
                    return;
                }

                _value = value;
                _callbacks(value);
            }
        }

        public void Observe(Action<T> callback, bool initialInvoke = false)
        {
            _callbacks += callback;

            if (initialInvoke)
            {
                _callbacks(Value);
            }
        }

        public void UnObserve(Action<T> callback)
        {
            _callbacks -= callback;
        }
    }
}
