using CodeBase.Services.InputService;
using UnityEngine;

namespace CodeBase.MVPArchitecture.Model.Ship
{
    public class ShipRotate : IRotatable
    {
        private const int _maxAngleRotation = 360;

        private readonly float _speedRotation = 350f;
        private readonly Transform _transform;
        private readonly IInputService _inputService;
        
        private float _currentAngle;

        public float CosCurrentAngle => Mathf.Cos(ConvertDegToRad(_currentAngle));

        public float SinCurrentAngle => Mathf.Sin(ConvertDegToRad(_currentAngle));

        public ShipRotate(Transform transform, IInputService inputService)
        {
            _transform = transform;
            _inputService = inputService;

            ResetCurrentAngle();
        }

        public void Rotate()
        {
            ChangeCurrentAngle();
            RotateShip();
        }

        private void ChangeCurrentAngle()
        {
            _currentAngle = CalculateCurrentAngle();
            
            if (GreaterFullRotation())
                ResetCurrentAngle();
        }

        private float CalculateCurrentAngle() => 
            _currentAngle - Mathf.Round(_inputService.Axis.x) * _speedRotation * Time.deltaTime;

        private bool GreaterFullRotation() => 
            _currentAngle >= _maxAngleRotation;

        private void ResetCurrentAngle() => 
            _currentAngle = 0;

        private void RotateShip() => 
            _transform.rotation = Quaternion.Euler(0, 0, _currentAngle);

        private float ConvertDegToRad(float angle) => 
            Mathf.Deg2Rad * angle;
    }
}