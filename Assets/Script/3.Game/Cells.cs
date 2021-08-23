using System.Collections.Generic;
using UnityEngine;

public class Cells : MonoBehaviour
{
    private static Cells _instans;
    //private float Сomplexity = 1;
    private float _collCells = 50;
    // private int EventsQuantity = 10;

    private List<GameObject> _cells = new List<GameObject>();

    [SerializeField] private GameObject spawnPoint = null;
    [SerializeField] private GameObject cell = null;
    
    public static List<GameObject> StaticGetCells()
    {
        return _instans.GetCells;
    }
    public static GameObject[] StaticGetCellsOfRange(int first,int second)
    {
        return _instans.GetCellsOfRange(first, second);
    }
    public void SetAmountCells(float coll)
    {
        _collCells = coll;
    }
    public void SpawnCell()
    {
        for (int i = 0; i < _collCells; i++)
        {
            Vector3 spawnRage = spawnPoint.transform.position;
            GameObject newObject = Instantiate(cell, new Vector3(spawnRage.x + 1f * i, spawnRage.y, spawnRage.z), Quaternion.identity);
            newObject.name = "Cell_" + (i + 1);
            _cells.Add(newObject);
        }
        SpawnBuild();
    }

    private List<GameObject> GetCells => _cells;


    private GameObject[] GetCellsOfRange(int first,int second)
    {
        int size = second - first;
        GameObject[] cellsRange = new GameObject[size];

        for (int i = first, k = 0; i <second; i++, k++)
        {
            cellsRange[k] = _cells[i];
        }

        return cellsRange;
    }
    private void Awake()
    {
        _instans = this;
    }
    private void SpawnBuild()
    {
        int kolCell = 1;
        for (int i = 1; i < _collCells-1; i++)
        {
            kolCell++;
            if (100/(_collCells / kolCell)  >= 30)
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
                var rand = Random.Range(1, 6);
                new Build(_cells[i], rand);
            }
        }
    }


    public void ClearCells()
    {
        for (int i = 0; i < _collCells; i++)
        {
            Destroy(_cells[i]);
        }
        _cells.Clear();
    }
}
