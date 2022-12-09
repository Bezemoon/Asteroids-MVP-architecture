using System;

namespace CodeBase.MVPArchitecture.Model.Ship
{
    public class ShipHealth : IHealth
    {
        private int _health;

        public int Health => _health;

        public event Action HealthChanged;

        public ShipHealth(int health)
        { 
            _health = health;
        }

        public void TakeDamage()
        {
            if (_health <= 0)
                return;

            _health--;

            HealthChanged?.Invoke();
        }
    }
}
