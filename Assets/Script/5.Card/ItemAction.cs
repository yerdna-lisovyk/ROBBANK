using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAction :  MonoBehaviour
{
   public void AddStatus(StatusBar.Effect effect)
   {
     var player = GameObject.Find("GameMeneger").GetComponent<PlayerMeneger>().GetPlayer(0);
     player.SetActiveEffect(effect);
   }
   public void DestroyStatus(StatusBar.Effect effect)
   {
       var player = GameObject.Find("GameMeneger").GetComponent<PlayerMeneger>().GetPlayer(0);
       player.SetActiveEffect(effect);
   }
   public void Broom()
   {
       var player = GameObject.Find("GameMeneger").GetComponent<PlayerMeneger>().GetPlayer(0);
       var cellOfRange = new GameObject[3];
       cellOfRange = Cells.StaticGetCellsOfRange(player.GetPlayerCell,player.GetPlayerCell 
                                                                        + cellOfRange.Length);
       foreach (var cell in cellOfRange)
       {
           var cards = cell.GetComponent<CellInfo>().GetActiveCard;
           foreach (var card in cards)
           {
               if (card.GetTypeTrap == Card.TypeTrap.MINA)
               {
                   player.GetInventors.AddCard(card.CopyCard());
                   Destroy(cell.GetComponent<Traps.Mina>());
               }
           }
       }
   }
}
