
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    private TimeBar _time;
    private GameObject _cell;
    private ProfilePlayer _player;

    [SerializeField] private Button button = null;

    public ProfilePlayer GetProfilePlayer => _player;

    private void Start()
    {
        _player = GameObject.Find("GameMeneger").GetComponent<PlayerMeneger>().GetPlayer(0);
        _time = GameObject.Find("TimeBar").GetComponent<TimeBar>();
    }

    public void SetInteractional(bool Interacted)
    {
        button.interactable = Interacted;
    }
    public void Move()
    {
        _cell = CellNext();
        transform.position = new Vector3(transform.position.x + (_cell.transform.position.x - transform.position.x - 0.1f), transform.position.y, transform.position.z);
        // _player.EndTurn();
    }

    private GameObject CellNext()
    {
        _player.SetPlayerCell(_player.GetPlayerSpeed);
        string nameCellNext = "Cell_" + _player.GetPlayerCell;
        return GameObject.Find(nameCellNext);
    }

    private GameObject CellBack()
    {
        _player.SetPlayerCell(_player.GetPlayerSpeed);
        string nameCellNext = "Cell_" + _player.GetPlayerCell;
        return GameObject.Find(nameCellNext);

    }


    public void MoveToPoint(int PointMove)
    {
        _player.SetPlayerCell(PointMove);
        string nameCellNext = "Cell_" + _player.GetPlayerCell;
        _cell = GameObject.Find(nameCellNext);
        transform.position = new Vector3(transform.position.x + (_cell.transform.position.x - transform.position.x - 0.1f), transform.position.y, transform.position.z);
    }

}
