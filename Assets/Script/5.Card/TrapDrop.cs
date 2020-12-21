using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TrapDrop : MonoBehaviour, IDropHandler
{
    private TimeBar _time;

    private void Awake()
    {
        _time = GameObject.Find("TimeBar").GetComponent<TimeBar>();
        
    }
    void IDropHandler.OnDrop(PointerEventData eventData)
    {
        if (!_time.IsStep)
        {
            _time.SetStep(true);
            eventData.pointerDrag.GetComponent<Image>().sprite = null;
            eventData.pointerDrag.GetComponent<Image>().color = new Color(1, 1, 1, 0);
            eventData.pointerDrag.transform.localPosition = Vector3.zero;
         //  eventData.pointerDrag.GetComponent<TrapControll>();
        }
    }


}
