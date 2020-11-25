using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sting_lobby : Cells
{

    private TimeBar _time;

    [SerializeField] private ProfilePlayer _profile = null;
    [SerializeField] private GameObject Panel = null;

    public void StartGame()
    {
        SpawnCell();
        Camera.main.gameObject.GetComponent<CameraControl>().enabled = true;
        Panel.SetActive(false);
        GameObject.Find("ButtonLobby").SetActive(false);
        GameObject.Find("Player").SetActive(true);
        _time.enabled = true;
        _profile.SetClass();

    }



    private void Start()
    {
        Camera.main.gameObject.GetComponent<CameraControl>().enabled = false;
        _time = GameObject.Find("TimeBar").GetComponent<TimeBar>();
    }

    public void collSelsto_min()
    {
        SetcСollSels(50);
    }
    public void collSelsto_max()
    {
        SetcСollSels(100);
    }

    public void Back()
    {
        if (Panel.activeSelf)
            Panel.SetActive(false);
        else
            Panel.SetActive(true);
    }
    public void EndGame()
    {

        _time.enabled = false;
    }
}
