using UnityEngine;

namespace CodeBase.MVPArchitecture.Model.Enemy
{
    public class AsteroidMove : IMovable
    {
        private float _speed;
        private Vector2 _direction;
        private Transform _transform;

        public AsteroidMove(Transform transform)
        {
            _speed = 4;
            _direction = new Vector2(Random.Range(-1, 1), Random.Range(-1, 1));
            _transform = transform;
        }
        
        public void Move()
        {
            MoveAsteroid();
        }

        private void MoveAsteroid() => 
            _transform.position += GetDirection();

        private Vector3 GetDirection() => 
            _direction * _speed * Time.deltaTime;
    }
}