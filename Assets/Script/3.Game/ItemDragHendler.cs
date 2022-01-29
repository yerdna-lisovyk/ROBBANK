using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemDragHendler : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler, IDropHandler
{
    private CanvasGroup _canvasGroup;
    private Transform _perrentToretyrnTo = null;
    private VoultMeneger _voult;
    private ProfilePlayer _player;

    private void Start()
    {
        _player = GameObject.Find("GameMeneger").GetComponent<PlayerMeneger>().GetPlayer(0);
        _voult = GameObject.Find("GameMeneger").GetComponent<VoultMeneger>();
        _canvasGroup = GetComponent<CanvasGroup>();
    }
    public void ShowInfoCard()
    {
        var parent = transform.parent.parent.parent.parent;
        InformationButton.StaticShowInformatinButton(gameObject, parent);
        if (GetComponent<CardInfo>().GetCard.GetAction != null)
        {
            ActivateButton.StaticShowActivateButton(gameObject, parent);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.pointerDrag.GetComponent<Image>().sprite != null)
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

        _canvasGroup.blocksRaycasts = true;
        transform.SetParent(_perrentToretyrnTo);
        transform.localPosition = Vector3.zero;

    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        InformationButton.StaticHideInformatinButton();
        Camera.main.gameObject.GetComponent<CameraControl>().enabled = false;
        _canvasGroup.blocksRaycasts = false;
        _perrentToretyrnTo = transform.parent;
        transform.SetParent(GameObject.Find("HUD").transform);
    }

    void IDropHandler.OnDrop(PointerEventData eventData)//Изменить на взаимодействие с CardInfo
    {

        if (eventData.pointerDrag != null &&
            GetComponent<Image>().sprite == null &&
            eventData.pointerDrag.GetComponent<Image>().sprite != null &&
            (CompareTag("Voult") || eventData.pointerDrag.CompareTag(tag)) &&
            !_player.IsStep)
        {
          //  if (eventData.pointerDrag.tag != tag)
            //    _player.PlayingCard();
            SwapCardInfo(GetComponent<CardInfo>(), eventData.pointerDrag.GetComponent<CardInfo>());
            eventData.pointerDrag.transform.position = transform.position;
            if (!CompareTag("Voult"))
            {
                Boots tmp = new Boots(gameObject, GetComponent<CardInfo>().GetCard.GetNameEquipment);
            }
            tag = eventData.pointerDrag.tag;

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
