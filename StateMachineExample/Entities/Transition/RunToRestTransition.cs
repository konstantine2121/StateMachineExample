using StateMachineExample.Interfaces;

namespace StateMachineExample.Entities
{
    public class RunToRestTransitionTransition : BaseTransition<RestState>
    {
        
        public RunToRestTransitionTransition(RestState target, ParameterContainer parameterContainer) : base(target, parameterContainer)
        {
        
        }

        public IState Target { get; }

        public override bool CheckСondition()
        {
            Parameter speed = null;

            if (Parameters.TryGetParameter(StateMachine.Paremeters.Speed, out speed))
            {
                if ((int)speed.Value < 1)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
