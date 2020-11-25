using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemDragHendler : MonoBehaviour, IDragHandler , IEndDragHandler, IBeginDragHandler,IDropHandler
{
    private CanvasGroup canvasGroup;
    private Transform perrentToretyrnTo = null;
    private TimeBar _time;

    
    private void Awake()
    {
        _time = GameObject.Find("TimeBar").GetComponent<TimeBar>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnDrag(PointerEventData eventData)
    {
        if ((this.tag == "Voult" || this.tag == "Inventory" || this.tag == "Equipment") && GetComponent<Image>().sprite != null)
        {
            transform.position = Input.mousePosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {

            Camera.main.gameObject.GetComponent<CameraControl>().enabled = true;
            canvasGroup.blocksRaycasts = true;
            this.transform.SetParent(perrentToretyrnTo);
            transform.localPosition = Vector3.zero;

    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {

            Camera.main.gameObject.GetComponent<CameraControl>().enabled = false;
            canvasGroup.blocksRaycasts = false;
            perrentToretyrnTo = this.transform.parent;
            this.transform.SetParent(GameObject.Find("HUD").transform);
            this.transform.SetSiblingIndex(8);
    }

     void IDropHandler.OnDrop(PointerEventData eventData)
    {

        if(eventData.pointerDrag !=null&&
            GetComponent<Image>().sprite == null&& 
            eventData.pointerDrag.GetComponent<Image>().sprite !=null&&
            (eventData.pointerDrag.tag ==tag|| eventData.pointerDrag.tag == "Voult"|| tag == "Voult" )&&
            !_time.IsStep)
        {
            _time.SetStep(true);
            GetComponent<Image>().sprite = eventData.pointerDrag.GetComponent<Image>().sprite;
            eventData.pointerDrag.transform.position = transform.position;
            eventData.pointerDrag.GetComponent<Image>().sprite=null;
            eventData.pointerDrag.GetComponent<Image>().color = new Color(1, 1, 1, 0);
            eventData.pointerDrag.transform.localPosition = Vector3.zero;
            transform.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
        }
        else
        {
            eventData.pointerDrag.transform.localPosition = Vector3.zero;
        }
    }
}
