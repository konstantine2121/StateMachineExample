namespace StateMachineExample.Interfaces
{
    public interface ITransition
    {
        IState NextState { get; }

        bool CheckСondition();
    }
}
