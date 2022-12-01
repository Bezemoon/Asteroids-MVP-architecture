using UnityEngine;

namespace Asteroids_2._0.CodeBase.Services.InputService
{
    public abstract class InputService : IInputService
    {
        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";
        
        public abstract Vector2 Axis { get;}

        protected Vector2 SimpleInputAxis() => 
            new Vector2(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));
    }
}