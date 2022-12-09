using CodeBase.Infrastructures.Services;
using CodeBase.MVPArchitecture.Model;
using CodeBase.MVPArchitecture.Model.Ship;
using CodeBase.MVPArchitecture.Presenter;

namespace CodeBase.Services.PreseneterStock
{
    public interface IPresenterStockService : IService
    {
        void Add(IModel model, IPresenter presenter);
        void Remove(IModel model);
    }
}