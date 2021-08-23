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
        STOP, //you can't move
        VISIBILITY, //cell visibility
        NO_VISIBILITY, // NO cell visibility
        VAGABOND,// gradual damage
        SHACKLES, 
        ARMOR_OUTFIT, 
        ONE_FOR_TWO,
        SAPPER_CLOTHING, // protects  mine and stretching
        OVERALL, //protects against tentacles, whip and pit
        BAR, //cannot attack and cannot be attacked
        BACKPACK,
        BIG_BACKPACK
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
    public static void StaticNewStatus(int Seconds, Effect Effect, ProfilePlayer player)
    {
        _instans.NewStatus(Seconds, Effect, player);
    }
    
    private void NewStatus( int Seconds, Effect Effect, ProfilePlayer player)
    {
        _player = player;
        var newStatus = Instantiate(_prefabStatus, _statusArea.transform);
        newStatus.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = EstablishSprite(Effect);
        newStatus.transform.GetComponent<TimerStatus>().StartTimer(Seconds, Effect, player);
        _player.SetActiveEffect(Effect);
        _statutes.Add(newStatus);
    }

    private Sprite EstablishSprite(Effect Effect)
    {
        switch(Effect)
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
