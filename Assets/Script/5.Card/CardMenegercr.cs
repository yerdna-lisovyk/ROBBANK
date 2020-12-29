using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMenegercr : MonoBehaviour
{
    private  List<Card> AllCards = new List<Card>();
    private ProfilePlayer _player;

    private void Start()
    {
        _player = GameObject.Find("GameMeneger").GetComponent<PlayerMeneger>().GetPlayer(0);
        AllCards.Add(new Card("Chika", "Отдай монету, или жди 20 секунд. 50%", "Simple Buttons/RPG_inventory_icons/apple", Card.TypeCard.TRAP,Card.TypeTrap.CHIKA));
        AllCards.Add(new Card("Сапог скороход", "Добавляет 2 клетки к ходу. Если два сапога то +4 всего.", "Simple Buttons/RPG_inventory_icons/boots", Card.TypeCard.EQUIPMENT,0,Card.TypeEquipment.BOOTS));
        _player.GetInvetory.AddCard(AllCards[0].GetCopyCard());//исправить
        _player.GetInvetory.AddCard(AllCards[0].GetCopyCard());
        _player.GetEquipment.AddBoots(AllCards[1].GetCopyCard());
        _player.GetEquipment.AddBoots(AllCards[1].GetCopyCard());
    }


}
