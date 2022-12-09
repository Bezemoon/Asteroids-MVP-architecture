using System;
using CodeBase.Logic;
using CodeBase.Services.InputService;
using UnityEngine;

namespace CodeBase.MVPArchitecture.Model.Ship
{
    public class Ship : IUpdatable, ITeleportable, IModel
    {
        private readonly Vector2 _size;
        private readonly Transform _transform;
        private readonly IInputService _inputService;
        private readonly IRotatable _shipRotate;
        private readonly IMovable _shipMove;
        private readonly IHealth _shipHealth;
        private readonly ShipDeath _shipDeath;

        public IHealth ShipHealth => _shipHealth;
        public ShipDeath ShipDeath => ShipDeath;

        public event Action<Transform, Vector3> Teleported;

        public Ship(IInputService inputService, GameObject gameObject, Vector2 size)
        {
            _inputService = inputService;
            _transform = gameObject.transform;
            _size = size;


            _shipRotate = new ShipRotate(_transform, _inputService);
            _shipMove = new ShipMove(_transform, _inputService, _shipRotate);
            _shipHealth = new ShipHealth(5);
            _shipDeath = new ShipDeath(_shipHealth, gameObject);
        }

        public void Update()
        {
            _shipRotate.Rotate();
            _shipMove.Move();
            Teleported?.Invoke(_transform, _size);
        }
    }
}

