using UnityEngine;
using UnityEngine.UI;

public class Storage
{
    private GameObject[] _storage;

    public Storage()
    {
        _storage = GameObject.FindGameObjectsWithTag("Voult");
    }

    public void AddCard(Card NewCard)
    {
        foreach (var icon in _storage)
        {
            if (icon.transform.GetComponent<Image>().sprite == null)
            {
                icon.GetComponent<CardInfo>().SetCardInfo(NewCard);
                break;
            }
        }
    }
}
