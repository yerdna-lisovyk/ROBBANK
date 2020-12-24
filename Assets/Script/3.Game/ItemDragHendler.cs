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
    private Voult _voult;

    private void Awake()
    {
        _voult = GameObject.Find("GameMeneger").GetComponent<Voult>();
        _time = GameObject.Find("TimeBar").GetComponent<TimeBar>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnDrag(PointerEventData eventData)
    {
        if ((this.tag == "Voult" || this.tag == "Inventory" || this.tag == "Equipment") && eventData.pointerDrag.GetComponent<Image>().sprite != null)
        {
            transform.position = Input.mousePosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!_voult.IsOpenVoult)
        {
            Camera.main.gameObject.GetComponent<CameraControl>().enabled = true;
        }
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
            this.transform.SetSiblingIndex(9);
    }

     void IDropHandler.OnDrop(PointerEventData eventData)
    {

        if(eventData.pointerDrag !=null&&
            GetComponent<Image>().sprite == null&& 
            eventData.pointerDrag.GetComponent<Image>().sprite !=null&&
            (eventData.pointerDrag.tag ==tag|| eventData.pointerDrag.tag == "Voult"|| tag == "Voult" )&&
            !_time.IsStep)
        {
            //_time.SetStep(true);
            SwapCardInfo(GetComponent<CardInfo>(), eventData.pointerDrag.GetComponent<CardInfo>());
            eventData.pointerDrag.transform.position = transform.position;
            eventData.pointerDrag.transform.localPosition = Vector3.zero;
        }
        else
        {
            eventData.pointerDrag.transform.localPosition = Vector3.zero;
        }
    }

    private void SwapCardInfo(CardInfo First, CardInfo Second)
    {
        Card tmp = First.GetCard;
        First.SetCardInfo(Second.GetCard);
        Second.SetCardInfo(tmp);
    }    

}
