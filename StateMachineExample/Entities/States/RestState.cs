namespace StateMachineExample.Entities
{
    public class RestState : BaseState
    {
        public const int TimeToRest = 4;

        private int _timeCounter = 0;

        public RestState(ParameterContainer parameterContainer): base (parameterContainer)
        {

        }

        public override void PerformState()
        {
            _timeCounter++;
            
            if (_timeCounter >= TimeToRest)
            {
                _timeCounter = 0;

                if (Parameters.TryGetParameter(StateMachine.Paremeters.Speed, out Parameter parameter) )
                {
                    parameter.Value = 1;
                }

                InvokeFinished();
            }
        }
    }
}
