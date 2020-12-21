using System.Collections;
using System.Collections.Generic;
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
                icon.transform.GetComponent<Image>().color = new Color(1, 1, 1, 1f);
                icon.transform.GetComponent<Image>().sprite = NewCard.GetSprite;
               // icon.GetComponent<Card>().SetSprite(NewCard.GetSprite);
                //icon.GetComponent<Card>().SetDescription(NewCard.GetDescription);
                //icon.GetComponent<Card>().SetTypeCard(NewCard.GetTypeCard);
               // icon.GetComponent<Card>().SetName(NewCard.GetName);
                break;
            }
        }
    }
}