using System;
using UnityEngine;

namespace CodeBase.MVPArchitecture.Model
{
    public interface ITeleportable
    {
        event Action<Transform, Vector3> Teleported;
    }
}