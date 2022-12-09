using CodeBase.MVPArchitecture.Model;
using CodeBase.MVPArchitecture.Presenter.CollisionPresenters;
using CodeBase.MVPArchitecture.View;
using UnityEngine;

namespace CodeBase.MVPArchitecture.Presenter
{
    public class EnemyCollisionPresenter : CollisionPresenter
    {
        private const string PlayershipTag = "PlayerShip";
        private const string PlayerlaserTag = "PlayerLaser";
        
        private IHealth _health;
        
        public EnemyCollisionPresenter(IHealth health, CollisionObserver collisionObserver) : base(health, collisionObserver)
        {
            _health = health;
        }

        protected override void OnTriggerEnter(Collider2D collider2D)
        {
            if (collider2D.CompareTag(PlayershipTag) || collider2D.CompareTag(PlayerlaserTag)) 
                _health.TakeDamage();
        }
    }
}