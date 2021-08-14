using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InformationCellBox : MonoBehaviour
{
    private static InformationCellBox _instans;
    
    private Transform _content;
    private GameObject _panel;
    private GameObject _template;
    
    private Image _spriteCard;
    private Text _descriptionCell;

    public static bool IsActivePanel => _instans.gameObject.activeSelf;
    private void Awake()
    {
        _instans = this;
        _template = Resources.Load<GameObject>("Object/Information");
        gameObject.SetActive(false);
        
    }
    public static void StaticShowInformationPanel(List<Card> сards)
    {
        _instans.ShowInformationCellBox(сards);
    }
    public void PubHideInformationCellBox()
    {
        _instans.HideInformationCellBox();
    }
    
    private void ShowInformationCellBox (List<Card> сards)
    {
        _content = transform.GetChild(0).GetChild(0).GetChild(0);
        foreach (var card in сards)
        {
            _panel = Instantiate(_instans._template, _content);
            _spriteCard = _panel.transform.Find("Image").GetComponent<Image>();
            _descriptionCell = _panel.transform.Find("Panel").GetChild(0).GetComponent<Text>();
            _spriteCard.sprite = card.GetSprite;
            _descriptionCell.text = card.GetDescription;
        }
        gameObject.SetActive(true);
        
    } 
    private void HideInformationCellBox ()
    {
        foreach (Transform child in _content.transform)
        {
            Destroy(child.gameObject);
        }
        gameObject.SetActive(false);
    }    
}
