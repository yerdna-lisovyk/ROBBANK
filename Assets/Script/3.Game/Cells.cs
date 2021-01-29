using System.Collections.Generic;
using UnityEngine;

public class Cells : MonoBehaviour
{
    private static Cells _instans;
    //private float Сomplexity = 1;
    private float collSels = 50;
    // private int EventsQuantity = 10;

    private List<GameObject> _Cells = new List<GameObject>();

    [SerializeField] private GameObject spawnPoing = null;
    [SerializeField] private GameObject cell = null;
    
    private void Awake()
    {
        _instans = this;
    }
    public static List<GameObject> StaticGetCells()
    {
        return _instans.GetCells;
    }
    private List<GameObject> GetCells => _Cells;

    public void SetcСollSels(float coll)
    {
        collSels = coll;
    }
    public void SpawnCell()
    {
        for (int i = 0; i < collSels; i++)
        {
            Vector3 V = spawnPoing.transform.position;
            GameObject newObject = Instantiate(cell, new Vector3(V.x + 1f * i, V.y, V.z), Quaternion.identity);
            newObject.name = "Cell_" + (i + 1);
            _Cells.Add(newObject);
            Build tmp = new Build(newObject);
        }

    }


    public void ClearCells()
    {
        for (int i = 0; i < collSels; i++)
        {
            Destroy(_Cells[i]);
        }
        _Cells.Clear();
    }
}
