using UnityEngine;
using UnityEngine.UI;

public class CardInfo : MonoBehaviour //визуальная информациия карт
{
    private Card _infoCard=null;

    public bool IsTrap => _infoCard.GetTypeCard ==Card.TypeCard.TRAP;
    public Card GetCard => _infoCard;
    public bool IsNull => _infoCard==null;
    public void SetCardInfo(Card NewCard)
    {
        _infoCard = NewCard;

        if (NewCard != null)
        {
           gameObject.transform.GetComponent<Image>().color = new Color(1, 1, 1, 1f);
           gameObject.transform.GetComponent<Image>().sprite = _infoCard.GetSprite;
        }
        else
        {
            gameObject.transform.GetComponent<Image>().color = new Color(1, 1, 1, 0f);
            gameObject.transform.GetComponent<Image>().sprite = null;
        }
    }

}
