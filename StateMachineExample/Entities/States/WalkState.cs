using System;
using System.Drawing;

namespace StateMachineExample.Entities
{
    public class WalkState : BaseState
    {
        public const int WalkSpeed = 1;
        public const int HitChance = 10;

        private Point _directionDown = new Point(1, 0);

        private readonly Random _random = new Random();

        public WalkState(ParameterContainer parameterContainer): base (parameterContainer)
        {

        }

        public override void PerformState()
        {   
            if (GetHit())
            {
                if (Parameters.TryGetParameter(StateMachine.Paremeters.TakingDamage, out Parameter parameter))
                {
                    parameter.Value = true;
                }
                InvokeFinished();
            }
        }

        private bool GetHit()
        {
            var value = _random.Next(101);

            if (value < HitChance)
            {
                return true;
            }

            return false;
        }
    }
}
