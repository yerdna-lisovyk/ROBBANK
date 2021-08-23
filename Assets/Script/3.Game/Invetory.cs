using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Invetory
{
    private GameObject[] _hand;
    private List<Card> _cards = new List<Card>();

    public GameObject[] GetHand => _hand;
    public List<Card> GetCards=> _cards;

    public int QuantityCard()
    {
        var quantity = 0;
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
                _cards.Add(NewCard);
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