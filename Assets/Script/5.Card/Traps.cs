using UnityEngine;

public class Traps
{
    public enum Effect
    {
        NO_EFFECT,
        STOP
    }


    public Traps(GameObject Cell, Card.TypeTrap TrapCard)
    {
        switch (TrapCard)
        {
            case Card.TypeTrap.CHIKA:
                {
                    Cell.AddComponent<ChikaTrap>();
                    break;
                }
        }
    }


    private class ChikaTrap : MonoBehaviour
    {
        private ProfilePlayer _player;
        private Effect _effect;
        private void Awake()
        {
            _effect = Effect.STOP;
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
            StatusBar.StaticNewStatus(Resources.Load<Sprite>("Simple Buttons/RPG_inventory_icons/apple"), 20, _effect, _player);
        }
    }
}
