using Game.Camera;
using Game.Input.Impl;
using Game.Physics.Impl;
using UnityEngine;
using Zenject;

public class RootCoreInstaller : MonoInstaller
{
    [SerializeField]
    private Camera _camera;
    [SerializeField]
    private CameraControllerComponent _cameraController;

    public override void InstallBindings()
    {
        Container.BindInstance(_cameraController);

        Container.BindInstance(_camera);

        Container.BindInterfacesTo<InputService>()
            .AsSingle();

        Container.BindInterfacesTo<InputApi>()
            .AsSingle();

        Container.BindInterfacesTo<InputListener>()
            .AsSingle();

        Container.BindInterfacesTo<CameraDecorator>()
            .AsSingle();

        Container.BindInterfacesTo<CameraController>()
            .AsSingle();

        Container.BindInterfacesTo<Raycaster>()
            .AsSingle();
    }
}