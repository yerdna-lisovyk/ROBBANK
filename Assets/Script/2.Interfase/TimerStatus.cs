using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimerStatus : MonoBehaviour
{
    private ProfilePlayer _player;

    public void StartTimer(int seconds, Traps.Effect effect, ProfilePlayer player)
    {
        _player = player;
        StartCoroutine(Timer(seconds, effect));
    }
    private IEnumerator Timer(int seconds, Traps.Effect effect)
    {
        _player.EndTurn();
        while (gameObject.transform.GetChild(0).GetComponent<Image>().fillAmount != 0)
        {
            gameObject.transform.GetChild(0).GetComponent<Image>().fillAmount -= Time.deltaTime / seconds;
            yield return null;
        }
        StatusBar.StaticDestroyStatus(effect);
        _player.NewTurn();
        Destroy(gameObject);

    }

}
