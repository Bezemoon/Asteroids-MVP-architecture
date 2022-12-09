using System.Collections.Generic;
using CodeBase.Logic;

namespace CodeBase.Infrastructures.PlayableObjectsStorage
{
    public class UpdateKeeper: IUpdateKeeper
    {
        private List<IUpdatable> _updatableObjects;

        public IReadOnlyList<IUpdatable> UpdatableObjects => _updatableObjects;

        public UpdateKeeper()
        {
            _updatableObjects = new List<IUpdatable>();
        }

        public void Add(IUpdatable updatableObject)
        {
            _updatableObjects.Add(updatableObject);
        }

        public void Remove(IUpdatable updatableObject)
        {
            _updatableObjects.Remove(updatableObject);
        }
    }

    
}