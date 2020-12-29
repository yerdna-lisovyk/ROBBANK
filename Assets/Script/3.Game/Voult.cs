using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voult : MonoBehaviour
{
    [SerializeField]  private GameObject _voult = null;

    public bool IsOpenVoult => _voult.activeSelf;


    public void OpenVoult()
    {
        if (_voult.activeSelf)
        {
            _voult.SetActive(false);
            Camera.main.gameObject.GetComponent<CameraControl>().enabled = true;
        }
        else
        {
            _voult.SetActive(true);
            Camera.main.gameObject.GetComponent<CameraControl>().enabled = false;
        }
    }

   

}
