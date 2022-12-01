using Asteroids_2._0.CodeBase.Infrastructures.Services;
using UnityEngine;

namespace Asteroids_2._0.CodeBase.Services.InputService
{
    public interface IInputService : IService
    {
        Vector2 Axis { get; }
    }
}