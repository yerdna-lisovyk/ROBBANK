using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Build
{
    public Build(GameObject cell)
    {
        cell.AddComponent<PoliceDepartment>();
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
            SecectionPanel.StaticShowSecectionPanel();
            StartCoroutine(IsActivePanel());
            _removeCard = 0;
        }
        private IEnumerator IsActivePanel()
        {
            while (SecectionPanel.IsActivate)
            {
                yield return new WaitForSeconds(0.04f);
            }
            int vallue = SecectionPanel.GerFinalValue;
            if (vallue > 3) Tooltip.ShowTooltip_Static(_nameEvent, "Вы свободны");
            else
            {
                if (_player.GetInvetory.QuantityCard() < 2 && _player.GetCoin <= 2)
                {
                    StatusBar.StaticNewStatus(Resources.Load<Sprite>("Simple Buttons/RPG_inventory_icons/apple"), 30, Traps.Effect.STOP, _player);
                }
                else
                if (_player.GetInvetory.QuantityCard() < 2)
                {
                    Yes();
                    Tooltip.ShowTooltip_Static(_nameEvent, "Вы отдали : " + 2 + " Монеты");
                }
                else
                if (_player.GetCoin <= 2)
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

}
