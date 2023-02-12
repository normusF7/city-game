using Game.Actions.StateMachine.Impl;
using UnityEngine;

namespace Game.Actions.Handlers.Impl
{
    public class ViewingHandler : IActionHandler
    {
        private readonly IActionsContext _actionsContext;
        private readonly ViewingState.Factory _viewingStateFactory;

        public ViewingHandler(IActionsContext actionsContext, ViewingState.Factory viewingStateFactory)
        {
            _actionsContext = actionsContext;
            _viewingStateFactory = viewingStateFactory;
        }

        public int Priority => 0;
        public bool Handle(RaycastHit hit)
        {
            if (_actionsContext.CurrentState.GetType() == typeof(ViewingState))
            {
                return false;
            }
            
            if (_actionsContext.CurrentState.GetType() == typeof(ViewingState))
            {
                return true;
            }

            _actionsContext.ChangeState(_viewingStateFactory.Create());
            return true;
        }
    }
}