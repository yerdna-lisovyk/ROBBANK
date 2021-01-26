using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Build
{
    public Build(GameObject cell)
    {
        cell.AddComponent<BlackMarket>();
    }
    private class PoliceDepartment : MonoBehaviour
    {
        private string _nameEvent = "Полицейский пост";
        private string _descriptionEvent = "Отдатдать две монеты ?Иначе две карты.";
        private ProfilePlayer _player;
        private int _removeCard;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            _player = collision.GetComponent<PlayerMove>().GetProfilePlayer;
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
                    StatusBar.StaticNewStatus(Resources.Load<Sprite>("Simple Buttons/RPG_inventory_icons/Police"), 30, Traps.Effect.STOP, _player);
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

    private class BlackMarket : MonoBehaviour
    {
        private string _nameEvent = "Черный рынок";
        private string _descriptionEvent = "Заплати монету, чтобы достать 3 карты и выбрать одну. " +
            "Заплати 10 монет, чтобы получить рандомно раритетное оружие или одежду. " +
            "Не пытайся ограбить! Если ты всё же хочешь ограбить, то в случае не удачи расстанься " +
            "со всем своим имуществом, а если улыбнется удача, то получи 10 монет и карту оружия или одежды." +
            " Не действуют карты отмены.";
        private ProfilePlayer _player;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            _player = collision.GetComponent<PlayerMove>().GetProfilePlayer;
            MassegeBox.StaticShowMassege(_nameEvent, _descriptionEvent, Yes, No, true, Rob());
        }

        private void Yes()
        {
            _player.ApplyCoinDamage(-1);
            SelectionCard.StaticShowSelectionCard(3, 1,_player.GetInvetory, Card.TypeCard.INVENTORY);
        }
        private void No()
        {
            _player.ApplyCoinDamage(-10);
            _player.GetEquipment.AddEquipment(CardMenegercr.StaticRandCard(Card.TypeCard.EQUIPMENT));
        }
        private IEnumerator Rob()
        {
            DisePanel.StaticShowDisce();
            while (DisePanel.IsActivate)
            {
                yield return new WaitForSeconds(0.04f);
            }
            int vallue = DisePanel.GetFinalValue;
            if (vallue < 6)
            {
                _player.GetEquipment.RemoveAllEquipment();
                _player.GetInvetory.RemoveAllCard();
                Tooltip.ShowTooltip_Static(_nameEvent, "Вы потеряли всё!");
            }
            else
            {
                _player.ApplyCoinDamage(10);
                _player.GetEquipment.AddEquipment(CardMenegercr.StaticRandCard(Card.TypeCard.EQUIPMENT));
            }
        }
    }
}
