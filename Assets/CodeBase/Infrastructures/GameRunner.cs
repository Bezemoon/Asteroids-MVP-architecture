using CodeBase.Infrastructures.PlayableObjectsStorage;
using CodeBase.Infrastructures.Services;
using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Infrastructures
{
    public class GameRunner : MonoBehaviour
    {
        private IUpdateKeeper _updateKeeper;
        
        private void Awake() => 
            _updateKeeper = AllServices.Container.Single<IUpdateKeeper>();

        private void Update()
        {
            foreach (IUpdatable updatableObject in _updateKeeper.UpdatableObjects) 
                updatableObject.Update();
        }
    }
}