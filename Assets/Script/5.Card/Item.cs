using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item 
{
    public class SapperShovel : MonoBehaviour
    {
        private ProfilePlayer _player;

        private Sprite _sprite;
        private StatusBar.Effect _effect = StatusBar.Effect.SAPPER_CLOTHING;
        
        public void SetSprite(Sprite sprite)
        {
            _sprite = sprite;
        }
        private void Start()
        {
            _player = GameObject.Find("GameMeneger").GetComponent<PlayerMeneger>().GetPlayer(0);
            _player.SetActiveEffect(_effect);
        }
        private void OnDestroy()
        {
            _player.DestroyStatus(_effect);
        }
    }
    public class Broomstick : MonoBehaviour
    {
        private ProfilePlayer _player;

        private Sprite _sprite;

        public void SetSprite(Sprite sprite)
        {
            _sprite = sprite;
        }
        private void Start()
        {
            _player = GameObject.Find("GameMeneger").GetComponent<PlayerMeneger>().GetPlayer(0);
        }
        private void OnMouseUp()
        {
            
        }
    }
}
