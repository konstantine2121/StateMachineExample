using StateMachineExample.Interfaces;

namespace StateMachineExample.Entities
{
    public class RestToWalkTransition : BaseTransition<WalkState>
    {
        
        public RestToWalkTransition(WalkState target, ParameterContainer parameterContainer) : base(target, parameterContainer)
        {
        
        }

        public IState Target { get; }

        public override bool CheckСondition()
        {
            Parameter speed = null;

            if (Parameters.TryGetParameter(StateMachine.Paremeters.Speed, out speed))
            {
                if ((int)speed.Value > 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
