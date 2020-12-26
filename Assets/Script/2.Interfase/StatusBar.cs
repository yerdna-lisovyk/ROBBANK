using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusBar : MonoBehaviour
{
    private GameObject _prefabStatus;
    private GameObject _statusArea;
    private List<GameObject> _statutes = new List<GameObject>();


    private void Start()
    {
        _statusArea = GameObject.Find("StatusArea");
        _prefabStatus = Resources.Load<GameObject>("Object/Starus");
    }

    public void NewStatus(Sprite StatusSprite)
    {
        GameObject NewStatus = Instantiate(_prefabStatus, _statusArea.transform);
        NewStatus.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = StatusSprite;
        _statutes.Add(NewStatus);
    }
}
