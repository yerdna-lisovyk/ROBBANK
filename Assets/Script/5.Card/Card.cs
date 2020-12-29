
using UnityEngine;

public class Card
{
    public enum TypeCard
    {
        TRAP,
        INVENTORY,
        EQUIPMENT
    }
    public enum TypeTrap
    {
        NO_TRAP,
        CHIKA
    }
    public enum TypeEquipment
    {
        BODY,
        HEAD,
        WEAPON,
        BOOTS
    }

    private Sprite _sprite;
    private string _name;
    private string _description;
    private TypeCard _type;
    private TypeTrap _typeTrap;
    private TypeEquipment _typeEquipment;

    public Sprite GetSprite => _sprite;
    public string GetName => _name;
    public string GetDescription => _description;
    public TypeEquipment GetTypeEquipment => _typeEquipment;
    public TypeCard GetTypeCard => _type;
    public TypeTrap GetTypeTrap => _typeTrap;

    public Card(string Name, string Description, string LoadSprite, TypeCard TypeC, TypeTrap TypeT = 0, TypeEquipment typeEquipment = 0)
    {
        _name = Name;
        _description = Description;
        _sprite = Resources.Load<Sprite>(LoadSprite);
        _type = TypeC;
        _typeTrap = TypeT;
        _typeEquipment = typeEquipment;
    }

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

    public Card GetCopyCard()
    {
        Card card = this;
        return card;
    }


}

