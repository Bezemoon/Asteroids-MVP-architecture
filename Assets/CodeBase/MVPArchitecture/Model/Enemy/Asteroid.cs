using System;
using CodeBase.Logic;
using CodeBase.MVPArchitecture.Model.Ship;
using UnityEngine;

namespace CodeBase.MVPArchitecture.Model.Enemy
{
    public class Asteroid : IUpdatable, ITeleportable, IModel
    {
        private Transform _transform;
        private IMovable _asteroidMove;
        private Vector2 _size;

        public event Action<Transform, Vector3> Teleported;

        public Asteroid(Transform transform, Vector2 size)
        {
            _transform = transform;
            _size = size;
            _asteroidMove = new AsteroidMove(_transform);
        }

        public void Update()
        {
            _asteroidMove.Move();
            Teleported?.Invoke(_transform, _size);
        }
    }
}