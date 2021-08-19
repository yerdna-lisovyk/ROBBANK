using UnityEngine;
using UnityEngine.EventSystems;

public class DragEquip : MonoBehaviour, IEndDragHandler, IBeginDragHandler
{
    private CardInfo _item;
    private Card.NameEquipment _nameItem;

    public void OnBeginDrag(PointerEventData eventData)
    {
        _item = gameObject.GetComponent<CardInfo>();
        _nameItem = _item.GetCard.GetNameEquipment;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (_item.IsNull)
        {
            switch (_nameItem)
            {
                case Card.NameEquipment.BOOTS_OF_SPEED:
                    {
                        Destroy(_item.GetComponent<Boots.BootOfSpeed>());
                        break;
                    }
            }
        }
    }


}
