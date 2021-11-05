using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon 
{
    public Weapon(GameObject icon, Card.NameEquipment TypeWeapon)
    {
        switch (TypeWeapon)
        {
            case Card.NameEquipment.PISTOL:
            {
                icon.AddComponent<Pistol>();
                break;
            }
        }
    }
    public class Pistol : MonoBehaviour
    {
        private ProfilePlayer _player;
        private void Start()
        {
            _player = GameObject.Find("GameMeneger").GetComponent<PlayerMeneger>().GetPlayer(0);
            _player.SetWeaponRange(3);
            Debug.Log(_player.GetWeaponRange);
        }
        
        private void OnDestroy()
        {
            _player.SetWeaponRange(-3);
        }
    }
}
