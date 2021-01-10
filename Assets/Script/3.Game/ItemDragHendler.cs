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
    public void ShowInfoCard()
    {
        if (!gameObject.GetComponent<CardInfo>().IsNull)
        {
            string Name = gameObject.GetComponent<CardInfo>().GetCard.GetName + ", " + gameObject.GetComponent<CardInfo>().GetCard.GetTypeCard.ToString();
            string Description = gameObject.GetComponent<CardInfo>().GetCard.GetDescription;
            Tooltip.ShowTooltip_Static(Name, Description);
        }
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
            tag == "Voult"  &&
            !_player.IsStep)
        {
            if(eventData.pointerDrag.tag != tag)
                 _player.SetStep(true);
            tag = eventData.pointerDrag.tag;
            SwapCardInfo(GetComponent<CardInfo>(), eventData.pointerDrag.GetComponent<CardInfo>());
            eventData.pointerDrag.transform.position = transform.position;
            if (tag != "Voult")
            {
                Boots tmp = new Boots(gameObject, GetComponent<CardInfo>().GetCard.GetNameEqupment);
            }
            
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
