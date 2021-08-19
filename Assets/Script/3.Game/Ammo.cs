
public class Ammo 
{
    private Card _ammoCard;
    private string _name ="Патрон";
    private string _description = "Позволяется стрелять";
    private int _prise = 10;
    private Card.TypeCard _type= Card.TypeCard.AMMO;
    private ProfilePlayer _player;

    public int GetAmmoQuantity => _ammoCard.GetQuantity;

    public Ammo(ProfilePlayer player)
    {
        _ammoCard = new Card(_name, _description, _prise, "Simple Buttons/RPG_inventory_icons/bullets", _type,0);
        _player = player;

    }

    public void AddAmmo(int quantity)
    {
        if (_ammoCard.GetQuantity == 0)
        {
            _ammoCard.SetQuantity(quantity);
            _player.GetInvetory.AddCard(_ammoCard);
            
        }
        else
        {
            _ammoCard.ApplyQuantity(quantity);
            if(_ammoCard.GetQuantity == 0)
                foreach(var icon in _player.GetInvetory.GetHand)
                {
                    if(icon.GetComponent<CardInfo>().GetCard.GetTypeCard == Card.TypeCard.AMMO)
                    {
                        icon.GetComponent<CardInfo>().SetCardInfo(null);
                        break;
                    }
                }
        }
    }
}
