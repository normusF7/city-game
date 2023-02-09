namespace Core.Framework.StateMachine
{
    public interface IMutableState : IState
    {
        public void Begin();
        public void Update();
        //TODO: Use Dispose?
        public void End();
    }
}