using UnityEngine;

public class Traps 
{


    public Traps(GameObject Cell, Card card)
    {
        switch (card.GetTypeTrap)
        {
            case Card.TypeTrap.CHIKA:
                {
                    Cell.AddComponent<ChikaTrap>().SetSprite(card.GetSprite);
                    break;
                }
        }
        
    }


    public class ChikaTrap : MonoBehaviour
    {
        private ProfilePlayer _player;

        private Sprite _sprite ;
        private StatusBar.Effect _effect = StatusBar.Effect.STOP;

        public Sprite GetSprite => _sprite;
        public void SetSprite(Sprite sprite)
        {
            _sprite = sprite;
        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            _player = collision.GetComponent<PlayerMove>().GetProfilePlayer;
            MassegeBox.StaticShowMassege("Ловушка", "Отдать Монету? Или Ждать 20 секунд.", Yes, No);
            Destroy(this);
        }
        private void Yes()
        {
            _player.ApplyCoinDamage(-1);
        }
        private void No()
        {
            StatusBar.StaticNewStatus(20, _effect, _player);
        }
    }
}
