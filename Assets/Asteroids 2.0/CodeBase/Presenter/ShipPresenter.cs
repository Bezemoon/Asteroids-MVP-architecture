using Asteroids_2._0.CodeBase.Model;
using Asteroids_2._0.CodeBase.View;

namespace Asteroids_2._0.CodeBase.Presenter
{
    public class ShipPresenter
    {
        private readonly Ship _model;
        private readonly ShipView _view;


        public ShipPresenter(Ship model, ShipView view)
        {
            _model = model;
            _view = view;
        }
    }
}
