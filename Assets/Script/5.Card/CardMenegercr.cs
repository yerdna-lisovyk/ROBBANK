using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class CardMenegercr : ItemAction 
{
    private static CardMenegercr _instans;
    private List<Card> AllCards = new List<Card>();
    private ProfilePlayer _player;

    
    public static Card StaticRandCard(Card.TypeCard[] typeCard = null, Card.TypeEquipment[] typeEquipment=null)
    {
        return _instans.RandCard(typeCard, typeEquipment);
    }
    public static Card StaticGetCardToId(int idCard)
    {
        return _instans.GetCardToId(idCard);
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
        AllCards.Add(new Card("Шахтерская каска", "видит первые две клетки", 
            5, "Simple Buttons/RPG_inventory_icons/Helem", Card.TypeCard.EQUIPMENT, Card.TypeEquipment.HEAD, Card.NameEquipment.MINING_HELMET));
        AllCards.Add(new Card("Повязка аниме", " Позволяет сделать рывок на 4 клетки вперёд. Перезарядка 45сек.", 
            600, "Simple Buttons/RPG_inventory_icons/Anime", Card.TypeCard.EQUIPMENT, Card.TypeEquipment.HEAD, Card.NameEquipment.ANIME_HEADBAND));
        AllCards.Add(new Card("Пистолет", "Увеличивает расстояние на 3 клетки", 3000,"Simple Buttons/RPG_inventory_icons/pistol", Card.TypeCard.EQUIPMENT,
            Card.TypeEquipment.WEAPON, Card.NameEquipment.PISTOL));
        AllCards.Add(new Card("Саперная лапта", "Наткнувшись на мину, вы с легкостью её отбиваете", 10, "Simple Buttons/RPG_inventory_icons/apple", Card.TypeCard.INVENTORY, Card.TypeTrap.NO_TRAP,
            (() => AddStatus(StatusBar.Effect.PROTECTION_MELEE)),(() =>DestroyStatus(StatusBar.Effect.PROTECTION_MELEE))));
        AllCards.Add(new Card("Метла", " Если мина то, она выкапывается и переходит в инвентарь.", 10, "Simple Buttons/RPG_inventory_icons/Helem", Card.TypeCard.INVENTORY, Card.TypeTrap.NO_TRAP,
            null,null
            ,(() => Broom())));
        AllCards.Add(new Card("Саперная лапта", "Наткнувшись на мину, вы с легкостью её отбиваете", 10, "Simple Buttons/RPG_inventory_icons/apple", Card.TypeCard.INVENTORY, Card.TypeTrap.NO_TRAP,
            (() => AddStatus(StatusBar.Effect.PROTECTION_MELEE)),(() =>DestroyStatus(StatusBar.Effect.PROTECTION_MELEE))));
        _player.GetInventors.AddCard(AllCards[0].CopyCard());//исправить
        _player.GetInventors.AddCard(AllCards[1].CopyCard());
        _player.GetInventors.AddCard(AllCards[0].CopyCard());
        _player.GetInventors.AddCard(AllCards[3].CopyCard());
        _player.GetInventors.AddCard(AllCards[9].CopyCard());
        _player.GetEquipment.AddEquipment(AllCards[6].CopyCard());
        _player.GetEquipment.AddEquipment(AllCards[7].CopyCard());
        _player.GetAmmo.AddAmmo(10);
        _player.GetAmmo.AddAmmo(20);
    }

    private Card GetCardToId(int idCard)
    {
        return AllCards[1].CopyCard();
    }
    private Card RandCard(Card.TypeCard[] typeCard, Card.TypeEquipment[] typeEquipment)
    {
        if (typeCard != null)
        {
            var tmp = AllCardOfType(typeCard,typeEquipment);
            var randomItem = Random.Range(0, tmp.Count);
            return tmp[randomItem].CopyCard();
        }
        return AllCards[Random.Range(0, AllCards.Count)].CopyCard();
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
