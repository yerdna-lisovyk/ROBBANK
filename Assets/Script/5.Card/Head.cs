using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Head
{
    public Head(GameObject icon, Card.NameEquipment TypeHead)
    {
        switch (TypeHead)
        {
            case Card.NameEquipment.OVERALL:
            {
                icon.AddComponent<Overall>();
                break;
            }
        }
    }
    public class Overall : MonoBehaviour
    {
        private ProfilePlayer _player;
        private void Start()
        {
            _player = GameObject.Find("GameMeneger").GetComponent<PlayerMeneger>().GetPlayer(0);
            _player.SetActiveEffect(StatusBar.Effect.OVERALL);
        }
        
        private void OnDestroy()
        {
            _player.DestroyStatus(StatusBar.Effect.OVERALL);
        }
    }
    
    public class Pan : MonoBehaviour
    {
        private ProfilePlayer _player;
        private void Start()
        {
            _player = GameObject.Find("GameMeneger").GetComponent<PlayerMeneger>().GetPlayer(0);
            _player.SetActiveEffect(StatusBar.Effect.OVERALL);
        }
        
        private void OnDestroy()
        {
            _player.DestroyStatus(StatusBar.Effect.OVERALL);
        }
    }
}
