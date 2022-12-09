using UnityEngine;

namespace CodeBase.Extension
{
    public static class Extension
    {
        public static Vector2 WorldToViewport(this Vector3 vector) => 
            Camera.main.WorldToViewportPoint(vector);

        public static Vector3 ViewportToWorld(this Vector2 vector) => 
            Camera.main.ViewportToWorldPoint(vector);
    }
}