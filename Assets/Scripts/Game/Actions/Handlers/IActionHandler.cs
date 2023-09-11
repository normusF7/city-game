using UnityEngine;

namespace Game.Actions.Handlers
{
    internal interface IActionHandler
    {
        int Priority { get; }
        
        bool Handle(RaycastHit hit);
    }
}
