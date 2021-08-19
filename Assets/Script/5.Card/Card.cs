
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

    public enum NameEquipment
    {
        BOOTS_OF_SPEED,
        SHOES_WITHOUT_SOLES,
        MAFIOSO_SHOES,
        FOIL_CAP,
        WELDER_GOGGLES,
        BULLETPROOF_VEST
    }

    private Sprite _sprite;
    private string _name;
    private string _description;
    private int _prise;
    private int _quantity;

    private TypeCard _type;
    private TypeTrap _typeTrap;
    private TypeEquipment _typeEquipment;
    private NameEquipment _nameEquipment;

    public int GetQuantity => _quantity;
    public Sprite GetSprite => _sprite;
    public string GetName => _name;
    public int GetPrise => _prise;
    public string GetDescription => _description;
    public TypeEquipment GetTypeEquipment => _typeEquipment;
    public TypeCard GetTypeCard => _type;
    public TypeTrap GetTypeTrap => _typeTrap;
    public NameEquipment GetNameEquipment => _nameEquipment;

    public Card(string Name, string Description, int prise, string LoadSprite, TypeCard TypeC, TypeTrap TypeT = TypeTrap.NO_TRAP)
    {
        _name = Name;
        _description = Description;
        _sprite = Resources.Load<Sprite>(LoadSprite);
        _type = TypeC;
        _prise = prise;
        _typeTrap = TypeT;
    }

    public Card(string Name, string Description, int prise, string LoadSprite, TypeCard TypeC, TypeEquipment typeEquipment, NameEquipment typeBoots)
    {
        _name = Name;
        _description = Description;
        _sprite = Resources.Load<Sprite>(LoadSprite);
        _type = TypeC;
        _prise = prise;
        _typeEquipment = typeEquipment;
        _nameEquipment = typeBoots;
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
    public void ApplyQuantity(int quantity)
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

