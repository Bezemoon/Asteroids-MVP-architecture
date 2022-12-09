using System.Collections;
using UnityEngine;

namespace CodeBase.Infrastructures
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}