using Game.Actions.StateMachine.Impl;
using UnityEngine;

namespace Game.Actions.Handlers.Impl
{
    public class ViewHandler : IActionHandler
    {
        private readonly IActionsContext _actionsContext;
        private readonly ViewingState.Factory _viewingStateFactory;

        public int Priority => 0;
        
        public ViewHandler(IActionsContext actionsContext, ViewingState.Factory viewingStateFactory)
        {
            _actionsContext = actionsContext;
            _viewingStateFactory = viewingStateFactory;
        }

        public bool Handle(RaycastHit hit)
        {
            if (_actionsContext.CurrentState is ViewingState)
            {
                return false;
            }
            
            if (_actionsContext.CurrentState is ViewingState)
            {
                return true;
            }

            _actionsContext.ChangeState(_viewingStateFactory.Create());
            return true;
        }
    }
}