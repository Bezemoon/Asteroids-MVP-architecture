using CodeBase.MVPArchitecture.Model;
using CodeBase.MVPArchitecture.Model.Ship;
using CodeBase.MVPArchitecture.View;

namespace CodeBase.MVPArchitecture.Presenter
{
    public class TeleportPresenter : IPresenter
    {
        private ITeleportable _model;
        private TeleportView _view;

        public TeleportPresenter(ITeleportable model, TeleportView view)
        {
            _model = model;
            _view = view;
            
            Enable();
        }

        public void Enable() => 
            _model.Teleported += _view.OnTeleport;

        public void Disable() => 
            _model.Teleported -= _view.OnTeleport;
    }
}