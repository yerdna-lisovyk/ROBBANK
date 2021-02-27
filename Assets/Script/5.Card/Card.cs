
using UnityEngine;

public class Card
{
    public enum TypeCard
    {
        TRAP,
        INVENTORY,
        EQUIPMENT,
        AMMO
    }
    public enum TypeTrap
    {
        NO_TRAP,
        CHIKA,
        MINA,
        VAGABOND
    }
    public enum TypeEquipment
    {
        BODY,
        HEAD,
        WEAPON,
        BOOTS
    }

    public enum NameEqupment
    {
        BOOTS_OF_SPEED,
        SHOES_WITHOUT_SOLES
    }

    private Sprite _sprite;
    private string _name;
    private string _description;
    private int _prise;
    private int _quantity;

    private TypeCard _type;
    private TypeTrap _typeTrap;
    private TypeEquipment _typeEquipment;
    private NameEqupment _nameEqupment;

    public int GetQuantity => _quantity;
    public Sprite GetSprite => _sprite;
    public string GetName => _name;
    public int GetPrise => _prise;
    public string GetDescription => _description;
    public TypeEquipment GetTypeEquipment => _typeEquipment;
    public TypeCard GetTypeCard => _type;
    public TypeTrap GetTypeTrap => _typeTrap;
    public NameEqupment GetNameEqupment => _nameEqupment;

    public Card(string Name, string Description, int prise, string LoadSprite, TypeCard TypeC, TypeTrap TypeT = TypeTrap.NO_TRAP)
    {
        _name = Name;
        _description = Description;
        _sprite = Resources.Load<Sprite>(LoadSprite);
        _type = TypeC;
        _prise = prise;
        _typeTrap = TypeT;
    }

    public Card(string Name, string Description, int prise, string LoadSprite, TypeCard TypeC, TypeEquipment typeEquipment, NameEqupment typeBoots)
    {
        _name = Name;
        _description = Description;
        _sprite = Resources.Load<Sprite>(LoadSprite);
        _type = TypeC;
        _prise = prise;
        _typeEquipment = typeEquipment;
        _nameEqupment = typeBoots;
    }

    public Card(string Name, string Description, int prise, string LoadSprite, TypeCard TypeC, int quantity = 0)
    {
        _name = Name;
        _description = Description;
        _sprite = Resources.Load<Sprite>(LoadSprite);
        _type = TypeC;
        _prise = prise;
        _quantity = quantity;
    }
    public void SetQuantity(int quantity)
    {
        _quantity = quantity;
    }
    public void AppayQuantity(int quantity)
    {
        _quantity += quantity;
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

