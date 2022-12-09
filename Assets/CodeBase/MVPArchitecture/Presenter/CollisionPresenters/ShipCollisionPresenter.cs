using CodeBase.MVPArchitecture.Model;
using CodeBase.MVPArchitecture.View;
using UnityEngine;

namespace CodeBase.MVPArchitecture.Presenter.CollisionPresenters
{
    public class ShipCollisionPresenter : CollisionPresenter
    {
        private const string EnemyTag = "Enemy";
        private const string EnemylaserTag = "EnemyLaser";
        
        private readonly IHealth _health;

        public ShipCollisionPresenter(IHealth health, CollisionObserver collisionObserver) : base(health, collisionObserver)
        {
            _health = health;
        }

        protected override void OnTriggerEnter(Collider2D collider2D)
        {
            if(collider2D.CompareTag(EnemyTag) || collider2D.CompareTag(EnemylaserTag))
                _health.TakeDamage();
        }
    }
}