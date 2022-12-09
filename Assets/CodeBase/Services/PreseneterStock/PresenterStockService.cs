using System.Collections.Generic;
using CodeBase.MVPArchitecture.Model;
using CodeBase.MVPArchitecture.Model.Ship;
using CodeBase.MVPArchitecture.Presenter;
using UnityEngine;

namespace CodeBase.Services.PreseneterStock
{
    public class PresenterStockService : IPresenterStockService
    {
        private Dictionary<IModel, List<IPresenter>> _stock;

        public PresenterStockService()
        {
            _stock = new Dictionary<IModel, List<IPresenter>>();
        }

        public void Add(IModel model, IPresenter presenter)
        {
            var presenters = GetPresenters(model);

            presenters.Add(presenter);
            
            _stock[model] = presenters;
            
            Debug.Log(_stock.Count);
            Debug.Log(presenters.Count);
        }

        private List<IPresenter> GetPresenters(IModel model)
        {
            List<IPresenter> presenters = new List<IPresenter>();

            if (_stock.ContainsKey(model))
                presenters = _stock[model];
            
            return presenters;
        }

        public void Remove(IModel model)
        {
            foreach (IPresenter presenter in _stock[model]) 
                presenter.Disable();
        }
    }
}