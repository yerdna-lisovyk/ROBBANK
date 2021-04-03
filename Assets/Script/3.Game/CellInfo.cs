using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellInfo : MonoBehaviour
{
    private int _cellNum;

    private Sprite _spriteBuild;
    private string _nameBuild;
    private string _descriptionBuild;

    private List<Card> _activeCard = new List<Card>();

    public Sprite GetSprite => _spriteBuild;
    public string GetNameBuild => _nameBuild;
    public string GetDescriptionBuild => _descriptionBuild;

    public bool IsHaveTrap ()
    {
        if (_activeCard.Count != 0) return true;
        return false;
    }

    public List<Card> GetActiveCard => _activeCard;

    public void SetCardTrap(Card card)
    {
        _activeCard.Add(card);
    }

    public void SetBuildInfo(Sprite sprite, string name,string description)
    {
        _spriteBuild = sprite;
        _nameBuild = name;
        _descriptionBuild = description;
        Debug.Log(gameObject.transform.Find("Build").GetComponent<SpriteRenderer>().sprite);
        gameObject.transform.Find("Build").GetComponent<SpriteRenderer>().sprite = _spriteBuild;
        Debug.Log(gameObject.transform.Find("Build").GetComponent<SpriteRenderer>().sprite);
    }
}
