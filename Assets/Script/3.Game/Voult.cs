using System;
using UnityEngine;
using UnityEngine.UI;

public class Voult 
{
    private GameObject[] _voult;

    public Voult()
    {
        _voult = GameObject.FindGameObjectsWithTag("Voult");
    }

    public void AddCard(Card NewCard)
    {
        foreach (var icon in _voult)
        {
            if (icon.transform.GetComponent<Image>().sprite == null)
            {
                icon.GetComponent<CardInfo>().SetCardInfo(NewCard);
                break;
            }
        }
    }
}
