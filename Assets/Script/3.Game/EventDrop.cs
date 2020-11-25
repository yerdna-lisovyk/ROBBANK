using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventDrop : MonoBehaviour, IDropHandler,IPointerEnterHandler,IPointerExitHandler
{
    void IDropHandler.OnDrop(PointerEventData eventData)
    {
        Debug.Log(1);
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("OnPointerEnter");
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("OnPointerExit");
    }
}
