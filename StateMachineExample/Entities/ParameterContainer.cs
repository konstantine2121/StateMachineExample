using System;
using StateMachineExample.Interfaces;
using System.Collections.Generic;

namespace StateMachineExample.Entities
{
    public class ParameterContainer
    {
        public event Action ValueChanged;

        private readonly Dictionary<string, Parameter> _parameters = new Dictionary<string, Parameter>();

        public ParameterContainer(IEnumerable<Parameter> parameters)
        {
            foreach (var pameter in parameters)
            {
                if (_parameters.ContainsKey(pameter.Name))
                {
                    throw new InvalidOperationException("Имя параметра должно быть уникальным.");
                }

                _parameters.Add(pameter.Name, pameter);

                pameter.Changed += OnValueChanged;
            }
        }

        public bool TryGetParameter(string name, out Parameter paremeter)
        {
            if (_parameters.ContainsKey(name))
            {
                paremeter = _parameters[name];
                return true;
            }

            paremeter = null;
            return false;
        }

        private void OnValueChanged()
        {
            ValueChanged?.Invoke();
        }
    }
}
