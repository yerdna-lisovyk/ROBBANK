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
            case StatusBar.Effect.NO_VISIBILITY:
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
        _player.DestroyStatus(effect);
        _player.NewTurn();
        Destroy(gameObject);
    }

    private IEnumerator TimerEffectVisibility(int seconds, StatusBar.Effect effect)
    {
        var cells = Cells.StaticGetCells();
        while (gameObject.transform.GetChild(0).GetComponent<Image>().fillAmount != 0)
        {
            gameObject.transform.GetChild(0).GetComponent<Image>().fillAmount -= Time.deltaTime / seconds;
            for(var i =0; i<cells.Count; i++)
            {
                var image = cells[i].transform.GetChild(0).gameObject;
                if (IsHaveTrap(cells[i]))
                {
                    image.SetActive(true);
                }
                else
                {
                    if (image.activeSelf == true)
                    {
                        image.SetActive(false);
                    }
                }
            }
            yield return null;
        }

        for (var i = 0; i < cells.Count; i++)
        {
            var image = cells[i].transform.GetChild(0).gameObject;
            if (image.activeSelf == true)
            {
                image.SetActive(false);
            }
        }
        _player.DestroyStatus(effect);
        Destroy(gameObject);
    }

    private IEnumerator TimerEffectNotVisibility(int seconds, StatusBar.Effect effect)
    {
        var cells = Cells.StaticGetCells();
        ShowAndHideBuild(cells, false);
        while (gameObject.transform.GetChild(0).GetComponent<Image>().fillAmount != 0)
        {
            gameObject.transform.GetChild(0).GetComponent<Image>().fillAmount -= Time.deltaTime / seconds;

            yield return null;
        }
        ShowAndHideBuild(cells, true);
        _player.DestroyStatus(effect);
        Destroy(gameObject);
    }
    private void ShowAndHideBuild(List<GameObject> cells,bool active)
    {
        for (var i = 0; i < cells.Count; i++)
        {
            var sprite = cells[i].transform.Find("Build").gameObject;
            if (sprite.name != "Close Button")
            {
                sprite.SetActive(active);
            }
        }
    }

    private bool IsHaveTrap(GameObject cell)
    {
        if(cell.GetComponent<Traps.ChikaTrap>())
        {
            return true;
        }
        return false;
    }


}
