using CodeBase.Infrastructures.Factory;
using CodeBase.Infrastructures.PlayableObjectsStorage;
using CodeBase.MVPArchitecture.Model.Enemy;
using CodeBase.MVPArchitecture.Model.Ship;
using CodeBase.MVPArchitecture.Presenter;
using CodeBase.MVPArchitecture.Presenter.CollisionPresenters;
using CodeBase.MVPArchitecture.View;
using CodeBase.Services.InputService;
using CodeBase.Services.PreseneterStock;
using UnityEngine;

namespace CodeBase.Infrastructures.States
{
    public class LoadResourceState : IPayloadedState<string>
    {
        private const string EnemySpawnPoint = "EnemySpawnPoint";
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly IGameFactory _gameFactory;
        private readonly IInputService _inputService;
        private readonly IUpdateKeeper _updateKeeper;
        private readonly IPresenterStockService _presenterStockService;

        public LoadResourceState(GameStateMachine stateMachine, SceneLoader sceneLoader, IGameFactory gameFactory, IInputService inputService, IUpdateKeeper updateKeeper, IPresenterStockService presenterStockService)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _gameFactory = gameFactory;
            _inputService = inputService;
            _updateKeeper = updateKeeper;
            _presenterStockService = presenterStockService;
        }

        public void Enter(string payload)
        {
            _sceneLoader.Load("Main", OnLoaded);
        }

        private void OnLoaded()
        {
            InitGameWorld();
        }

        private void InitGameWorld()
        {
            TeleportView teleport = _gameFactory.CreateTeleporter();
            
            GameObject playerShip = _gameFactory.CreatePlayerShip();
            GameObject enemyAsteroid = _gameFactory.CreateAsteroid(FindEnemySpawnPoint());
            

            _updateKeeper.Add(InitializeShipMVP(playerShip, teleport));
            _updateKeeper.Add(InitializeAsteroid(enemyAsteroid, teleport));
            
            _gameFactory.CreateHud();
        }

        private Vector3 FindEnemySpawnPoint() => 
            GameObject.FindGameObjectWithTag(EnemySpawnPoint).transform.position;

        private Asteroid InitializeAsteroid(GameObject enemyAsteroid, TeleportView view)
        {
            Asteroid model = CreateAsteroid(enemyAsteroid);
            _presenterStockService.Add(model,new TeleportPresenter(model,view));
            return model;
        }

        private Asteroid CreateAsteroid(GameObject gameObject) => 
            new(gameObject.transform, GetSize(gameObject));

        private Ship InitializeShipMVP(GameObject playerShip, TeleportView view)
        {
            Ship model = CreateShip(playerShip, _inputService);
            _presenterStockService.Add(model, new TeleportPresenter(model, view));
            _presenterStockService.Add(model, new ShipCollisionPresenter(model.ShipHealth, playerShip.GetComponent<CollisionObserver>()));
            
            return model;
        }

        private Ship CreateShip(GameObject gameObject, IInputService inputService) =>
            new(inputService, gameObject, GetSize(gameObject));

        private Vector2 GetSize(GameObject gameObject) => 
            gameObject.GetComponentInChildren<SpriteRenderer>().size;

        public void Exit()
        {
        }
    }
}