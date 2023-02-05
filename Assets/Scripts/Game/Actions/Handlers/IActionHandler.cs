using Game.Actions;

namespace Assets.Scripts.Game.Actions.Handlers
{
    internal interface IActionHandler
    {
        public bool Handle(ActionContext context);
    }
}
