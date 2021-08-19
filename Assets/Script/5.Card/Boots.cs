using UnityEngine;
using UnityEngine.UI;

// ReSharper disable All

public class Boots
{
    
    public Boots(GameObject icon, Card.NameEquipment TypeBoots)
    {
        switch (TypeBoots)
        {
            case Card.NameEquipment.BOOTS_OF_SPEED:
            {
                icon.AddComponent<BootOfSpeed>();
                break;
            }
            case Card.NameEquipment.MAFIOSO_SHOES:
            {
                icon.AddComponent<MafiosoShoe>();
                break;
            }
        }
    }

    public class BootOfSpeed : MonoBehaviour
    {
        private ProfilePlayer _player;
        private void Start()
        {
            _player = GameObject.Find("GameMeneger").GetComponent<PlayerMeneger>().GetPlayer(0);
            _player.ApplyPlayerSpeed(2);
        }
        private void OnDestroy()
        {
            _player.ApplyPlayerSpeed(-2);
        }
    }
    public class MafiosoShoe: MonoBehaviour
    {
        private ProfilePlayer _player;
        private void Start()
        {
            _player = GameObject.Find("GameMeneger").GetComponent<PlayerMeneger>().GetPlayer(0);
            Button itemButton  = transform.parent.gameObject.GetComponent<Button>();
            itemButton.onClick.AddListener(ActivateEffect);
        }

        private void ActivateEffect()
        {
            var boots = _player.GetEquipment.GetBoots;
            int size;
            if (SearchDuplicates(Card.NameEquipment.MAFIOSO_SHOES, boots))
            {
                size = 6;
            }
            else
            {
                size = 3;
            }
            GameObject[] _cellOfRange = new GameObject[size];
            _cellOfRange = Cells.StaticGetCellsOfRange(_player.GetPlayerCell,_player.GetPlayerCell 
                                                                             + _cellOfRange.Length);
            foreach (var cell in _cellOfRange)
            {
                cell.transform.GetChild(0).gameObject.SetActive(true);
            }
        }
    }
    
    public class ArmorShackles: MonoBehaviour
    {
        private ProfilePlayer _player;
        private void Start()
        {
            _player = GameObject.Find("GameMeneger").GetComponent<PlayerMeneger>().GetPlayer(0);
            _player.SetActiveEffect(StatusBar.Effect.SHACKLES);
            _player.ApplyPermanentArmor(1);
        }
        private void OnDestroy()
        {
            _player.DestroyStatus(StatusBar.Effect.SHACKLES);
            _player.ApplyPermanentArmor(-1);
        }
    }

    private static bool SearchDuplicates(Card.NameEquipment NameBoot,GameObject[] boots)
    {
        int kol=0;
        foreach (var boot in boots)
        {
            if (boot.GetComponent<CardInfo>().GetCard.GetNameEquipment== NameBoot)
            {
                kol++;
                if (kol == 2)
                    return true;
            }
        }
        return false;
    }
}
