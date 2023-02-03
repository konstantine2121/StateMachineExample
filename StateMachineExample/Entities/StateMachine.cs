using StateMachineExample.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace StateMachineExample.Entities
{
    public class StateMachine
    {
        private readonly ParameterContainer _parameters;
        private readonly Dictionary< IState, IEnumerable<ITransition> > _stateGraph = new Dictionary<IState, IEnumerable<ITransition>>();

        private IState _currentState;

        public StateMachine()
        {
            _parameters = new ParameterContainer(GetParameters());

            InitializeStateGraph();

            _currentState = _stateGraph.Keys.First();
        }

        public void PerformState()
        {
            _currentState?.PerformState();            
        }

        private void OnStateFinished(IState state)
        {
            var transitions = _stateGraph[_currentState];

            foreach (var transition in transitions)
            {
                if (transition.CheckСondition())
                {
                    SetState(transition.NextState);
                }

                break;
            }
        }

        private void SetState(IState state)
        {
            _currentState = state;
        }

        private IEnumerable<Parameter> GetParameters()
        {
            yield return new Parameter(Paremeters.TakingDamage, false);
            yield return new Parameter(Paremeters.Speed, 5);
        }

        private void InitializeStateGraph()
        {
            _stateGraph.Clear();

            var walkState = new WalkState(_parameters);
            var restState = new RestState(_parameters);
            var runState = new RunAwayState(_parameters);

            var anyToRunTransition = new AnyToRunAwayTransition(runState, _parameters);
            var runToRestTransition = new RunToRestTransitionTransition(restState, _parameters);
            var restToWalkTransition = new RestToWalkTransition(walkState, _parameters);

            _stateGraph.Add(walkState,new ITransition[] { anyToRunTransition });
            _stateGraph.Add(restState, new ITransition[] { restToWalkTransition, anyToRunTransition });
            _stateGraph.Add(runState, new ITransition[] { runToRestTransition });

            foreach (var state in _stateGraph.Keys)
            {
                state.Finished += OnStateFinished;
            }
        }

        public class Paremeters
        {
            public const string TakingDamage = "TakingDamage";
            public const string Speed = "Speed";
        }
    }
}
