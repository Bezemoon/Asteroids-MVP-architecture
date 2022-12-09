using UnityEngine;

namespace CodeBase.Services.InputService
{
    public abstract class InputService : IInputService
    {
        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";
        private const string Gas = "Gas";
        
        public abstract Vector2 Axis { get;}

        protected Vector2 SimpleInputAxis() => 
            new Vector2(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));
    }
}