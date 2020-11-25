using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voult : MonoBehaviour
{

    private GameObject newObject;
    private GameObject Prefab;
    private GameObject canvas;


    private void Awake()
    {
        Prefab = (GameObject)Resources.Load("Voult");
        canvas = GameObject.Find("HUD");
    }
    public void OpenVoult()
    {

        if (newObject == null)
        {
            newObject = (GameObject)Instantiate(Prefab, GameObject.Find("SpawnObject").transform.position, Quaternion.identity);
            newObject.transform.SetParent(canvas.transform, false);
            newObject.transform.SetSiblingIndex(0);
            FixTransoform(Prefab.GetComponent<RectTransform>(), newObject.GetComponent<RectTransform>());
        }
        else
        {
            if (newObject.activeSelf)
                newObject.SetActive(false);
            else
                newObject.SetActive(true);

        }
    }

    private void FixTransoform(RectTransform rectTransform, RectTransform objRectTransform)
    {
        objRectTransform.anchorMin = rectTransform.anchorMin;
        objRectTransform.anchorMax = rectTransform.anchorMax;
        objRectTransform.anchoredPosition = rectTransform.anchoredPosition;
        objRectTransform.sizeDelta = rectTransform.sizeDelta;
    }
    private void Update()
    {
        if(newObject!=null)
        {
            Camera.main.gameObject.GetComponent<CameraControl>().enabled = false;
        }

    }
}
