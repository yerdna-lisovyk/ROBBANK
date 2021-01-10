using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragVoult : MonoBehaviour, IEndDragHandler
{
    public void OnEndDrag(PointerEventData eventData)
    {
        tag = "Voult";
    }
}
