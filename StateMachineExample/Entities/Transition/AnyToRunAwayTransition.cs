using StateMachineExample.Interfaces;

namespace StateMachineExample.Entities
{
    public class AnyToRunAwayTransition : BaseTransition<RunAwayState>
    {
        
        public AnyToRunAwayTransition(RunAwayState target, ParameterContainer parameterContainer) : base(target, parameterContainer)
        {
        
        }

        public override bool CheckСondition()
        {
            Parameter takenDamage = null;

            if (Parameters.TryGetParameter(StateMachine.Paremeters.TakingDamage, out takenDamage))
            {
                if ((bool) takenDamage.Value == true)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
