using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class TimerStatus : MonoBehaviour
{
    private ProfilePlayer _player;

    public void StartTimer(int seconds, StatusBar.Effect effect, ProfilePlayer player)
    {
        _player = player;
        switch (effect)
        {
            case StatusBar.Effect.STOP:
                {
                    StartCoroutine(TimerEffectStop(seconds, effect));
                    break;
                }
            case StatusBar.Effect.VISIBILITY:
                {
                    StartCoroutine(TimerEffectVisibility(seconds,effect));
                    break;
                }
        }
    }
    private IEnumerator TimerEffectStop(int seconds, StatusBar.Effect effect)
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

    private IEnumerator TimerEffectVisibility(int seconds, StatusBar.Effect effect)
    {
        List <GameObject> cells = Cells.StaticGetCells();
        while (gameObject.transform.GetChild(0).GetComponent<Image>().fillAmount != 0)
        {
            gameObject.transform.GetChild(0).GetComponent<Image>().fillAmount -= Time.deltaTime / seconds;
            for(int i =0; i<cells.Count; i++)
            {
                GameObject SpriteImage = cells[i].transform.GetChild(0).gameObject;
                if (IsHaveTrap(cells[i]))
                {
                    SpriteImage.SetActive(true);
                }
                else
                {
                    if (SpriteImage.activeSelf == true)
                    {
                        SpriteImage.SetActive(false);
                    }
                }
            }
            yield return null;
        }

        for (int i = 0; i < cells.Count; i++)
        {
            GameObject SpriteImage = cells[i].transform.GetChild(0).gameObject;
            if (SpriteImage.activeSelf == true)
            {
                SpriteImage.SetActive(false);
            }
        }
        StatusBar.StaticDestroyStatus(effect);
        Destroy(gameObject);
    }

    private bool IsHaveTrap(GameObject cell)
    {
        if(cell.GetComponent<Traps.ChikaTrap>() !=null)
        {
            return true;
        }
        return false;
    }


}
