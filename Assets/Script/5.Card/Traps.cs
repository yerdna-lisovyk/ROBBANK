using UnityEngine;

public class Traps
{
    public enum EffectTrap
    {
        NO_EFFECT,
        STOP
    }


    public Traps(GameObject Cell ,Card.TypeTrap TrapCard)
    {
        switch(TrapCard)
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
        private StatusBar _statusBar;
        private ProfilePlayer _player;
        private EffectTrap _effect;
        private MassegeBox _massege;
        private void Awake()
        {
            _statusBar = GameObject.Find("StatusArea").GetComponent<StatusBar>();
            _effect = Traps.EffectTrap.STOP;
            _massege = GameObject.Find("GameMeneger").GetComponent<MassegeBox>();
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            _player = collision.GetComponent<PlayerMove>().GetProfilePlayer;
            _player.ApplyCoinDamage(-1);
            _massege.ShowMassege("Ловушка","Отдать Монету? Или Ждать 20 секунд.",Yes,No);
            Destroy(this);
        }
        private void Yes()
        {
            _player.ApplyCoinDamage(-1);
        }
        private void No()
        {
            _statusBar.NewStatus(Resources.Load<Sprite>("Simple Buttons/RPG_inventory_icons/apple"), 20, _effect, _player);
        }
    }
}
