using UnityEngine;
using UnityEngine.EventSystems;

public class TrapDrop : MonoBehaviour, IDropHandler
{
    private TimeBar _time;

    private void Awake()
    {
        _time = GameObject.Find("TimeBar").GetComponent<TimeBar>();
        
    }
    void IDropHandler.OnDrop(PointerEventData eventData)
    {
        if (!eventData.pointerDrag.GetComponent<CardInfo>().IsNull)
        {
            if (!_time.IsStep && eventData.pointerDrag.GetComponent<CardInfo>().IsTrap)
            {
                // _time.SetStep(true);
                Debug.Log(eventData.pointerDrag.GetComponent<CardInfo>().GetCard.GetTypeTrap);
                switch(eventData.pointerDrag.GetComponent<CardInfo>().GetCard.GetTypeTrap)
                {
                    case Card.TypeTrap.CHIKA:
                        {
                            gameObject.AddComponent<ChikaTrap>();
                            break;
                        }
                }
                eventData.pointerDrag.transform.localPosition = Vector3.zero;
                eventData.pointerDrag.GetComponent<CardInfo>().SetCardInfo(null);
            }
        }
    }


}
