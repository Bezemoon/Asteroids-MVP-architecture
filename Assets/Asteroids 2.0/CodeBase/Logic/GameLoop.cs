using Asteroids_2._0.CodeBase.Infrastructures.Services;
using Asteroids_2._0.CodeBase.Model;
using Asteroids_2._0.CodeBase.Presenter;
using Asteroids_2._0.CodeBase.Services.InputService;
using Asteroids_2._0.CodeBase.View;
using UnityEngine;

namespace Asteroids_2._0.CodeBase.Logic
{
    public class GameLoop: MonoBehaviour
    {
        public ShipView View;

        private ShipPresenter _presenter;
        private Ship _model;

        private void Awake()
        {
            _model = new Ship(AllServices.Container.Single<IInputService>(), View.transform);
            _presenter = new ShipPresenter(_model, View);
        }

        private void Update()
        {
            _model.Update();
        }
    }
}