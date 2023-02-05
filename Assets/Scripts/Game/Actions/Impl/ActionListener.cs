using Game.Physics;

namespace Actions.Impl
{
    public class ActionListener
    {
        private readonly IRaycaster _raycaster;

        public ActionListener(IRaycaster raycaster)
        {
            _raycaster = raycaster;
        }


    }
}
