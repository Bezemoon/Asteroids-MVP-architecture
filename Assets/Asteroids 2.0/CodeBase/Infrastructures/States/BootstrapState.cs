using Asteroids_2._0.CodeBase.Infrastructures.SceneLoad;
using Asteroids_2._0.CodeBase.Infrastructures.Services;
using Asteroids_2._0.CodeBase.Services.InputService;
using UnityEngine;

namespace Asteroids_2._0.CodeBase.Infrastructures.States
{
    public class BootstrapState : IState
    {
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
            _sceneLoader.Load("Main", EnterLoadLevel);
        }

        public void Exit()
        {
        }

        private void RegistryServices()
        {
            _services.RegisterSingle<IInputService>(RegistryInputService());
        }

        private void EnterLoadLevel()
        {
            //_stateMachine.Enter<LoadResourceState>();
        }

        private IInputService RegistryInputService()
        {
            if (Application.isEditor)
                return new StandaloneInputService(new PlayerInputAction());

            return new MobileInputService();
        }
    }
}