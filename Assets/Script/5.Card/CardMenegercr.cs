using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class CardMeneger
{
    public static List<CardInfo> AllCards = new List<CardInfo>();

}
public class CardMenegercr : MonoBehaviour
{
    private void Awake()
    {
       // CardMeneger.AllCards.Add(new CardInfo("Chika", "Отдай монету, или жди 20 секунд. 50%", , CardInfo.TypeCard.TRAP));
    }
}
