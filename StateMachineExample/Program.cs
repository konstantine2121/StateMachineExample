using StateMachineExample.Entities;

namespace StateMachineExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var stateMachine = new StateMachine();

            while (true)
            {
                stateMachine.PerformState();
            }

        }
    }
}
