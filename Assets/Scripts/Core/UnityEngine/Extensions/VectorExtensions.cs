using UnityEngine;

namespace Core.UnityEngine.Extensions
{
    public static class VectorExtensions
    {
        public static Vector3 ToVector3XZ(this Vector2 vector2)
        {
            return new Vector3(vector2.x, 0, vector2.y);
        }
    }
}
