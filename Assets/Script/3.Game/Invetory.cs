using UnityEngine;
using UnityEngine.UI;

public class Invetory
{
    private GameObject[] _hand;

    public GameObject[] GetHand => _hand;

    public Invetory()
    {
        _hand = GameObject.FindGameObjectsWithTag("Inventory");
    }
    public void AddCard(Card NewCard)
    {
        foreach (var icon in _hand)
        {
            if (icon.transform.GetComponent<Image>().sprite == null)
            {
                icon.GetComponent<CardInfo>().SetCardInfo(NewCard);
                break;
            }
        }
    }
}