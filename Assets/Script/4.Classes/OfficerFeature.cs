using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OfficerFeature : MonoBehaviour
{
    private bool _chekAppply = false;

    [SerializeField] private TimeBar _time= null;

    private Button _button; 


    public void ApplyFeature()
    {
        if (!_chekAppply)
        {
            float k = Random.Range(1, 6);
            Debug.Log(k);
            if (k > 4)
            {
                _time.SetStep(false);
            }
            _chekAppply = true;
        }
    }
    
   public void AttachAnEvent()
    {
        _button = GameObject.Find("NextMove").GetComponent<Button>();
        Button.ButtonClickedEvent _event = _button.onClick;
        _event.AddListener(ApplyFeature);
        _button.onClick = _event;

    }
}
