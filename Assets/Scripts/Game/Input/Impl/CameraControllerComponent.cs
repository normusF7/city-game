using Core.UnityEngine.Extensions;
using UnityEngine;

public class CameraControllerComponent : MonoBehaviour
{
    public void Move(Vector2 delta)
    {
        transform.position += delta.ToVector3XZ();
    }

    public void MoveTo(Vector2 position)
    {
        transform.position = position.ToVector3XZ();
    }
}
