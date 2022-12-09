using CodeBase.MVPArchitecture.Model;
using CodeBase.MVPArchitecture.View;
using UnityEngine;

namespace CodeBase.MVPArchitecture.Presenter.CollisionPresenters
{
    public abstract class CollisionPresenter : IPresenter
    {
        private readonly CollisionObserver _collisionObserver;
        
        public CollisionPresenter(IHealth health, CollisionObserver collisionObserver)
        {
            _collisionObserver = collisionObserver;
            Enable();
        }
        
        public void Enable() => 
            _collisionObserver.TriggerEntered += OnTriggerEnter;

        public void Disable() => 
            _collisionObserver.TriggerEntered -= OnTriggerEnter;

        protected abstract void OnTriggerEnter(Collider2D collider2D);
    }
}