using UnityEngine;

namespace Game.Camera
{
    public interface ICameraDecorator
    {
        Ray ScreenPointToRay(Vector3 position);
    }
}
