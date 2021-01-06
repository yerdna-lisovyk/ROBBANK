using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemDragHendler : MonoBehaviour, IDragHandler , IEndDragHandler, IBeginDragHandler,IDropHandler
{
    private CanvasGroup canvasGroup;
    private Transform perrentToretyrnTo = null;
    private VoultMeneger _voult;
    private ProfilePlayer _player;

    private void Start()
    {
        _player = GameObject.Find("GameMeneger").GetComponent<PlayerMeneger>().GetPlayer(0);
        _voult = GameObject.Find("GameMeneger").GetComponent<VoultMeneger>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.pointerDrag.GetComponent<Image>().sprite != null)//исправить условие
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
    }

     void IDropHandler.OnDrop(PointerEventData eventData)//Изменить на взаимодействие с CardInfo
    {

        if(eventData.pointerDrag !=null&&
            GetComponent<Image>().sprite == null&& 
            eventData.pointerDrag.GetComponent<Image>().sprite !=null&&
            ( tag == "Voult" || eventData.pointerDrag.tag == tag) &&
            !_player.IsStep)
        {
            tag = eventData.pointerDrag.tag;
            SwapCardInfo(GetComponent<CardInfo>(), eventData.pointerDrag.GetComponent<CardInfo>());
            eventData.pointerDrag.transform.position = transform.position;
            
        }
        eventData.pointerDrag.transform.localPosition = Vector3.zero;
    }

    private void SwapCardInfo(CardInfo First, CardInfo Second)
    {
        Card tmp = First.GetCard;
        First.SetCardInfo(Second.GetCard);
        Second.SetCardInfo(tmp);
    }    

}
