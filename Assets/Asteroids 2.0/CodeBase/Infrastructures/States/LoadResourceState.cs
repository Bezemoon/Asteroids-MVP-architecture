using Asteroids_2._0.CodeBase.Infrastructures.SceneLoad;

namespace Asteroids_2._0.CodeBase.Infrastructures.States
{
    public class LoadResourceState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;

        public LoadResourceState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            
        }

        public void Exit()
        {
            
        }
    }
}