using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Build
{
    public Build(GameObject cell, int rand= 0)
    {

        switch (rand)
        {
            case 0:
                {
                    cell.AddComponent<Bank>();
                    break;
                }
            case 1:
                {
                    cell.AddComponent<PoliceDepartment>();
                    break;
                }
            case 2:
                {
                    cell.AddComponent<BlackMarket>();
                    break;
                }
            case 3:
                {
                    cell.AddComponent<Bar>();
                    break;
                }
            case 4:
                {
                    cell.AddComponent<ClothingStore>();
                    break;
                }
            case 5:
                {
                    cell.AddComponent<WeaponsStore>();
                    break;
                }
            case 6:
                {
                    cell.AddComponent<Trove>();
                    break;
                }
        }

    }
    public class PoliceDepartment : MonoBehaviour
    {
        private string _nameEvent = "Полицейский пост";
        private string _descriptionEvent = "Отдатдать две монеты ?Иначе две карты.";
        private ProfilePlayer _player;
        private int _removeCard;
        private Sprite _sptiteEvent;

        private void Awake()
        {
            _sptiteEvent = Resources.Load<Sprite>("Simple Buttons/RPG_inventory_icons/Police");
            gameObject.GetComponent<CellInfo>().SetBuildInfo(_sptiteEvent, _nameEvent, _descriptionEvent);      
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            _player = collision.GetComponent<PlayerMove>().GetProfilePlayer;
            if(!_player.IsActiveEffect(StatusBar.Effect.NOTVISIBILITY))
            {
                gameObject.transform.Find("Build").gameObject.SetActive(true); 
            }
            DisePanel.StaticShowDisce();
            StartCoroutine(IsActivePanel());
            _removeCard = 0;
        }
        private IEnumerator IsActivePanel()
        {
            while (DisePanel.IsActivate)
            {
                yield return new WaitForSeconds(0.04f);
            }
            int vallue = DisePanel.GetFinalValue;
            if (vallue > 3) Tooltip.ShowTooltip_Static(_nameEvent, "Вы свободны");
            else
            {
                if (_player.GetInvetory.QuantityCard() < 2 && _player.GetCoin <= 2)
                {
                    StatusBar.StaticNewStatus(30, StatusBar.Effect.STOP, _player);
                }
                else
                if (_player.GetInvetory.QuantityCard() < 2)
                {
                    Yes();
                    Tooltip.ShowTooltip_Static(_nameEvent, "Вы отдали : " + 2 + " Монеты");
                }
                else
                if (_player.GetInvetory.QuantityCard() == 2)
                {
                    foreach (var card in _player.GetInvetory.GetHand)
                    {
                        if (!card.GetComponent<CardInfo>().IsNull)
                        {
                            card.GetComponent<CardInfo>().SetCardInfo(null);
                        }
                    }
                    Tooltip.ShowTooltip_Static(_nameEvent, "Вы потеряли : " + 2 + " Карты");
                }
                else
                {
                    MassegeBox.StaticShowMassege(_nameEvent, _descriptionEvent, Yes, No);
                }
            }
        }
        private void Yes()
        {
            _player.ApplyCoinDamage(-2);
        }
        private void No()
        {
            BlockPanel.StaticShowBlockPanel();
            GameObject[] hand = _player.GetInvetory.GetHand;
            foreach (var card in hand)
            {
                if (!card.GetComponent<CardInfo>().IsNull)
                {
                    card.transform.parent.GetComponent<Button>().onClick.AddListener(delegate
                    {
                        card.GetComponent<CardInfo>().SetCardInfo(null);
                        _removeCard++;
                        if (_removeCard == 2)
                        {
                            DelListener();
                        }
                    });
                }
            }
        }
        private void DelListener()
        {
            GameObject[] hand = _player.GetInvetory.GetHand;
            foreach (var card in hand)
                if (!card.GetComponent<CardInfo>().IsNull)
                {
                    card.transform.parent.GetComponent<Button>().onClick.RemoveAllListeners();
                }
            BlockPanel.StaticHideBlockPanel();
        }
    }

    public class BlackMarket : MonoBehaviour
    {
        private string _nameEvent = "Черный рынок";
        private string _descriptionEvent = "Заплати монету, чтобы достать 3 карты и выбрать одну. " +
            "Заплати 10 монет, чтобы получить рандомно раритетное оружие или одежду. " +
            "Не пытайся ограбить! Если ты всё же хочешь ограбить, то в случае не удачи расстанься " +
            "со всем своим имуществом, а если улыбнется удача, то получи 10 монет и карту оружия или одежды." +
            " Не действуют карты отмены.";
        private ProfilePlayer _player;
        private Sprite _sptiteEvent;

        private void Awake()
        {
            _sptiteEvent = Resources.Load<Sprite>("Simple Buttons/RPG_inventory_icons/Police");
            gameObject.GetComponent<CellInfo>().SetBuildInfo(_sptiteEvent, _nameEvent, _descriptionEvent);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            _player = collision.GetComponent<PlayerMove>().GetProfilePlayer;
            if (!_player.IsActiveEffect(StatusBar.Effect.NOTVISIBILITY))
            {
                gameObject.transform.Find("Build").gameObject.SetActive(true);
            }
            MassegeBox.StaticShowMassege(_nameEvent, _descriptionEvent, Yes, No, true, Rob());
        }

        private void Yes()
        {
            _player.ApplyCoinDamage(-1);
            SelectionCard.StaticShowSelectionCard(3, 1,_player, new[] { Card.TypeCard.INVENTORY, Card.TypeCard.TRAP});
        }
        private void No()
        {
            _player.ApplyCoinDamage(-10);
            _player.GetEquipment.AddEquipment(CardMenegercr.StaticRandCard(new[] { Card.TypeCard.EQUIPMENT }));
        }
        private IEnumerator Rob()
        {
            DisePanel.StaticShowDisce();
            while (DisePanel.IsActivate)
            {
                yield return new WaitForSeconds(0.04f);
            }
            int vallue = DisePanel.GetFinalValue;
            if (vallue < 5)
            {
                _player.GetEquipment.RemoveAllEquipment();
                _player.GetInvetory.RemoveAllCard();
                Tooltip.ShowTooltip_Static(_nameEvent, "Вы потеряли всё!");
            }
            else
            {
                _player.ApplyCoinDamage(10);
                _player.GetEquipment.AddEquipment(CardMenegercr.StaticRandCard(new[] { Card.TypeCard.EQUIPMENT }));
            }
        }
    }

    public class Bar: MonoBehaviour
    {
        private string _nameEvent = "Бар \"4217\"";
        private string _descriptionEvent = "Единственно место, где ты сможешь отдохнуть. " +
            "Пока ты на этой клетке, никто не может на тебя напасть." +
            " Но и ты тоже ничего не можешь сделать. Просто отдохни.";
        private ProfilePlayer _player;
        private Sprite _sptiteEvent;

        private void Awake()
        {
            _sptiteEvent = Resources.Load<Sprite>("Simple Buttons/RPG_inventory_icons/Police");
            gameObject.GetComponent<CellInfo>().SetBuildInfo(_sptiteEvent, _nameEvent, _descriptionEvent);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {

            _player = collision.GetComponent<PlayerMove>().GetProfilePlayer;
            if (!_player.IsActiveEffect(StatusBar.Effect.NOTVISIBILITY))
            {
                gameObject.transform.Find("Build").gameObject.SetActive(true);
            }
            _player.SetCanAttack(false);
            _player.SetImpervious(true);
            Tooltip.ShowTooltip_Static(_nameEvent, _descriptionEvent);
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            _player.SetCanAttack(true);
            _player.SetImpervious(false);
        }
    }

    public class ComputerClub : MonoBehaviour
    {
        private string _nameEvent = "Компьютерный клуб";
        private string _descriptionEvent = "Всегда можно найти школьника который загуглит информацию о картах. " +
            "(Посмотри три карты в колоде и выбери одну себе) Отдай 2 монеты " +
            "чтобы посмотреть 60 секунд все клетки на поле.";
        private ProfilePlayer _player;
        private Sprite _sptiteEvent;

        private void Awake()
        {
            _sptiteEvent = Resources.Load<Sprite>("Simple Buttons/RPG_inventory_icons/Police");
            gameObject.GetComponent<CellInfo>().SetBuildInfo(_sptiteEvent, _nameEvent, _descriptionEvent);
        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            _player = collision.GetComponent<PlayerMove>().GetProfilePlayer;
            if (!_player.IsActiveEffect(StatusBar.Effect.NOTVISIBILITY))
            {
                gameObject.transform.Find("Build").gameObject.SetActive(true);
            }
            MassegeBox.StaticShowMassege(_nameEvent, _descriptionEvent, Yes, No);
        }
        private void Yes()
        {
            SelectionCard.StaticShowSelectionCard(3, 1, _player);
        }
        private void No()
        {
            _player.ApplyCoinDamage(-2);
            StatusBar.StaticNewStatus(30, StatusBar.Effect.VISIBILITY, _player);
        }
    }

    public class Bank : MonoBehaviour
    {
        private string _nameEvent = "Банк";
        private string _descriptionEvent = "Вы получили 15 монет";
        private ProfilePlayer _player;
        private Sprite _sptiteEvent;

        private void Awake()
        {
            _sptiteEvent = Resources.Load<Sprite>("Simple Buttons/RPG_inventory_icons/Police");
            gameObject.GetComponent<CellInfo>().SetBuildInfo(_sptiteEvent, _nameEvent, _descriptionEvent);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            
            _player = collision.GetComponent<PlayerMove>().GetProfilePlayer;
            if (!_player.IsActiveEffect(StatusBar.Effect.NOTVISIBILITY))
            {
                gameObject.transform.Find("Build").gameObject.SetActive(true);
            }
            Tooltip.ShowTooltip_Static(_nameEvent, _descriptionEvent);
            if (_player.GetClasses == ProfilePlayer.Classes.MOMFRIEND)
            {
                _player.ApplyCoinDamage(30);
            }else _player.ApplyCoinDamage(15);

        }
    }
    public class ClothingStore : MonoBehaviour
    {
        private string _nameEvent = "Магазинчик одежды";
        private string _descriptionEvent = "Место где можно купить одежду за монеты." +
            " Если ограбление удачно то + рандомная карта одежды, если нет, " +
            "то теряешь свою надетую одежду и 2 монеты.";
        private ProfilePlayer _player;
        private Sprite _sptiteEvent;

        private void Awake()
        {
            _sptiteEvent = Resources.Load<Sprite>("Simple Buttons/RPG_inventory_icons/Police");
            gameObject.GetComponent<CellInfo>().SetBuildInfo(_sptiteEvent, _nameEvent, _descriptionEvent);
        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            _player = collision.GetComponent<PlayerMove>().GetProfilePlayer;
            if (!_player.IsActiveEffect(StatusBar.Effect.NOTVISIBILITY))
            {
                gameObject.transform.Find("Build").gameObject.SetActive(true);
            }
            MassegeBox.StaticShowMassege(_nameEvent, _descriptionEvent, Yes, null, false, Rob());
        }

        private void Yes()
        {
            SelectionCard.StaticShowSelectionCard(3, 3, _player, new[] { Card.TypeCard.EQUIPMENT },
                new[] { Card.TypeEquipment.BODY, Card.TypeEquipment.BOOTS, Card.TypeEquipment.HEAD }, true);
        }
        private IEnumerator Rob()
        {
            DisePanel.StaticShowDisce();
            while (DisePanel.IsActivate)
            {
                yield return null;
            }
            int vallue = DisePanel.GetFinalValue;
            if (vallue < 5)
            {
                _player.GetEquipment.AddEquipment(CardMenegercr.StaticRandCard(new[] { Card.TypeCard.EQUIPMENT }));
            }
            else
            {
                _player.GetEquipment.RemoveAllСlothes();
            }
        }
    }

    public class WeaponsStore : MonoBehaviour
    {
        private string _nameEvent = "Магазинчик оружия";
        private string _descriptionEvent = "Место где можно купить оружие за монеты." +
            " Если ограбление удачно то + рандомная карта оружия, если нет, " +
            "то теряешь своё надетое оружие и 2 монеты.";
        private ProfilePlayer _player;
        private Sprite _sptiteEvent;

        private void Awake()
        {
            _sptiteEvent = Resources.Load<Sprite>("Simple Buttons/RPG_inventory_icons/Police");
            gameObject.GetComponent<CellInfo>().SetBuildInfo(_sptiteEvent, _nameEvent, _descriptionEvent);
        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            _player = collision.GetComponent<PlayerMove>().GetProfilePlayer;
            if (!_player.IsActiveEffect(StatusBar.Effect.NOTVISIBILITY))
            {
                gameObject.transform.Find("Build").gameObject.SetActive(true);
            }
            MassegeBox.StaticShowMassege(_nameEvent, _descriptionEvent, Yes, null, false, Rob());
        }

        private void Yes()
        {
            SelectionCard.StaticShowSelectionCard(3, 3, _player, new[] { Card.TypeCard.EQUIPMENT },
                new[] { Card.TypeEquipment.WEAPON },true);
        }
        private IEnumerator Rob()
        {
            DisePanel.StaticShowDisce();
            while (DisePanel.IsActivate)
            {
                yield return null;
            }
            int vallue = DisePanel.GetFinalValue;
            if (vallue > 5)
            {
                _player.GetEquipment.AddEquipment(CardMenegercr.StaticRandCard(new[] { Card.TypeCard.EQUIPMENT }));
            }
            else
            {
                _player.GetEquipment.AddWeapon(null);
            }
        }
    }

    public class Trove : MonoBehaviour
    {
        private string _nameEvent = "Клад";
        private string _descriptionEvent = "Можно открыть потратив четыре карты и получить 15 монет. " +
            "Если есть саперная лапта, откапывай благодаря ей. " +
            "Лапта остается в инвентаре. ";
        private ProfilePlayer _player;
        private Sprite _sptiteEvent;

        private void Awake()
        {
            _sptiteEvent = Resources.Load<Sprite>("Simple Buttons/RPG_inventory_icons/Police");
            gameObject.GetComponent<CellInfo>().SetBuildInfo(_sptiteEvent, _nameEvent, _descriptionEvent);
        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            _player = collision.GetComponent<PlayerMove>().GetProfilePlayer;
            if (!_player.IsActiveEffect(StatusBar.Effect.NOTVISIBILITY))
            {
                gameObject.transform.Find("Build").gameObject.SetActive(true);
            }
            MassegeBox.StaticShowMassege(_nameEvent, _descriptionEvent, Yes,null);
        }

        private void Yes()
        {
            _player.ApplyCoinDamage(-15);
            SelectionCard.StaticShowSelectionCard(4, 1, _player);
        }
    }
}
