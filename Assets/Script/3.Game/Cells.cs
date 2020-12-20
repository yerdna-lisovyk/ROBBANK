using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cells : MonoBehaviour
{
    //private float Сomplexity = 1;
    private float collSels = 50;
    private int EventsQuantity = 10;

    private List<GameObject> _Cells = new List<GameObject>();

    [SerializeField] private GameObject spawnPoing = null;
    [SerializeField] private GameObject cell = null;

    public void SetcСollSels (float coll)
    {
        collSels = coll;
    }
    public void SpawnCell()
    {
        GameObject canvas = GameObject.Find("HUD");
        for (int i = 0; i < collSels; i++)
        {
            Vector3 V = spawnPoing.transform.position;
            GameObject newObject = Instantiate(cell, new Vector3(V.x + 1f * i, V.y, V.z), Quaternion.identity);
            newObject.name = "Cell_" + (i + 1);
            _Cells.Add(newObject);

        }
        AddEvents();
    }

    private void AddEvents()
    {
        for (int i = 0; i < EventsQuantity; i++)
        {
            int k = 0;
            do
            {
                k = Random.Range(1, (int)collSels-1);
            } while (_Cells[k].GetComponent<Event>() != null);
            _Cells[k].AddComponent<Event>();
        }
    }
    public void ClearCells()
    {
        for (int i = 0; i < EventsQuantity; i++)
        {
            Destroy(_Cells[i]);
        }
        _Cells.Clear();
    }
}
