using CodeBase.Services.InputService;
using UnityEngine;

namespace CodeBase.MVPArchitecture.Model.Ship
{
    public class ShipMove : IMovable
    {
        private readonly Transform _transform;
        private readonly IRotatable _shipRotate;
        private readonly IInputService _inputService;
        private readonly Vector2 _speedRange = new Vector2(0, 10f);
        private readonly float _acceleration = 20f;
        private readonly float _inertia = 10f;
        
        private float _currentSpeed;

        public ShipMove(Transform transform, IInputService inputService, IRotatable shipRotate)
        {
            _transform = transform;
            _shipRotate = shipRotate;
            _inputService = inputService;
        }

        public void Move()
        {
            ChangeSpeed();
            MoveShip();
        }

        private void ChangeSpeed() =>
            _currentSpeed = CanMove() ? Accelerate(_currentSpeed, _acceleration, _speedRange.y) 
                : Decelerate(_currentSpeed, _inertia, _speedRange.x);

        private bool CanMove() => 
            Mathf.Round(_inputService.Axis.y) > 0;


        private Vector3 GetDirection(float speed, float cos, float sin)
        {
            float offsetX = CalculateDistance(speed, cos);
            float offsetY = CalculateDistance(speed, sin);
            
            return new Vector3(offsetX, offsetY);
        }

        private float CalculateDistance(float speed, float angle) => 
            speed * Time.deltaTime * angle;

        private float Accelerate(float speed, float acceleration, float maxSpeed)
        {
            speed += acceleration * Time.deltaTime;
            
            if (speed >= maxSpeed) 
                speed = maxSpeed;
            
            return speed;
        }

        private float Decelerate(float speed, float inertia, float minSpeed)
        {
            speed -= inertia * Time.deltaTime;

            if (speed <= minSpeed)
                speed = minSpeed;

            return speed;
        }

        private void MoveShip() => 
            _transform.position += GetDirection(_currentSpeed, cos: _shipRotate.CosCurrentAngle, sin: _shipRotate.SinCurrentAngle);
    }
}