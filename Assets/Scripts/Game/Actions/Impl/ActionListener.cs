using System.Collections.Generic;
using Game.Actions.Handlers;
using Game.Physics;

namespace Actions.Impl
{
    public class ActionListener
    {
        private readonly IRaycaster _raycaster;
        private readonly IReadOnlyCollection<IActionHandler> _actionHandlers;

        public ActionListener(IRaycaster raycaster)
        {
            _raycaster = raycaster;
        }
    }
}
