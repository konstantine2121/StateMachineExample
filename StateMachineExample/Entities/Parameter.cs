using System;

namespace StateMachineExample.Entities
{
    public class Parameter 
    {       
        public event Action Changed;

        private object _value;

        public Parameter(string name)
        {
            Name = name;
        }

        public Parameter(string name, object initialValue) : this(name)
        {
            _value = initialValue;
            ValueType = initialValue.GetType();
        }

        public string Name { get; }

        public Type ValueType { get; private set; }
        
        public object Value
        {
            get 
            { 
                return _value; 
            }
            set 
            {
                if (_value.Equals(value))
                {
                    return;
                }

                ValueType = value.GetType();
                _value = value;
                Changed?.Invoke();
            }
        }
    }
}
