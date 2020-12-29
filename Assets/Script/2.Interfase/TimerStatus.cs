using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimerStatus : MonoBehaviour
{
    private StatusBar _statusBar;
    private ProfilePlayer _player;

    private void Awake()
    {
        _statusBar = GameObject.Find("StatusArea").GetComponent<StatusBar>();
    }
    public void StartTimer(int seconds, Traps.EffectTrap effect, ProfilePlayer player)
    {
        _player = player;
        StartCoroutine(Timer(seconds, effect));
    }
    private IEnumerator Timer(int seconds,Traps.EffectTrap effect)
    {
        _player.SetStep(true);
        while (gameObject.transform.GetChild(0).GetComponent<Image>().fillAmount!=0)
        {
            gameObject.transform.GetChild(0).GetComponent<Image>().fillAmount -= Time.deltaTime/seconds;
            yield return null;
        }
        _statusBar.DestroyStatus(effect);
        _player.SetStep(false);
        Destroy(gameObject);
        
    }

}
