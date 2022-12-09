using CodeBase.Extension;
using UnityEngine;

namespace CodeBase.MVPArchitecture.View
{
    public class TeleportView : MonoBehaviour
    {
        private Vector3 _offsetXBorder;
        private Vector3 _offsetYBorder;

        private void Awake()
        {
            Vector3 lowLeftPoint = new Vector2(0, 0).ViewportToWorld();
            Vector3 topRightPoint = new Vector2(1, 1).ViewportToWorld();

            _offsetXBorder = new Vector3(lowLeftPoint.x, topRightPoint.x, 0);
            _offsetYBorder = new Vector3(lowLeftPoint.y, topRightPoint.y, 0);
        }

        public void OnTeleport(Transform objectTransform, Vector3 size) => 
            objectTransform.position = GetViewportPosition(objectTransform.position, size);

        private Vector2 GetViewportPosition(Vector2 viewportPosition, Vector2 size) =>
            new Vector2(CalculateViewportOffset(viewportPosition.x, size.x / 2f, _offsetXBorder), 
                CalculateViewportOffset(viewportPosition.y, size.y / 2f, _offsetYBorder));

        private float CalculateViewportOffset(float viewportOffset, float halfSize, Vector3 offsetBorder)
        {
            if (OutOfLowBorder(viewportOffset + halfSize, offsetBorder.x))
                viewportOffset = offsetBorder.y + halfSize;
            else if (OutOfHighBorder(viewportOffset - halfSize, offsetBorder.y))
                viewportOffset = offsetBorder.x - halfSize;

            return viewportOffset;
        }

        private bool OutOfLowBorder(float objectPositionOffset, float borderValue) =>
            objectPositionOffset < borderValue;

        private bool OutOfHighBorder(float objectPositionOffset, float borderValue) =>
            objectPositionOffset > borderValue;
    }
}
