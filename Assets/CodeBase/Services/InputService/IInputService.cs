using CodeBase.Infrastructures.Services;
using UnityEngine;

namespace CodeBase.Services.InputService
{
    public interface IInputService : IService
    {
        Vector2 Axis { get; }
    }
}