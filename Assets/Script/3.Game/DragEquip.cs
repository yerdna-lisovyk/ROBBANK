using UnityEngine;
using UnityEngine.EventSystems;

public class DragEquip : MonoBehaviour, IEndDragHandler, IBeginDragHandler
{
    private CardInfo _item;
    private Card.NameEqupment _nameItem;

    public void OnBeginDrag(PointerEventData eventData)
    {
        _item = gameObject.GetComponent<CardInfo>();
        _nameItem = _item.GetCard.GetNameEqupment;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (_item.IsNull)
        {
            switch (_nameItem)
            {
                case Card.NameEqupment.BOOTS_OF_SPEED:
                    {
                        Destroy(_item.GetComponent<Boots.BootOfSpeed>());
                        Debug.Log("1");
                        break;
                    }
            }
        }
    }


}
