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
        AllCards.Add(new Card("Chika", "Отдай монету, или жди 20 секунд. 50%", "Simple Buttons/RPG_inventory_icons/apple", Card.TypeCard.TRAP));
        _player.GetInvetory.AddCard(AllCards[0]);
       
    }
    
}
