using System;
using UnityEngine;

namespace CodeBase.MVPArchitecture.Model.Ship
{
    public class ShipDeath
    {
        private readonly IHealth _playerShipHealth;

        public event Action<int> Dead;

        public ShipDeath(IHealth playerShipHealth, GameObject playerShip)
        {
            _playerShipHealth = playerShipHealth;

            _playerShipHealth.HealthChanged += Die;
        }

        private void Die()
        {
            Dead?.Invoke(_playerShipHealth.Health);
        }
    }
}