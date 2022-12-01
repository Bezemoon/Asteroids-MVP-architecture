namespace Asteroids_2._0.CodeBase.Infrastructures.States
{
    public interface IState : IExitableState
    {
        void Enter();
    }

    public interface IExitableState
    {
        void Exit();
    }
}