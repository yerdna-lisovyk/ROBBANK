using UnityEngine;
using UnityEngine.UI;

public class Equipment 
{
    private GameObject _body;
    private GameObject _head;
    private GameObject _weapon;
    private GameObject[] _boots;

    public GameObject GetBody => _body;
    public GameObject GetHead => _head;
    public GameObject GetWeapon => _weapon;
    public GameObject[] GetBoots => _boots;

    public Equipment()
    {
        _body = GameObject.FindGameObjectWithTag("Body");
        _head = GameObject.FindGameObjectWithTag("Head");
        _weapon = GameObject.FindGameObjectWithTag("Weapon");
        _boots = GameObject.FindGameObjectsWithTag("Boots");
    }

    public void AddBody(Card NewBody)
    {
        _body.GetComponent<CardInfo>().SetCardInfo(NewBody);
    }

    public void AddHead(Card NewHead)
    {
        _head.GetComponent<CardInfo>().SetCardInfo(NewHead);
    }
    public void AddWeapon(Card NewWeapon)
    {
        _weapon.GetComponent<CardInfo>().SetCardInfo(NewWeapon);
    }
    public void AddBoots(Card NewBoots)
    {
        foreach (var icon in _boots)
        {
            if (icon.transform.GetComponent<Image>().sprite == null)
            {
                icon.GetComponent<CardInfo>().SetCardInfo(NewBoots);
                break;
            }
        }
    }
}
