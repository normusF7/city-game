using System.Collections.Generic;
using Assets.Scripts.Game.Actions.Impl;
using Game.Actions.Handlers;
using Game.Physics;
using Zenject;

namespace Game.Actions.Impl
{
    internal class ActionProcessor : IActionProcessor, ITickable
    {
        private readonly IRaycastApi _raycastApi;
        private readonly IReadOnlyCollection<IActionHandler> _actionHandlers;

        public ActionProcessor(IRaycastApi raycastApi, List<IActionHandler> actionHandlers)
        {
            _raycastApi = raycastApi;
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
                if (handle.Handle(_raycastApi.currentHit))
                {
                    break;
                }
            }
        }
    }
}
