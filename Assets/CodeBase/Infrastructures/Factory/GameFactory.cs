using CodeBase.Infrastructures.AssetManagement;
using CodeBase.MVPArchitecture.View;
using UnityEngine;

namespace CodeBase.Infrastructures.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAsset _assets;

        public GameFactory(IAsset assets)
        {
            _assets = assets;
        }

        public GameObject CreatePlayerShip() =>
            _assets.Instantiate(AssetPath.PlayerShipPath, Vector3.zero);

        public void CreateHud() =>
            _assets.Instantiate(AssetPath.HudPath);

        public TeleportView CreateTeleporter() => 
            _assets.Instantiate(AssetPath.TeleporterPath).GetComponent<TeleportView>();

        public GameObject CreateAsteroid(Vector3 at) => 
            _assets.Instantiate(AssetPath.AsteroidT1Path, at);
    }
}

