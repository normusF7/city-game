using Core.Framework.StateMachine.Impl;
using Game.Actions.Handlers.Impl;
using Game.Actions.Impl;
using Game.Actions.StateMachine.Impl;
using Game.Buildings.Impl;
using Game.Camera;
using Game.Cursor.Impl;
using Game.Debug.Impl;
using Game.Grid.Data;
using Game.Grid.Data.Impl;
using Game.Grid.Impl;
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
    [SerializeField]
    private GameObject _buildingPrefab;
    [SerializeField]
    private GameObject _cursorPrefab;
    [SerializeField]
    private HighlightColorLibrary _highlightColorLibrary;
    [SerializeField]
    private MeshRenderer _gridRenderer;

    public override void InstallBindings()
    {
        BindMisc();
        BindInstances();
        BindServices();
        BindFactories();
    }

    private void BindMisc()
    {
        Container.BindInterfacesTo<InputListener>()
            .AsSingle();

        Container.BindInterfacesTo<CameraDecorator>()
            .AsSingle();

        Container.BindInterfacesTo<Raycaster>()
            .AsSingle();
        
        Container.BindInterfacesTo<RaycastRepository>()
            .AsSingle();

        Container.BindInterfacesTo<PickupHandler>()
            .AsSingle();
        
        Container.BindInterfacesTo<ViewHandler>()
            .AsSingle();
        
        Container.BindInterfacesTo<ActionProcessor>()
            .AsSingle();
    
        Container.BindInterfacesTo<StateMachine>()
            .AsSingle();
        
        Container.BindInterfacesTo<ViewingState>()
            .AsTransient();
        
        Container.BindInterfacesTo<ActionsContext>()
            .AsSingle();
        
        Container.BindInterfacesTo<GridRepository>()
            .AsSingle();

        Container.BindInterfacesTo<GridRenderer>()
            .AsSingle()
            .WithArguments(_highlightColorLibrary, _gridRenderer.material);

        Container.BindInterfacesTo<DebugBootstrapper>().AsSingle();
    }

    private void BindInstances()
    {
        Container.BindInstance(_cameraController);

        Container.BindInstance(_camera);
    }

    private void BindServices()
    {
        Container.BindInterfacesTo<InputService>()
            .AsSingle();
        
        Container.BindInterfacesTo<RaycastService>()
            .AsSingle();
        
        Container.BindInterfacesTo<GridService>()
            .AsSingle();

        Container.BindInterfacesTo<CursorService>()
            .AsSingle()
            .WithArguments(_cursorPrefab);
    }

    private void BindFactories()
    {
        Container.BindFactory<Vector2Int, IBuilding, DraggingState, DraggingState.Factory>();
        
        Container.BindFactory<EmptyState, EmptyState.Factory>();
        
        Container.BindFactory<ViewingState, ViewingState.Factory>();

        Container.BindIFactory<IBuilding>().FromFactoryWithResult<BuildingFactory>().WithArguments(_buildingPrefab);
    }
}