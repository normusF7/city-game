using Assets.Scripts.Game.Actions.Impl;
using Game.Physics;
using Zenject;

namespace Game.Actions.Impl
{
    internal class ActionProcessor : IActionProcessor, ITickable
    {
        private readonly IRaycastApi _raycastApi;

        public ActionProcessor(IRaycastApi raycastApi)
        {
            _raycastApi = raycastApi;
        }

        public void Tick()
        {
            Process();
        }

        private void Process()
        {

        }
    }
}
