using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Setting_box : MonoBehaviour
{
    [SerializeField] private GameObject Panel=null;


    public void OpenSetting()
    {

        if(Panel != null)
        {
            ButtonsOnOff(false);
            Panel.SetActive(true);
        }
    }

    private void ButtonsOnOff(bool f)
    {
        Button[] buttons = FindObjectsOfType<Button>();
        foreach (var item in buttons)
        {
            item.enabled = f; // отключаем кнопку
        }

    }

    public void Quit()
    {
        ButtonsOnOff(true);
        Panel.SetActive(false);
    }
    public void Volume_Setting()
    {
        if (AudioListener.volume == 0)
        {
            GameObject.Find("ButtonVolume").GetComponent<Image>().sprite = Resources.Load<Sprite>("ButtonsStyle13_23");
            AudioListener.volume = 1;
        }
        else
        {
            GameObject.Find("ButtonVolume").GetComponent<Image>().sprite = Resources.Load<Sprite>("ButtonsStyle13_22");
            AudioListener.volume = 0;
        }

    }
}
