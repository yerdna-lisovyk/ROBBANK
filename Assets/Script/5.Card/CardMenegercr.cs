using System.Collections.Generic;
using UnityEngine;


public class CardMenegercr : MonoBehaviour
{
    private static CardMenegercr _instans;
    private List<Card> AllCards = new List<Card>();
    private ProfilePlayer _player;


    public static Card StaticRandCard(Card.TypeCard typeCard)
    {
       return _instans.RandCard(typeCard);
    }
    private void Start()
    {
        _instans = this;
        _player = GameObject.Find("GameMeneger").GetComponent<PlayerMeneger>().GetPlayer(0);
        AllCards.Add(new Card("Чика", "Отдай монету, или жди 20 секунд. 50%", "Simple Buttons/RPG_inventory_icons/apple", Card.TypeCard.TRAP, Card.TypeTrap.CHIKA));
        AllCards.Add(new Card("Сапог скороход", "Добавляет 2 клетки к ходу.", "Simple Buttons/RPG_inventory_icons/boots", Card.TypeCard.EQUIPMENT, Card.TypeEquipment.BOOTS, Card.NameEqupment.BOOTS_OF_SPEED));
        _player.GetInvetory.AddCard(AllCards[0].GetCopyCard());//исправить
        _player.GetInvetory.AddCard(AllCards[0].GetCopyCard());
        _player.GetInvetory.AddCard(AllCards[0].GetCopyCard());
        //  _player.GetEquipment.AddBoots(AllCards[1].GetCopyCard());
        // _player.GetEquipment.AddBoots(AllCards[1].GetCopyCard());
    }
    
    private Card RandCard(Card.TypeCard typeCard)
    {
        List<Card> tmp = AllCardOfType(typeCard);
        int radomItem = Random.Range(0, tmp.Count);
        return tmp[radomItem].GetCopyCard();
    }
    private List<Card> AllCardOfType(Card.TypeCard typeCard)
    {
        List<Card> AllCardsTypes = new List<Card>();
        foreach(var card in AllCards)
        {
            if((typeCard == Card.TypeCard.INVENTORY || typeCard == Card.TypeCard.TRAP) && 
                (card.GetTypeCard == Card.TypeCard.INVENTORY || card.GetTypeCard == Card.TypeCard.TRAP))
            {
                AllCardsTypes.Add(card); // Поиск карт
            }
            else
            {
                if(card.GetTypeCard == typeCard)
                {
                    AllCardsTypes.Add(card); // Поиск снаряжения
                }
            }
        }
        return AllCardsTypes;
    }


}
