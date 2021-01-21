using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    private static Tooltip _instanse;

    private Text _tooltipText;
    private Text _tooltipHead;
    private RectTransform _backgroundRectTrancform;

    private void Awake()
    {
        _instanse = this;
        _backgroundRectTrancform = transform.Find("Background").GetComponent<RectTransform>();
        _tooltipText = transform.Find("Descriptionn").GetComponent<Text>();
        _tooltipHead = transform.Find("Name").GetComponent<Text>();
        HideTooltip();
    }
    private void ShowTooltip(string tooltipName, string tooltipDescriptionn)
    {
        HideTooltip();
        StopCoroutine(SetCollider());

        gameObject.SetActive(true);

        _tooltipText.text = tooltipName;
        _tooltipHead.text = tooltipDescriptionn;

        float textPaddingSize = 5f;
        Vector2 backgroundSize = new Vector2(_tooltipHead.preferredWidth + textPaddingSize * 2f, _tooltipHead.preferredHeight + _tooltipText.preferredHeight + textPaddingSize * 2f);
        _backgroundRectTrancform.sizeDelta = backgroundSize;

        _tooltipHead.color = new Color(1f, 1f, 1f);
        _tooltipText.color = new Color(1f, 1f, 1f);
        transform.Find("Background").GetComponent<Image>().color = new Color(1f, 1f, 1f);

        StartCoroutine(SetCollider());
    }
    private IEnumerator SetCollider()
    {
        yield return new WaitForSeconds(1.5f);
        for (float f = 0.01f; f <= 1; f += 0.01f)
        {
            Color color = new Color(1f, 1f, 1f);
            color.a = color.a - f;
            _tooltipHead.color = color;
            _tooltipText.color = color;
            transform.Find("Background").GetComponent<Image>().color = color;
            yield return new WaitForSeconds(0.01f);
        }
        HideTooltip();
    }
    private void HideTooltip()
    {
        gameObject.SetActive(false);
    }

    public static void ShowTooltip_Static(string tooltipName, string tooltipDescriptionn)
    {
        _instanse.ShowTooltip(tooltipName, tooltipDescriptionn);
    }

    public static void HideTooltip_Static()
    {
        _instanse.HideTooltip();
    }
}
