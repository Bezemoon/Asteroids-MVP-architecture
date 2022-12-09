using System;
using UnityEngine;

namespace CodeBase.MVPArchitecture.View
{
    public class CollisionObserver : MonoBehaviour
    {
        public event Action<Collider2D> TriggerEntered;

        private void OnTriggerEnter2D(Collider2D other) => 
            TriggerEntered?.Invoke(other);
    }
}