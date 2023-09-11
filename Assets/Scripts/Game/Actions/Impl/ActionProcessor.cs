using System.Collections.Generic;
using Game.Actions.Handlers;
using Game.Physics;
using Zenject;

namespace Game.Actions.Impl
{
    internal class ActionProcessor : IActionProcessor, ITickable
    {
        private readonly IRaycastService _raycastService;
        private readonly IReadOnlyCollection<IActionHandler> _actionHandlers;

        public ActionProcessor(IRaycastService raycastService, List<IActionHandler> actionHandlers)
        {
            _raycastService = raycastService;
            actionHandlers.Sort((x, y) => y.Priority.CompareTo(x.Priority));
            _actionHandlers = actionHandlers;
        }

        public void Tick()
        {
            Process();
        }

        private void Process()
        {
            foreach (var handle in _actionHandlers)
            {
                if (handle.Handle(_raycastService.CurrentHit))
                {
                    break;
                }
            }
        }
    }
}
