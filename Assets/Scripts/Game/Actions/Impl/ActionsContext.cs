using Core.Framework.StateMachine;
using Zenject;

namespace Game.Actions.Impl
{
    public class ActionsContext : IActionsContext, ITickable
    {
        private readonly IStateMachine _stateMachine;

        public IState CurrentState => _stateMachine.CurrentState;
        
        public ActionsContext(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        
        public void ChangeState(IMutableState state)
        {
            _stateMachine.ChangeState(state);
        }

        public void Tick()
        {
            _stateMachine.CurrentState.Update();
        }
    }
}