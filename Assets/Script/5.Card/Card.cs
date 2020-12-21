
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Card
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
    public TypeCard GetTypeCard => _type;

    public void SetSprite(Sprite NewSprite)
    {
        _sprite = NewSprite;
    }
    public void SetName(string NewName)
    {
        _name = NewName;
    }

    public void SetDescription(string NewDescription)
    {
        _description = NewDescription;
    }
    public void SetTypeCard(TypeCard NewTypeCard)
    {
        _type = NewTypeCard;
    }


    public Card(string Name , string Description , string LoadSprite,TypeCard Type)
    {
        _name = Name;
        _description = Description;
        _sprite = Resources.Load<Sprite>(LoadSprite);
        _type = Type;
    }

}
