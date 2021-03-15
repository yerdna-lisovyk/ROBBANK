using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusBar : MonoBehaviour
{
    public enum Effect
    {
        STOP,
        VISIBILITY,
        NOTVISIBILITY,
        VAGABOND
    }

    private static StatusBar _instans;
    private GameObject _prefabStatus;
    private ProfilePlayer _player;
    private GameObject _statusArea;
    private List<GameObject> _statutes = new List<GameObject>();

    private void Start()
    {
        _statusArea = GameObject.Find("StatusArea");
        _prefabStatus = Resources.Load<GameObject>("Object/Starus");
        _instans = this;
    }
    public static void StaticNewStatus(int Seconds, Effect effect, ProfilePlayer player)
    {
        _instans.NewStatus(Seconds, effect, player);
    }

    public static void StaticDestroyStatus(Effect Effect)
    {
        _instans.DestroyStatus(Effect);
    }
    private void NewStatus( int Seconds, Effect effect, ProfilePlayer player)
    {
        _player = player;
        GameObject NewStatus = Instantiate(_prefabStatus, _statusArea.transform);
        NewStatus.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = EstablishSprite(effect);
        NewStatus.transform.GetComponent<TimerStatus>().StartTimer(Seconds, effect, player);
        _player.GetActiveEffect.Add(effect);
        _statutes.Add(NewStatus);
    }

    private Sprite EstablishSprite(Effect effect)
    {
        switch(effect)
        {
            case Effect.STOP:
                {
                    return Resources.Load<Sprite>("Pause");
                }
            case Effect.VISIBILITY:
                {
                    return Resources.Load<Sprite>("eye");
                }
            case Effect.NOTVISIBILITY:
                {
                    return Resources.Load<Sprite>("NonEye");
                }
            case Effect.VAGABOND:
                {
                    return Resources.Load<Sprite>("VAGABOND");
                }
        }
        return null;
    }

    private void DestroyStatus(Effect Effect)
    {
        for (int i = 0; i < _player.GetActiveEffect.Count; i++)
        {
            if (_player.GetActiveEffect[i] == Effect)
            {
                _player.GetActiveEffect.RemoveAt(i);
                break;
            }
        }
    }

    private void DestroyAllStates()
    {
        _player.GetActiveEffect.Clear();
        foreach (var status in _statutes)
        {
            Destroy(status);
        }
    }

}
