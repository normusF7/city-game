using System;

namespace Core.Framework.Data.Impl
{
    public class BindableProperty<T> : IMutableBindableProprty<T>
    {
        private T _value;
        private Action<T> _callbacks = delegate { };

        public BindableProperty()
        {
        }

        public BindableProperty(T value)
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

        public void Bind(Action<T> callback, bool initialInvoke = false)
        {
            _callbacks += callback;

            if (initialInvoke)
            {
                _callbacks(Value);
            }
        }

        public void UnBind(Action<T> callback)
        {
            _callbacks -= callback;
        }
    }
}
