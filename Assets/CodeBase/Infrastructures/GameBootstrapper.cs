using CodeBase.Infrastructures.States;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace CodeBase.Infrastructures
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] private GameRunner _gameRunner;
        
        private Game _game;
        
        private void Awake()
        {
            _game = new Game(this);
            _game.StateMachine.Enter<BootstrapState>();
            
            DontDestroyOnLoad(this);
        }
    }
}