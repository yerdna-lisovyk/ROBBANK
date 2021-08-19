using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusBar : MonoBehaviour
{
    public enum TriggeredEffects
    {
        TR_SHACKLES
    }
    public enum Effect
    {
        STOP,
        VISIBILITY,
        NO_VISIBILITY,
        VAGABOND,
        SHACKLES
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
    
    private void NewStatus( int Seconds, Effect effect, ProfilePlayer player)
    {
        _player = player;
        var newStatus = Instantiate(_prefabStatus, _statusArea.transform);
        newStatus.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = EstablishSprite(effect);
        newStatus.transform.GetComponent<TimerStatus>().StartTimer(Seconds, effect, player);
        _player.SetActiveEffect(effect);
        _statutes.Add(newStatus);
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
            case Effect.NO_VISIBILITY:
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
    



}
