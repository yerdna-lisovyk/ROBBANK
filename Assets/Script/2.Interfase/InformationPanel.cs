using UnityEngine;
using UnityEngine.UI;

public class InformationPanel : MonoBehaviour
{
    private static InformationPanel _instans;

    private Text _descriptionCard;
    private Text _nameCard;
    private Text _typeCard;
    private Text _priseCard;
    private Image _spriteCard;
    private Button _exit;


    public static void StaticShowInformationPanel(Card card)
    {
        _instans.ShowInformationPanel(card);
    }

    private void Awake()
    {
        _instans = this;

        _nameCard = transform.Find("Border").GetChild(0).GetComponent<Text>();
        _descriptionCard = transform.Find("Description").GetChild(0).GetComponent<Text>();
        _typeCard = transform.Find("Type").GetChild(0).GetComponent<Text>();
        _priseCard = transform.Find("Prise").GetChild(0).GetComponent<Text>();
        _spriteCard = transform.Find("CardImage").GetChild(0).GetComponent<Image>();
        _exit = transform.Find("Exit").GetComponent<Button>();

        _exit.onClick.AddListener(() =>
        {
            HideInformationPanel();
        });
        HideInformationPanel();
    }

    private void ShowInformationPanel(Card card)
    {
        gameObject.SetActive(true);
        _nameCard.text = card.GetName;
        _spriteCard.sprite = card.GetSprite;
        _descriptionCard.text = card.GetDescription;
        _typeCard.text = card.GetTypeCard.ToString();
        _priseCard.text = card.GetPrise.ToString();
    }

    private void HideInformationPanel()
    {
        gameObject.SetActive(false);
    }    
}
