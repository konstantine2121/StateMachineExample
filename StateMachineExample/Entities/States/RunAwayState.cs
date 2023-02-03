using System;
using System.Drawing;

namespace StateMachineExample.Entities
{
    public class RunAwayState : BaseState
    {
        public const int RunSpeed = 5;
        public const int MaxStamina = 3;
        public const int HitChance = 10;

        private int _stamina = MaxStamina;
        private Point _directionUp = new Point(1, 0);

        private readonly Random _random = new Random();

        public RunAwayState(ParameterContainer parameterContainer): base (parameterContainer)
        {

        }

        public override void PerformState()
        {
            _stamina--;

            if (_stamina <= 0)
            {
                _stamina = MaxStamina;

                if (Parameters.TryGetParameter(StateMachine.Paremeters.Speed, out Parameter parameter))
                {
                    parameter.Value = 0;
                }

                InvokeFinished();
            }
        }

    }
}
