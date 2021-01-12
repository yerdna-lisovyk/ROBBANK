using UnityEngine;
using UnityEngine.EventSystems;

public class DragVoult : MonoBehaviour, IEndDragHandler
{
    public void OnEndDrag(PointerEventData eventData)
    {
        tag = "Voult";
    }
}
