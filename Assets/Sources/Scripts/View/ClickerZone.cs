using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickerZone : MonoBehaviour, IPointerDownHandler
{
    public event Action Clicked;

    public void OnPointerDown(PointerEventData eventData)
    {
        Clicked?.Invoke();
    }
}
