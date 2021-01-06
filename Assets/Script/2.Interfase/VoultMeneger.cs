using UnityEngine;

public class VoultMeneger : MonoBehaviour
{
    [SerializeField]  private GameObject _voultObj = null;
    public bool IsOpenVoult => _voultObj.activeSelf;
    public GameObject GetVoult => _voultObj;

    public void OpenVoult()
    {
        
        if (_voultObj.activeSelf)
        {
            _voultObj.SetActive(false);
            Camera.main.gameObject.GetComponent<CameraControl>().enabled = true;
        }
        else
        {
            _voultObj.SetActive(true);
            Camera.main.gameObject.GetComponent<CameraControl>().enabled = false;
        }
    }

   

}
