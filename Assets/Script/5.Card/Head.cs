using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Head
{
    public Head(GameObject icon, Card.NameEquipment TypeHead)
    {
        switch (TypeHead)
        {
            case Card.NameEquipment.OVERALL:
            {
                icon.AddComponent<Overall>();
                break;
            }
            case Card.NameEquipment.MINING_HELMET:
            {
                icon.AddComponent<MiningHelmet>();
                break;
            }
            case Card.NameEquipment.ANIME_HEADBAND:
            {
                icon.AddComponent<AnimeHeadband>();
                break;
            }
        }
    }
    public class Overall : MonoBehaviour
    {
        private ProfilePlayer _player;
        private void Start()
        {
            _player = GameObject.Find("GameMeneger").GetComponent<PlayerMeneger>().GetPlayer(0);
            _player.SetActiveEffect(StatusBar.Effect.OVERALL);
        }
        
        private void OnDestroy()
        {
            _player.DestroyStatus(StatusBar.Effect.OVERALL);
        }
    }
    
    public class Pan : MonoBehaviour
    {
        private ProfilePlayer _player;
        private void Start()
        {
            _player = GameObject.Find("GameMeneger").GetComponent<PlayerMeneger>().GetPlayer(0);
            _player.SetActiveEffect(StatusBar.Effect.OVERALL);
        }
        
        private void OnDestroy()
        {
            _player.DestroyStatus(StatusBar.Effect.OVERALL);
        }
    }
    
    public class MiningHelmet : MonoBehaviour
    {
        private ProfilePlayer _player;
        private void Start()
        {
            _player = GameObject.Find("GameMeneger").GetComponent<PlayerMeneger>().GetPlayer(0);
            _player.SetActiveEffect(StatusBar.Effect.VISIBILITY_RANGE);
            StartCoroutine(TimerEffectVisibility());
        }
        
        private void OnDestroy()
        {
            _player.DestroyStatus(StatusBar.Effect.VISIBILITY_RANGE);
        }

        private IEnumerator TimerEffectVisibility()
        {
            var cellOfRange = new GameObject[2];
            cellOfRange = Cells.StaticGetCellsOfRange(_player.GetPlayerCell,_player.GetPlayerCell 
                                                                            + cellOfRange.Length);
            while (_player.IsActiveEffect(StatusBar.Effect.VISIBILITY_RANGE))
            {
                foreach (var cell in cellOfRange)
                {
                    cell.transform.GetChild(0).gameObject.SetActive(false);
                }

                cellOfRange = Cells.StaticGetCellsOfRange(_player.GetPlayerCell,_player.GetPlayerCell 
                    + cellOfRange.Length);
                foreach (var cell in cellOfRange)
                {
                    cell.transform.GetChild(0).gameObject.SetActive(true);
                }
                yield return null;
            }
            cellOfRange = Cells.StaticGetCellsOfRange(_player.GetPlayerCell,_player.GetPlayerCell 
                                                                            + cellOfRange.Length);
            foreach (var cell in cellOfRange)
            {
                cell.transform.GetChild(0).gameObject.SetActive(false);
            }

        }
    }
    public class DivingMask : MonoBehaviour
    {
        private ProfilePlayer _player;
        private void Start()
        {
            _player = GameObject.Find("GameMeneger").GetComponent<PlayerMeneger>().GetPlayer(0);
            _player.SetActiveEffect(StatusBar.Effect.DIVING_MASK);
        }
        
        private void OnDestroy()
        {
            _player.DestroyStatus(StatusBar.Effect.DIVING_MASK);
        }
    }
    public class HunterGoggles : MonoBehaviour
    {
        private ProfilePlayer _player;
        private void Start()
        {
            _player = GameObject.Find("GameMeneger").GetComponent<PlayerMeneger>().GetPlayer(0);
            _player.ApplyWeaponRange(3);
        }
        
        private void OnDestroy()
        {
            _player.ApplyWeaponRange(-3);
        }
    }
    
    public class Binoculars : MonoBehaviour
    {
        private ProfilePlayer _player;

        private void Start()
        {
            _player = GameObject.Find("GameMeneger").GetComponent<PlayerMeneger>().GetPlayer(0);
            _player.ApplyWeaponRange(10);
        }

        private void OnDestroy()
        {
            _player.ApplyWeaponRange(-10);
        }
    }
    public class AnimeHeadband : MonoBehaviour
    {
        private ProfilePlayer _player;

        private void Start()
        {
            _player = GameObject.Find("GameMeneger").GetComponent<PlayerMeneger>().GetPlayer(0);
            var itemButton  = transform.parent.gameObject.GetComponent<Button>();
            itemButton.onClick.AddListener(ActivateEffect);
        }

        private void ActivateEffect()
        {
            if(!_player.IsActiveEffect(StatusBar.Effect.HEAD_RECHARGE))
            {
                _player.GetPlayerPoint.GetComponent<PlayerMove>().MoveToPoint(_player.GetPlayerCell+4);
                StatusBar.StaticNewStatus(StatusBar.Effect.HEAD_RECHARGE,_player,45);
            }
        }
    }
}
