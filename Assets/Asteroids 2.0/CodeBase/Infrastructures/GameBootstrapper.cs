using Asteroids_2._0.CodeBase.Infrastructures.SceneLoader;
using Asteroids_2._0.CodeBase.Infrastructures.States;
using UnityEngine;

namespace Asteroids_2._0.CodeBase.Infrastructures
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        private Game _game;
        
        private void Awake()
        {
            _game = new Game(this);
            _game.StateMachine.Enter<BootstrapState>();
            
            DontDestroyOnLoad(this);
        }
    }
}