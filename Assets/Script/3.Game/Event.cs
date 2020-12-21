using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour
{
  //  private TrapControll _trap = null;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Игров евенте");
    }
}
