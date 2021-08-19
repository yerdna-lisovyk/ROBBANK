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
        AllCards.Add(new Card("Сапог скороход", "Добавляет 2 клетки к ходу.", 5, "Simple Buttons/RPG_inventory_icons/boots", Card.TypeCard.EQUIPMENT, Card.TypeEquipment.BOOTS, Card.NameEquipment.BOOTS_OF_SPEED));
        AllCards.Add(new Card("Бомж", "Отнимает монеты каждый ход.", 5, "VAGABOND", Card.TypeCard.TRAP, Card.TypeTrap.VAGABOND));
        AllCards.Add(new Card("Туфля мафиози", "Показывает следующие три клетки. Если есть две туфли то показывает 6 клеток.", 5, "Simple Buttons/RPG_inventory_icons/men_tuf", Card.TypeCard.EQUIPMENT, Card.TypeEquipment.BOOTS, Card.NameEquipment.MAFIOSO_SHOES));
        _player.GetInvetory.AddCard(AllCards[0].GetCopyCard());//исправить
        _player.GetInvetory.AddCard(AllCards[1].GetCopyCard());
        _player.GetInvetory.AddCard(AllCards[0].GetCopyCard());
        _player.GetInvetory.AddCard(AllCards[3].GetCopyCard());
        _player.GetAmmo.AddAmmo(40);
        //_player.GetEquipment.AddBoots(AllCards[2].GetCopyCard());
        // _player.GetEquipment.AddBoots(AllCards[2].GetCopyCard());
    }

    private Card RandCard(Card.TypeCard[] typeCard, Card.TypeEquipment[] typeEquipment)
    {
        if (typeCard != null)
        {
            var tmp = AllCardOfType(typeCard,typeEquipment);
            var randomItem = Random.Range(0, tmp.Count);
            return tmp[randomItem].GetCopyCard();
        }
        return AllCards[Random.Range(0, AllCards.Count)].GetCopyCard();
    }
    private List<Card> AllCardOfType(Card.TypeCard[] typeCard, Card.TypeEquipment[] typeEquipment)
    {
        var allCardsTypes = new List<Card>();
        if (typeEquipment == null)
        {
            foreach (var card in AllCards)
            {
                for (var i = 0; i < typeCard.Length; i++)
                    if (card.GetTypeCard == typeCard[i])
                    {

                        allCardsTypes.Add(card);
                        break;

                    }
            }
        }
        else
        {
            foreach (var card in AllCards)
            {
                for (var i = 0; i < typeCard.Length; i++)
                    if (card.GetTypeCard == typeCard[i])
                    {
                        for (var j = 0; j < typeEquipment.Length; j++)
                            if (card.GetTypeEquipment == typeEquipment[j])
                            {
                                allCardsTypes.Add(card);
                                break;
                            }
                    }
            }
        }
        return allCardsTypes;
    }


}
