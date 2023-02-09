namespace Core.Framework.StateMachine
{
    public interface IStateMachine
    {
        IMutableState CurrentState { get; }
        
        void ChangeState(IMutableState state);
    }
}