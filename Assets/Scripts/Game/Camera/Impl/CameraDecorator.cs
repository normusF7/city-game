using UnityEngine;

namespace Game.Camera
{
    public class CameraDecorator : ICameraDecorator
    {
        private readonly UnityEngine.Camera _camera;

        public CameraDecorator(UnityEngine.Camera camera)
        {
            _camera = camera;
        }

        public Ray ScreenPointToRay(Vector3 position)
        {
            return _camera.ScreenPointToRay(position);
        }
    }
}
