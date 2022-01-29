
using System;
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
        BULLETPROOF_VEST,
        OVERALL,
        MINING_HELMET,
        ANIME_HEADBAND,
        PISTOL,
        CARDBOARD_MACHINE,
        SVT_40,
        BOXING_GLOVE,
        SNIPER_RIFLE,
        SHOTGUN
    }

    private Sprite _sprite;
    private string _name;
    private string _description;
    private readonly int _prise;
    private int _quantity;

    public Action _actionNow;
    public Action _action;
    public Action _actionDestroy;
    
    private TypeCard _type;
    private TypeTrap _typeTrap;
    private TypeEquipment _typeEquipment;
    private NameEquipment _nameEquipment;

    public int GetQuantity => _quantity;
    public Sprite GetSprite => _sprite;
    public string GetName => _name;
    public Action GetAction => _action;
    
    public Action GetActionNow => _actionNow;
    
    public Action GetActionDestroy => _actionDestroy;
    public int GetPrise => _prise;
    public string GetDescription => _description;
    public TypeEquipment GetTypeEquipment => _typeEquipment;
    public TypeCard GetTypeCard => _type;
    public TypeTrap GetTypeTrap => _typeTrap;
    public NameEquipment GetNameEquipment => _nameEquipment;

    public Card(string Name, string Description, int prise, string LoadSprite, TypeCard TypeC, TypeTrap TypeT = TypeTrap.NO_TRAP, 
        Action ActionNow=null,Action ActionDestroy=null, Action Action=null)
    {
        _name = Name;
        _description = Description;
        _sprite = Resources.Load<Sprite>(LoadSprite);
        _type = TypeC;
        _prise = prise;
        _typeTrap = TypeT;
        _actionNow = ActionNow;
        _actionDestroy = ActionDestroy;
        _action = Action;
        if (_actionNow != null) _actionNow();
    }

    public Card(string Name, string Description, int prise, string LoadSprite, TypeCard TypeC, TypeEquipment typeEquipment, NameEquipment nameEquipment)
    {
        _name = Name;
        _description = Description;
        _sprite = Resources.Load<Sprite>(LoadSprite);
        _type = TypeC;
        _prise = prise;
        _typeEquipment = typeEquipment;
        _nameEquipment = nameEquipment;
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

    ~Card()
    {
        if (_actionDestroy!= null) _actionDestroy();
    }
    private Card(Card CopyCard)
    {
        _name = CopyCard.GetName;
        _description = CopyCard._description;
        _sprite = CopyCard.GetSprite;
        _prise = CopyCard.GetPrise;
        _quantity = CopyCard.GetQuantity;
        _type = CopyCard.GetTypeCard;
        _typeEquipment = CopyCard.GetTypeEquipment;
        _nameEquipment = CopyCard.GetNameEquipment;
        _typeTrap = CopyCard.GetTypeTrap;
        _action = CopyCard.GetAction;
    }


    public void SetAction(Action action)
    {
        _action = action;
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

    public Card CopyCard()
    {
        var card = new Card(this);
        return card;
    }


}

