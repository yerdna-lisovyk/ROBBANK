using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outfit
{
    public Outfit(GameObject icon, Card.NameEquipment TypeOutfit)
    {
        switch (TypeOutfit)
        {
            case Card.NameEquipment.BULLETPROOF_VEST:
            {
                icon.AddComponent<BulletproofVest>();
                break;
            }
        }
    }
    public class BulletproofVest : MonoBehaviour
    {
        private ProfilePlayer _player;
        
        private void Start()
        {
            _player = GameObject.Find("GameMeneger").GetComponent<PlayerMeneger>().GetPlayer(0);
            
        }
        private void OnDestroy()
        {
            
        }
    }
}
