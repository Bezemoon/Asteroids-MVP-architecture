using UnityEngine;

namespace Asteroids_2._0.CodeBase.Services.InputService
{
    public class MobileInputService: InputService
    { 
        public override Vector2 Axis => SimpleInputAxis();
    }
}