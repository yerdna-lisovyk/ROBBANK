using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class InformationButton : MonoBehaviour
{
    private static InformationButton _instans;

    public static void StaticShowInformatinButton(GameObject icon, Transform perent)
    {
        _instans.ShowInformatinButton(icon, perent);
    }

    public static void StaticHideInformatinButton()
    {
        _instans.HideInformatinButton();
    }

    private void HideInformatinButton()
    {
        gameObject.SetActive(false);
    }


    private void Awake()
    {
        _instans = this;
        gameObject.SetActive(false);
    }

    private void ShowInformatinButton(GameObject icon, Transform perent)
    {
        if (!icon.GetComponent<CardInfo>().IsNull)
        {
            gameObject.SetActive(false);
            gameObject.SetActive(true);
            StartCoroutine(TimerHide());
            gameObject.transform.transform.SetParent(perent);
            gameObject.transform.position = new Vector2(icon.transform.position.x, icon.transform.position.y);
            if (icon.GetComponent<CardInfo>().GetCard.GetTypeEquipment == Card.TypeEquipment.BOOTS)
            {
                gameObject.transform.localScale = new Vector2(icon.transform.localScale.x/2, icon.transform.localScale.y/2);
            }
            Button button = gameObject.GetComponent<Button>();
            button.onClick.AddListener(() =>
            {
                InformationPanel.StaticShowInformationPanel(icon.GetComponent<CardInfo>().GetCard);
                gameObject.SetActive(false);
            });
        }
    }

    private IEnumerator TimerHide()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }
}
