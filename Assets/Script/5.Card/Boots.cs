using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boots
{
    public Boots(GameObject icon, Card.NameEqupment TypeBoots)
    {
        switch (TypeBoots)
        {
            case Card.NameEqupment.BOOTS_OF_SPEED:
                {
                    icon.AddComponent<BootOfSpeed>();
                    break;
                }
        }
    }

    public class BootOfSpeed : MonoBehaviour
    {
        private ProfilePlayer _player;
        private void Start()
        {
            _player = GameObject.Find("GameMeneger").GetComponent<PlayerMeneger>().GetPlayer(0);
            _player.ApplyPlayerSpeed(2);
        }
        private void OnDestroy()
        {
            _player.ApplyPlayerSpeed(-2);
        }
    }
}
