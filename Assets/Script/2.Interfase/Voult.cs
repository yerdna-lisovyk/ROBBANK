using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voult : MonoBehaviour
{
    [SerializeField]  private GameObject _voult;

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

        /* if (newObject == null)
         {
             Camera.main.gameObject.GetComponent<CameraControl>().enabled = false;
             newObject = (GameObject)Instantiate(Prefab, GameObject.Find("SpawnObject").transform.position, Quaternion.identity);
             newObject.transform.SetParent(canvas.transform, false);
             newObject.transform.SetSiblingIndex(0);
             FixTransoform(Prefab.GetComponent<RectTransform>(), newObject.GetComponent<RectTransform>());
         }*/


    }

   

}
