
using UnityEngine;

public class Ammo
{
    private Card _ammoCard;
    private string _name ="Патрон";
    private string _description = "Позволяется стрелять";
    private int _prise = 10;
    private int _quantityAmmo = 0;
    private Card.TypeCard _type= Card.TypeCard.AMMO;
    private ProfilePlayer _player;
    private int _maxQuantity = 30;

    public int GetAmmoQuantity => _quantityAmmo;

    public Ammo(ProfilePlayer player)
    {
        _ammoCard = new Card(_name, _description, _prise, "Simple Buttons/RPG_inventory_icons/bullets", _type,0);
        _player = player;
    }
    

    public void AddAmmo(int quantity)
    {
        foreach (var icon in _player.GetInventors.GetHand)
        {
                if (!icon.GetComponent<CardInfo>().IsNull)
                {
                    var card = icon.GetComponent<CardInfo>().GetCard.GetCopyCard();
                    if (card.GetTypeCard == Card.TypeCard.AMMO)
                    {
                        if (card.GetQuantity+quantity <= _maxQuantity)
                        {
                            card.ApplyQuantity(quantity);
                            icon.GetComponent<CardInfo>().SetCardInfo(card);
                            _quantityAmmo += quantity;
                            quantity =0;
                            return;
                        }
                        else
                        {
                            if (card.GetQuantity != _maxQuantity)
                            {
                                var tmp = _maxQuantity - card.GetQuantity;
                                quantity -= tmp;
                                card.ApplyQuantity(tmp);
                                icon.GetComponent<CardInfo>().SetCardInfo(card);
                                _quantityAmmo += tmp;
                            }
                        }

                    }
                }
        }
            if (quantity != 0)
            {
                var ammoCardCopy = _ammoCard.GetCopyCard();
                ammoCardCopy.ApplyQuantity(quantity);
                _player.GetInventors.AddCard(ammoCardCopy);
                _quantityAmmo += quantity;
            }
    }
}
