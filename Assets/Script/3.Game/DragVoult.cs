using UnityEngine;
using UnityEngine.EventSystems;

public class DragVoult : MonoBehaviour, IEndDragHandler , IBeginDragHandler
{
    private CardInfo _item;
    private Card _card;
    public void OnBeginDrag(PointerEventData eventData)
    {
        _item = gameObject.GetComponent<CardInfo>();
        _card = _item.GetCard;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if(_item.GetCard != _card)
            tag = "Voult";
    }
}
