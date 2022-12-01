using Asteroids_2._0.CodeBase.Infrastructures.SceneLoader;
using Asteroids_2._0.CodeBase.Infrastructures.Services;
using Asteroids_2._0.CodeBase.Infrastructures.States;

namespace Asteroids_2._0.CodeBase.Infrastructures
{
    public class Game
    {
        public GameStateMachine StateMachine;

        public Game(ICoroutineRunner coroutineRunner)
        {
            StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), AllServices.Container);
        }
    }
}