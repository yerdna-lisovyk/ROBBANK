using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusBar : MonoBehaviour
{
    private GameObject _prefabStatus;
    private ProfilePlayer _player;
    private GameObject _statusArea;
    private List<GameObject> _statutes = new List<GameObject>();

    private void Start()
    {
        
        _statusArea = GameObject.Find("StatusArea");
        _prefabStatus = Resources.Load<GameObject>("Object/Starus");
    }

    public void NewStatus(Sprite StatusSprite,int Seconds,Traps.EffectTrap effect , ProfilePlayer player)
    {
        _player = player;
        GameObject NewStatus = Instantiate(_prefabStatus, _statusArea.transform);
        NewStatus.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = StatusSprite;
        NewStatus.transform.GetComponent<TimerStatus>().StartTimer(Seconds,effect,player);
        _player.GetActiveEffect.Add(effect);
        _statutes.Add(NewStatus);
    }
    public void DestroyStatus(Traps.EffectTrap EffectTrap)
    {
        for(int i =0;i< _player.GetActiveEffect.Count; i++)
        {
            if(_player.GetActiveEffect[i] == EffectTrap)
            {
                _player.GetActiveEffect.RemoveAt(i);
                break;
            }
        }
    }

    private void DestroyAllStates()
    {
        _player.GetActiveEffect.Clear();
        foreach(var status in _statutes)
        {
            Destroy(status);
        }    
    }

}
