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
        private int _armor;
        private void Start()
        {
            _player = GameObject.Find("GameMeneger").GetComponent<PlayerMeneger>().GetPlayer(0);
            _armor = 6;
            _player.SetActiveEffect(StatusBar.Effect.ARMOR_OUTFIT);
        }
        private void OnDestroy()
        {
            _player.DestroyStatus(StatusBar.Effect.ARMOR_OUTFIT);
        }

        public int DamageArmor(int damage)
        {
            damage = -damage;
            if (_armor - damage < 0)
            {
                var damageArmor = damage - _armor;
                _armor -= damageArmor;
                return damage - damageArmor;
            }
            _armor -= damage;
            return 0;
        }
    }

    public class SniperCape : MonoBehaviour
    {
        private ProfilePlayer _player;
        private void Start()
        {
            _player = GameObject.Find("GameMeneger").GetComponent<PlayerMeneger>().GetPlayer(0);
            _player.SetActiveEffect(StatusBar.Effect.ONE_FOR_TWO);
        }
        
        private void OnDestroy()
        {
            _player.DestroyStatus(StatusBar.Effect.ONE_FOR_TWO);
        }
    }
}
