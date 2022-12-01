using System.Collections;
using UnityEngine;

namespace Asteroids_2._0.CodeBase.Infrastructures.SceneLoader
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}