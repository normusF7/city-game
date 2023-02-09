using Core.Framework.StateMachine;
using UnityEngine;

namespace Game.Actions.StateMachine.Impl
{
    public class DraggingState : IMutableState
    {
        private readonly GameObject _draggedObject;
        
        public DraggingState(GameObject draggedObject)
        {
            _draggedObject = draggedObject;
        }

        public void Begin()
        {
            UnityEngine.Debug.Log("Start dragging");
        }

        public void Update()
        {
            UnityEngine.Debug.Log("Im dragging");
        }

        public void End()
        {
        }
    }
}