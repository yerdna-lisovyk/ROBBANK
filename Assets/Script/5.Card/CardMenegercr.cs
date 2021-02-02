using System.Collections.Generic;
using UnityEngine;


public class CardMenegercr : MonoBehaviour
{
    private static CardMenegercr _instans;
    private List<Card> AllCards = new List<Card>();
    private ProfilePlayer _player;


    public static Card StaticRandCard(Card.TypeCard[] typeCard = null, Card.TypeEquipment[] typeEquipment=null)
    {
        return _instans.RandCard(typeCard, typeEquipment);
    }
    private void Start()
    {
        _instans = this;
        _player = GameObject.Find("GameMeneger").GetComponent<PlayerMeneger>().GetPlayer(0);
        AllCards.Add(new Card("Чика", "теряешь 3 монеты и ждешь 20 секунд.", 10, "Simple Buttons/RPG_inventory_icons/apple", Card.TypeCard.TRAP, Card.TypeTrap.CHIKA));
        AllCards.Add(new Card("Мина", "Отдай монету, или жди 20 секунд. 50%", 10, "Simple Buttons/RPG_inventory_icons/pngegg", Card.TypeCard.TRAP, Card.TypeTrap.MINA));
        AllCards.Add(new Card("Сапог скороход", "Добавляет 2 клетки к ходу.", 5, "Simple Buttons/RPG_inventory_icons/boots", Card.TypeCard.EQUIPMENT, Card.TypeEquipment.BOOTS, Card.NameEqupment.BOOTS_OF_SPEED));
        _player.GetInvetory.AddCard(AllCards[0].GetCopyCard());//исправить
        _player.GetInvetory.AddCard(AllCards[1].GetCopyCard());
        _player.GetInvetory.AddCard(AllCards[0].GetCopyCard());
        _player.GetAmmo.AddAmmo(40);
        //  _player.GetEquipment.AddBoots(AllCards[].GetCopyCard());
        // _player.GetEquipment.AddBoots(AllCards[1].GetCopyCard());
    }

    private Card RandCard(Card.TypeCard[] typeCard, Card.TypeEquipment[] typeEquipment)
    {
        if (typeCard != null)
        {
            List<Card> tmp = AllCardOfType(typeCard,typeEquipment);
            int radomItem = Random.Range(0, tmp.Count);
            return tmp[radomItem].GetCopyCard();
        }
        return AllCards[Random.Range(0, AllCards.Count)].GetCopyCard();

    }
    private List<Card> AllCardOfType(Card.TypeCard[] typeCard, Card.TypeEquipment[] typeEquipment)
    {
        List<Card> AllCardsTypes = new List<Card>();
        if (typeEquipment == null)
        {
            foreach (var card in AllCards)
            {
                for (int i = 0; i < typeCard.Length; i++)
                    if (card.GetTypeCard == typeCard[i])
                    {

                        AllCardsTypes.Add(card);
                        break;

                    }
            }
        }
        else
        {
            foreach (var card in AllCards)
            {
                for (int i = 0; i < typeCard.Length; i++)
                    if (card.GetTypeCard == typeCard[i])
                    {
                        for (int j = 0; j < typeEquipment.Length; j++)
                            if (card.GetTypeEquipment == typeEquipment[j])
                            {
                                AllCardsTypes.Add(card);
                                break;
                            }
                    }
            }
        }
        return AllCardsTypes;
    }


}
