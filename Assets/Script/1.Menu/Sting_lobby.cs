using UnityEngine;

public class Sting_lobby : MonoBehaviour
{

    private TimeBar _time;
    private Cells _cells;
    [SerializeField] private GameObject Panel = null;

    /* Старт таймера поиск игроков и генерации клеток, включение движения камеры */
    public void StartGame()
    {
        _cells.SpawnCell();
        Camera.main.gameObject.GetComponent<CameraControl>().enabled = true;
        Panel.SetActive(false);
        GameObject.Find("ButtonLobby").SetActive(false);
        GameObject.Find("Player").SetActive(true);
        _time.StartTimer();
    }

    private void Awake()
    {
        _cells = GameObject.Find("SpawnClell").GetComponent<Cells>();
        Camera.main.gameObject.GetComponent<CameraControl>().enabled = false;
        _time = GameObject.Find("TimeBar").GetComponent<TimeBar>();
    }

    public void collSelsto_min()
    {
        _cells.SetAmountCells(50);
    }
    public void collSelsto_max()
    {
        _cells.SetAmountCells(100);
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
