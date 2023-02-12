using Core.Framework.StateMachine.Impl;
using Game.Actions;
using Game.Actions.Handlers.Impl;
using Game.Actions.Impl;
using Game.Actions.StateMachine.Impl;
using Game.Buildings;
using Game.Camera;
using Game.Cursor.Impl;
using Game.Debug.Impl;
using Game.Grid;
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
        
        Container.BindInterfacesTo<RaycastRepository>()
            .AsSingle();
        
        Container.BindInterfacesTo<RaycastApi>()
            .AsSingle();
        
        Container.BindInterfacesTo<PickupHandler>()
            .AsSingle();
        
        Container.BindInterfacesTo<ViewingHandler>()
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
        
        Container.BindInterfacesTo<GridService>()
            .AsSingle();
        
        Container.BindInterfacesTo<GridApi>()
            .AsSingle();

        Container.BindInterfacesTo<CursorService>()
            .AsSingle()
            .WithArguments(_cursorPrefab);
        
        Container.BindInterfacesTo<CursorApi>()
            .AsSingle();

        Container.BindFactory<Vector2Int, IBuilding, DraggingState, DraggingState.Factory>();
        
        Container.BindFactory<EmptyState, EmptyState.Factory>();
        
        Container.BindFactory<ViewingState, ViewingState.Factory>();

        var a = Container.BindIFactory<IBuilding>();
            var b = a.FromFactoryWithResult<BuildingFactory>();
             b.WithArguments(_buildingPrefab);

             Container.BindInterfacesTo<DebugBootsrapper>()
            .AsSingle();
    }
    
    public interface IMyFooFactory : IFactory<Foo>
    {
    }

    public class Foo
    {
        public class Factory : PlaceholderFactory<Foo>, IMyFooFactory
        {
        }
    }

    public class Runner : IInitializable
    {
        readonly IMyFooFactory _fooFactory;

        public Runner(IMyFooFactory fooFactory)
        {
            _fooFactory = fooFactory;
        }

        public void Initialize()
        {
            var foo = _fooFactory.Create();
            // ...
        }
    }
    
    public interface CustomBuildingFactory : IFactory<IBuilding>
     {
     }

    public class BuildingFactory : IFactory<IBuilding>
    {
        private readonly GameObject _prefab;
        private readonly IGridRepository _gridRepository;
             
        public BuildingFactory(GameObject prefab, IGridRepository gridRepository)
        {
            _prefab = prefab;
            _gridRepository = gridRepository;
        }

        public IBuilding Create()
        {
            var gameObject = Object.Instantiate(_prefab, Vector3.zero, Quaternion.Euler(new Vector3(-90, 0, 0)));
            return new Building(gameObject.GetComponent<BuildingComponent>());
        }
    }
}