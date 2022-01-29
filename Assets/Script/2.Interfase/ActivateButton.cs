using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ActivateButton : MonoBehaviour
{
    private static ActivateButton _instans;
    
    public static void StaticShowActivateButton(GameObject icon, Transform perent)
    {
        _instans.ShowActivateButton(icon, perent);
    }

    public static void StaticHideActivateButton()
    {
        _instans.HideActivateButton();
    }

    private void HideActivateButton()
    {
        gameObject.SetActive(false);
    }


    private void Awake()
    {
        _instans = this;
        gameObject.SetActive(false);
    }

    private void ShowActivateButton(GameObject icon, Transform parent)
    {
        if (!icon.GetComponent<CardInfo>().IsNull)
        {
            gameObject.SetActive(false);
            gameObject.SetActive(true);
            StartCoroutine(TimerHide());
            GameObject obj;
            (obj = gameObject).transform.transform.SetParent(parent);
            var position = icon.transform.position;
            obj.transform.position = new Vector2(position.x, position.y+80f);
            
            if (icon.GetComponent<CardInfo>().GetCard.GetTypeEquipment == Card.TypeEquipment.BOOTS)
            {
                var localScale = icon.transform.localScale;
                gameObject.transform.localScale = new Vector2(localScale.x/2, localScale.y/2);
            }
            Button button = gameObject.GetComponent<Button>();
            button.onClick.AddListener(() =>
            {
                icon.GetComponent<CardInfo>().GetCard.GetAction();
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
