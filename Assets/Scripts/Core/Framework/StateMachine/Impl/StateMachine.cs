using System;
using System.Collections.Generic;

namespace Core.Framework.StateMachine.Impl
{
    public class StateMachine : IStateMachine
    {
        private readonly IReadOnlyDictionary<Enum, IMutableState> _states;

        private IMutableState _currentState;

        public StateMachine(IMutableState currentState)
        {
            _currentState = currentState;
        }

        public IMutableState CurrentState => _currentState;

        public void ChangeState(IMutableState state)
        {
            _currentState.End();
            _currentState = state;
            _currentState.Begin();
        }
    }
}