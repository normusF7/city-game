using Game.Actions.StateMachine.Impl;
using UnityEngine;

namespace Game.Actions.Handlers.Impl
{
    public class PickupHandler : IActionHandler
    {
        private const float HoldTime = 0.5f;

        private readonly IActionsContext _actionsContext;
        
        private float _currentHoldTime;

        public int Priority => 1;
        
        public PickupHandler(IActionsContext actionsContext)
        {
            _actionsContext = actionsContext;
        }

        public bool Handle(RaycastHit hit)
        {
            if (!hit.transform || !hit.transform.CompareTag("Interactable"))
            {
                return false;
            }

            if (_actionsContext.CurrentState.GetType() == typeof(DraggingState))
            {
                return true;
            }

            _currentHoldTime += Time.deltaTime;

            if(_currentHoldTime >= HoldTime)
            {
                _actionsContext.ChangeState(new DraggingState(hit.transform.gameObject));
                return true;
            }

            return false;
        }
    }
}