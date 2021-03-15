
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    private TimeBar _time;
    private GameObject cell;
    private ProfilePlayer _player;

    [SerializeField] private Button _button = null;

    public ProfilePlayer GetProfilePlayer => _player;

    private void Start()
    {
        _player = GameObject.Find("GameMeneger").GetComponent<PlayerMeneger>().GetPlayer(0);
        _time = GameObject.Find("TimeBar").GetComponent<TimeBar>();
    }

    public void SetInteractebal(bool Interactebal)
    {
        _button.interactable = Interactebal;
    }
    public void Move()
    {
        cell = CellNext();
        transform.position = new Vector3(transform.position.x + (cell.transform.position.x - transform.position.x - 0.1f), transform.position.y, transform.position.z);
       // _player.EndTurn();
    }

    private GameObject CellNext()
    {
        _player.SetPlayerCell(_player.GetPlayerSpeed);
        string NameCellNext = "Cell_" + _player.GetPlayerCell;
        return GameObject.Find(NameCellNext);
    }

    private GameObject CellBack()
    {
        _player.SetPlayerCell(_player.GetPlayerSpeed);
        string NameCellNext = "Cell_" + _player.GetPlayerCell;
        return GameObject.Find(NameCellNext);

    }


    public void MoveToPoint(int PointMove)
    {
        _player.SetPlayerCell(PointMove);
        string NameCellNext = "Cell_" + _player.GetPlayerCell;
        cell = GameObject.Find(NameCellNext);
        transform.position = new Vector3(transform.position.x + (cell.transform.position.x - transform.position.x - 0.1f), transform.position.y, transform.position.z);
    }

}
