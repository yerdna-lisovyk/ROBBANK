using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sting_lobby : MonoBehaviour
{

    private TimeBar _time;
    private Cells _cells;
    [SerializeField] private GameObject Panel = null;


    public void StartGame()
    {
        _cells.SpawnCell();
        Camera.main.gameObject.GetComponent<CameraControl>().enabled = true;
        Panel.SetActive(false);
        GameObject.Find("ButtonLobby").SetActive(false);
        GameObject.Find("Player").SetActive(true);
        _time.enabled = true;
    }

    private void Awake()
    {
        _cells = GameObject.Find("SpawnClell").GetComponent<Cells>();
        Camera.main.gameObject.GetComponent<CameraControl>().enabled = false;
        _time = GameObject.Find("TimeBar").GetComponent<TimeBar>();
    }

    public void collSelsto_min()
    {
        _cells.SetcСollSels(50);
    }
    public void collSelsto_max()
    {
        _cells.SetcСollSels(100);
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
