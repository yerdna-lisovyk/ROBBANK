using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class schoolboyFeature : MonoBehaviour
{
    private ProfilePlayer _profile=null;
    private GameObject _gameMeneger;

    private void Start()
    {
        _profile =GameObject.Find("Profile_1").GetComponent<ProfilePlayer>();
        _gameMeneger = GameObject.Find("GameMeneger");
    }
    private void Update()
    {
        if (_profile.GetCoin <= 0)
        {
            float k = Random.Range(1, 6);
            Debug.Log(k);
            if (k > 4)
            {
                _profile.SetPlayerCoin(1);
            }
            else
            {
                Destroy(_gameMeneger.GetComponent<schoolboyFeature>());
                Debug.Log("YourDed");
            }

        }
    }
    public void AttachAnEvent()
    {
        _gameMeneger = GameObject.Find("GameMeneger");
        _gameMeneger.AddComponent<schoolboyFeature>();
    }
}
