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
            case Card.NameEquipment.CARDBOARD_MACHINE:
            {
                icon.AddComponent<CardboardMachine>();
                break;
            }
            case Card.NameEquipment.SVT_40:
            {
                icon.AddComponent<Svt40>();
                break;
            }
            case Card.NameEquipment.BOXING_GLOVE:
            {
                icon.AddComponent<BoxingGlove>();
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
        }
        
        private void OnDestroy()
        {
            _player.SetWeaponRange(-3);
        }
    }
    public class CardboardMachine : MonoBehaviour
    {
        private ProfilePlayer _player;
        private void Start()
        {
            _player = GameObject.Find("GameMeneger").GetComponent<PlayerMeneger>().GetPlayer(0);
            _player.SetWeaponRange(4);
        }
        
        private void OnDestroy()
        {
            _player.SetWeaponRange(1);
        }
    }
    public class Svt40 : MonoBehaviour
    {
        private ProfilePlayer _player;
        private void Start()
        {
            _player = GameObject.Find("GameMeneger").GetComponent<PlayerMeneger>().GetPlayer(0);
            _player.SetWeaponRange(7);
        }
        
        private void OnDestroy()
        {
            _player.SetWeaponRange(1);
        }
    }
    public class BoxingGlove : MonoBehaviour
    {
        private ProfilePlayer _player;
        private void Start()
        {
            _player = GameObject.Find("GameMeneger").GetComponent<PlayerMeneger>().GetPlayer(0);
            _player.SetWeaponDamage(2);
        }
        private void OnDestroy()
        {
            _player.SetWeaponDamage(-2);
        }
    }
    public class SniperRifle : MonoBehaviour
    {
        private ProfilePlayer _player;
        private void Start()
        {
            _player = GameObject.Find("GameMeneger").GetComponent<PlayerMeneger>().GetPlayer(0);
            _player.SetWeaponRange(15);
        }
        
        private void OnDestroy()
        {
            _player.SetWeaponRange(1);
        }
    }

    public class Shotgun : MonoBehaviour
    {
        private ProfilePlayer _player;
        private void Start()
        {
            _player = GameObject.Find("GameMeneger").GetComponent<PlayerMeneger>().GetPlayer(0);
            _player.SetActiveEffect(StatusBar.Effect.PROTECTION_MELEE);
            _player.SetWeaponSpan(2);
            _player.ApplyWeaponRange(-2);
        }
        
        private void OnDestroy()
        {
            _player.SetWeaponSpan(1); 
            _player.DestroyStatus(StatusBar.Effect.PROTECTION_MELEE);
        }
    }
}
