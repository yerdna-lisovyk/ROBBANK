using System.Collections.Generic;
using UnityEngine;

public class Cells : MonoBehaviour
{
    private static Cells _instans;
    //private float Сomplexity = 1;
    private float collSels = 50;
    // private int EventsQuantity = 10;

    private List<GameObject> _cells = new List<GameObject>();

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
    private List<GameObject> GetCells => _cells;

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
            _cells.Add(newObject);
        }
        SpawnBuild();
    }

    private void SpawnBuild()
    {
        int kolCell = 1;
        for (int i = 1; i < collSels-1; i++)
        {
            kolCell++;
            if (100/(collSels / kolCell)  >= 30)
            {
                for (int j = 0; j < 6; j++)
                {
                    new Build(_cells[i]); 
                    i++;
                }
                kolCell = 0;
            }
            else
            {
                int rand = Random.Range(1, 6);
                new Build(_cells[i], rand);
            }
        }
    }


    public void ClearCells()
    {
        for (int i = 0; i < collSels; i++)
        {
            Destroy(_cells[i]);
        }
        _cells.Clear();
    }
}
