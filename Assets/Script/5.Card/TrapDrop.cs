using UnityEngine;
using UnityEngine.EventSystems;

public class TrapDrop : MonoBehaviour, IDropHandler
{
    private ProfilePlayer _player;

    private void Awake()
    {
        _player = GameObject.Find("GameMeneger").GetComponent<PlayerMeneger>().GetPlayer(0);
    }
    void IDropHandler.OnDrop(PointerEventData eventData)
    {
        if (!eventData.pointerDrag.GetComponent<CardInfo>().IsNull)
        {
            if (!_player.IsStep && eventData.pointerDrag.GetComponent<CardInfo>().IsTrap)
            {
               // _player.PlayingCard();
                Traps _trap = new Traps(gameObject, eventData.pointerDrag.GetComponent<CardInfo>().GetCard);
                eventData.pointerDrag.transform.localPosition = Vector3.zero;
                eventData.pointerDrag.GetComponent<CardInfo>().SetCardInfo(null);
            }
        }
    }


}
