using UnityEngine;

namespace Asteroids_2._0.CodeBase.Services.InputService
{
    public class StandaloneInputService : InputService
    {
        private readonly PlayerInputAction _playerInputAction;

        public StandaloneInputService(PlayerInputAction playerInputAction)
        {
            _playerInputAction = playerInputAction;
            Enable();
        }

        public void Enable()
        {
            _playerInputAction.Enable();
        }

        public void Disable()
        {
            _playerInputAction.Disable();
        }
        
        public override Vector2 Axis
        {
            get
            {
                Vector2 axis = SimpleInputAxis();

                if (axis == Vector2.zero)
                    axis = UnityInputAxis();

                return axis;
            }
        }
        
        public Vector2 UnityInputAxis() => 
            _playerInputAction.Player.Rotate.ReadValue<Vector2>();
    }
}