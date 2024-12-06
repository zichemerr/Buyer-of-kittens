using UnityEngine;

public static class CanvasPositioningExtensions
{
    public static Vector3 ScreenToCanvasPosition(this Canvas canvas, Vector2 screenPosition)
    {
        Vector3 position = Camera.main.ScreenToWorldPoint(screenPosition);

        return RectTransformUtility.WorldToScreenPoint(Camera.main, position);
    }
}