using UnityEngine;
using UnityEngine.UI;

public class Invetory
{
    private GameObject[] _hand;

    public GameObject[] GetHand => _hand;

    public int QuantityCard()
    {
        int quantity = 0;
        foreach (var icon in _hand)
        {
            if (!icon.GetComponent<CardInfo>().IsNull)
                quantity++;
        }
        return quantity;
    }
    public Invetory()
    {
        _hand = GameObject.FindGameObjectsWithTag("Inventory");
    }
    public void AddCard(Card NewCard)
    {
        foreach (var icon in _hand)
        {
            if (icon.GetComponent<CardInfo>().IsNull)
            {
                icon.GetComponent<CardInfo>().SetCardInfo(NewCard);
                break;
            }
        }
    }

    public void RemoveAllCard()
    {
        foreach (var icon in _hand)
        {
            icon.GetComponent<CardInfo>().SetCardInfo(null);
        }
    }
}