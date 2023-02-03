using StateMachineExample.Interfaces;

namespace StateMachineExample.Entities
{
    public abstract class BaseTransition<T> : ITransition
        where T : IState
    {
        protected ParameterContainer Parameters;

        public BaseTransition(T target, ParameterContainer parameterContainer)
        {
            NextState = target;
            Parameters = parameterContainer;
        }

        public IState NextState { get; }

        public abstract bool CheckСondition();
    }
}
