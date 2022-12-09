using CodeBase.Infrastructures.AssetManagement;
using CodeBase.Infrastructures.Factory;
using CodeBase.Infrastructures.PlayableObjectsStorage;
using CodeBase.Infrastructures.Services;
using CodeBase.Services.InputService;
using CodeBase.Services.PreseneterStock;
using UnityEngine;

namespace CodeBase.Infrastructures.States
{
    public class BootstrapState : IState
    {
        private const string InitialScene = "Initial";
        private const string MainScene = "Main";

        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly AllServices _services;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, AllServices services)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _services = services;
            
            RegistryServices();
        }

        public void Enter()
        {
            _sceneLoader.Load(InitialScene, EnterLoadLevel);
        }

        public void Exit()
        {
        }

        private void RegistryServices()
        {
            _services.RegisterSingle<IInputService>(RegistryInputService());
            _services.RegisterSingle<IAsset>(new AssetProvider());
            _services.RegisterSingle<IGameFactory>(new GameFactory(_services.Single<IAsset>()));
            _services.RegisterSingle<IUpdateKeeper>(new UpdateKeeper());
            _services.RegisterSingle<IPresenterStockService>(new PresenterStockService());
        }

        private void EnterLoadLevel()
        {
            _stateMachine.Enter<LoadResourceState, string>(MainScene);
        }

        private IInputService RegistryInputService()
        {
            if (Application.isEditor)
                return new StandaloneInputService(new PlayerInputAction());

            return new MobileInputService();
        }
    }
}