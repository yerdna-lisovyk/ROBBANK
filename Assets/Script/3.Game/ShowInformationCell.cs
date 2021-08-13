using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInformationCell : MonoBehaviour
{
    private List<Card> _activeCard;
    private void OnMouseDown()
    {
        _activeCard = transform.parent.GetComponent<CellInfo>().GetActiveCard;
        InformationCellBox.StaticShowInformationPanel(_activeCard);
    }
}
