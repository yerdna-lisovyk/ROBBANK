
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CardInfo : MonoBehaviour
{
    public enum TypeCard
    {
        TRAP,
        INVENTORY,
        EQUIPMENT
    }

    private Sprite _sprite;
    private string _name;
    private string _description;
    private TypeCard _type;

    public Sprite GetSprite => _sprite;
    public string GetName => _name;
    public string GetDescription => _description;

    public void SetSprite(Sprite NewSprite)
    {
        _sprite = NewSprite;
        gameObject.transform.GetComponent<Image>().sprite = _sprite;
    }

    public void SetName(string NewName)
    {
        _name = NewName;
    }

    public void SetDescription(string NewDescription)
    {
        _name = NewDescription;
    }

    public CardInfo(string Name , string Description , Sprite NewSprite,TypeCard Type)
    {
        _name = Name;
        _description = Description;
        _sprite = NewSprite;
        _type = Type;
    }

}
