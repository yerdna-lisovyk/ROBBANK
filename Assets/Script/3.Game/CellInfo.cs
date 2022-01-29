using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellInfo : MonoBehaviour
{
    private int _cellNum;

    private Sprite _spriteBuild;
    private string _titleBuild;
    private string _descriptionBuild;

    private List<Card> _activeCard = new List<Card>();

    public Sprite GetSprite => _spriteBuild;
    public string GetNameBuild => _titleBuild;
    public string GetDescriptionBuild => _descriptionBuild;

    public bool IsHaveTrap()
    {
        return _activeCard.Count != 0;
    }

    public List<Card> GetActiveCard => _activeCard;

    public void SetCardTrap(Card card)
    {
        _activeCard.Add(card);
    }


    public void SetBuildInfo(Sprite sprite, string title, string description)
    {
        _spriteBuild = sprite;
        _titleBuild = title;
        _descriptionBuild = description;
        gameObject.transform.Find("Build").GetComponent<SpriteRenderer>().sprite = _spriteBuild;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<PlayerMove>().GetProfilePlayer;
        if (!player.IsActiveEffect(StatusBar.Effect.NO_VISIBILITY))
        {
            gameObject.transform.Find("Build").gameObject.SetActive(true); 
        }
    }
    
    
}
