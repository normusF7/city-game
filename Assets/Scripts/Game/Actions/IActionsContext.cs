using Core.Framework.StateMachine;

namespace Game.Actions
{
    public interface IActionsContext
    {
        IState CurrentState { get; }
        
        void ChangeState(IMutableState state);
    }
}