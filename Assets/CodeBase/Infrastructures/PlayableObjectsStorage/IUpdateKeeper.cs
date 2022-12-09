using System.Collections.Generic;
using CodeBase.Infrastructures.Services;
using CodeBase.Logic;

namespace CodeBase.Infrastructures.PlayableObjectsStorage
{
    public interface IUpdateKeeper : IService
    {
        IReadOnlyList<IUpdatable> UpdatableObjects { get; }

        void Add(IUpdatable updatableObject);

        void Remove(IUpdatable updatableObject);
    }
}