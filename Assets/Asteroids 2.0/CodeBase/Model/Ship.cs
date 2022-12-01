using Asteroids_2._0.CodeBase.Services.InputService;
using UnityEngine;

namespace Asteroids_2._0.CodeBase.Model
{
    public class Ship
    {
        private const int _maxAngleRotation = 360;
        private readonly IInputService _inputService;
        private float _angleRotation;
        private float _speed = 4;
        private float _acceleration = 2;
        private float _inertia = 2;
        private float _speedRotation = 250;

        private Transform _transform;

        public Ship(IInputService inputService, Transform transform)
        {
            _inputService = inputService;
            _transform = transform;
        }

        private void Rotate()
        { 
            _angleRotation += -Mathf.Round(_inputService.Axis.x) * _speedRotation * Time.deltaTime;
            if (_angleRotation >= _maxAngleRotation) 
                _angleRotation = 0;
            
            _transform.rotation = Quaternion.Euler(0, 0, _angleRotation);    
        }

        public void Update()
        {
            Debug.Log(">>> Ship updated <<<");
            Rotate();
        }
        
    }
}

