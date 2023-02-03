using StateMachineExample.Interfaces;
using System;

namespace StateMachineExample.Entities
{
    public abstract class BaseState : IState
    {
        public event Action<IState> Finished;

        protected readonly ParameterContainer Parameters;

        public BaseState(ParameterContainer parameterContainer)
        {
            Parameters = parameterContainer;
        }

        public abstract void PerformState();

        protected void InvokeFinished()
        {
            Finished?.Invoke(this);
        }
    }
}
