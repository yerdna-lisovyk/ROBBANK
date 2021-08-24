using System;
using System.Collections.Generic;
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
        var head = new Head(_head,Card.NameEquipment.MINING_HELMET);
    }
    public void AddWeapon(Card NewWeapon)
    {
        _weapon.GetComponent<CardInfo>().SetCardInfo(NewWeapon);
    }
    public void AddBoots(Card NewBoots)
    {
        foreach (var icon in _boots)
        {
            if (icon.transform.GetComponent<CardInfo>().IsNull)
            {
                icon.GetComponent<CardInfo>().SetCardInfo(NewBoots);
                Boots boots = new Boots(icon, NewBoots.GetNameEquipment);
                break;
            }
        }
    }
    public bool SearchByEquipment(Card.NameEquipment name)
    {
        if (_body.GetComponent<CardInfo>().GetCard.GetNameEquipment == name)
            return true;
        if (_head.GetComponent<CardInfo>().GetCard.GetNameEquipment == name)
            return true;
        if (_weapon.GetComponent<CardInfo>().GetCard.GetNameEquipment == name)
            return true;
        foreach(var boot in _boots)
            if (boot.GetComponent<CardInfo>().GetCard.GetNameEquipment == name)
                return true;
        return false;
    }
    public void AddEquipment(Card NewEquipment)
    {
        switch(NewEquipment.GetTypeEquipment)
        {
            case Card.TypeEquipment.BODY:
                {
                    AddBody(NewEquipment);
                    break;
                }
            case Card.TypeEquipment.HEAD:
                {
                    AddHead(NewEquipment);
                    break;
                }
            case Card.TypeEquipment.BOOTS:
                {
                    AddBoots(NewEquipment);
                    break;
                }
            case Card.TypeEquipment.WEAPON:
                {
                    AddWeapon(NewEquipment);
                    break;
                }
        }
    }
    public void RemoveAllEquipment()
    {
        AddBody(null);
        AddHead(null);
        AddWeapon(null);
        foreach (var icon in _boots)
        {
            icon.GetComponent<CardInfo>().SetCardInfo(null);
        }
    }

    public void RemoveAllСlothes()
    {
        AddBody(null);
        AddHead(null);
        foreach (var icon in _boots)
        {
            icon.GetComponent<CardInfo>().SetCardInfo(null);
        }
    }

    public void RemoveRandEquip()
    {
        List<GameObject> Equip = new List<GameObject>();
        if (!_body.GetComponent<CardInfo>().IsNull)
            Equip.Add(_body);
        if (_head.GetComponent<CardInfo>().IsNull)
            Equip.Add(_head);
        if (_weapon.GetComponent<CardInfo>().IsNull)
            Equip.Add(_weapon);
        foreach (var boot in _boots)
            if (boot.GetComponent<CardInfo>().IsNull)
                Equip.Add(boot);
        if(Equip.Count!=0) Equip[UnityEngine.Random.Range(0, Equip.Count)].GetComponent<CardInfo>().SetCardInfo(null);
    }
}
