using Core.Framework.StateMachine;
using Zenject;

namespace Game.Actions.StateMachine.Impl
{
    public class EmptyState : IMutableState
    {
        public void Begin()
        {
        }

        public void Update()
        {
        }

        public void End()
        {
        }
        
        public class Factory : PlaceholderFactory<EmptyState>
        {
        }
    }
}