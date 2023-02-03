using System;

namespace StateMachineExample.Interfaces
{
    public interface IState
    {
        event Action<IState> Finished;

        void PerformState();
    }
}
