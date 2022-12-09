using CodeBase.Infrastructures.Services;
using CodeBase.MVPArchitecture.View;
using UnityEngine;

namespace CodeBase.Infrastructures.Factory
{
    public interface IGameFactory : IService
    {
        GameObject CreatePlayerShip();
        GameObject CreateAsteroid(Vector3 at);
        void CreateHud();

        TeleportView CreateTeleporter();
    }
}