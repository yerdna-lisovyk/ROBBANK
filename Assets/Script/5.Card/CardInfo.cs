using UnityEngine;
using UnityEngine.UI;

public class CardInfo : MonoBehaviour //визуальная информациия карт
{
    private Card _infoCard = null;

    public bool IsTrap => _infoCard.GetTypeCard == Card.TypeCard.TRAP;
    public Card GetCard => _infoCard;
    public bool IsNull => _infoCard == null;
    public void SetCardInfo(Card NewCard)
    {
        _infoCard = NewCard;
        GameObject text = gameObject.transform.GetChild(0).gameObject;
        if (NewCard != null)
        {

            if (NewCard.GetTypeCard == Card.TypeCard.AMMO)
            {

                text.SetActive(true);
                text.GetComponent<Text>().text = NewCard.GetQuantity.ToString();
            }
            gameObject.transform.GetComponent<Image>().color = new Color(1, 1, 1, 1f);
            gameObject.transform.GetComponent<Image>().sprite = _infoCard.GetSprite;
        }
        else
        {
            text.SetActive(false);
            gameObject.transform.GetComponent<Image>().color = new Color(1, 1, 1, 0f);
            gameObject.transform.GetComponent<Image>().sprite = null;
        }
    }

}
