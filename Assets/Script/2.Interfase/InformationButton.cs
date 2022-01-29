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
            GameObject obj;
            (obj = gameObject).transform.transform.SetParent(perent);
            var position = icon.transform.position;
            obj.transform.position = new Vector2(position.x, position.y);
            if (icon.GetComponent<CardInfo>().GetCard.GetTypeEquipment == Card.TypeEquipment.BOOTS)
            {
                var localScale = icon.transform.localScale;
                gameObject.transform.localScale = new Vector2(localScale.x/2, localScale.y/2);
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
