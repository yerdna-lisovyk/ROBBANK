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
            case StatusBar.Effect.NOTVISIBILITY:
                {
                    StartCoroutine(TimerEffectNotVisibility(seconds, effect));
                    break;
                }
            case StatusBar.Effect.VAGABOND:
                {
                    StartCoroutine(TimerEffectVagabond(seconds,effect, player));
                    break;
                }
        }
    }
    private IEnumerator TimerEffectVagabond(float seconds ,StatusBar.Effect effect, ProfilePlayer player)
    {
        gameObject.GetComponent<Button>().onClick.AddListener(()=>InformationEffect.Vagabon.VagabonMassage(_player));
        while (!InformationEffect.Vagabon._massgeYes)
        {
            yield return null;
        }
        Destroy(gameObject);
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

    private IEnumerator TimerEffectNotVisibility(int seconds, StatusBar.Effect effect)
    {
        List<GameObject> cells = Cells.StaticGetCells();
        ShowAndHideBuild(cells, false);
        while (gameObject.transform.GetChild(0).GetComponent<Image>().fillAmount != 0)
        {
            gameObject.transform.GetChild(0).GetComponent<Image>().fillAmount -= Time.deltaTime / seconds;

            yield return null;
        }
        ShowAndHideBuild(cells, true);
        StatusBar.StaticDestroyStatus(effect);
        Destroy(gameObject);
    }
    private void ShowAndHideBuild(List<GameObject> cells,bool active)
    {
        for (int i = 0; i < cells.Count; i++)
        {
            GameObject SpriteImage = cells[i].transform.Find("Build").gameObject;
            if (SpriteImage.name != "Close Button")
            {
                SpriteImage.SetActive(active);
            }
        }
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
