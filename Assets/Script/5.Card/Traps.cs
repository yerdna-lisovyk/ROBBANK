using UnityEngine;

public class Traps
{
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
        private void Awake()
        {
            _statusBar = GameObject.Find("StatusArea").GetComponent<StatusBar>();
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            collision.GetComponent<PlayerMove>().GetProfilePlayer.ApplyCoinDamage(-1);
            _statusBar.NewStatus(Resources.Load<Sprite>("Simple Buttons/RPG_inventory_icons/apple"));
            Debug.Log(collision.GetComponent<PlayerMove>().GetProfilePlayer.GetCoin);
            Destroy(gameObject.GetComponent<ChikaTrap>());
        }
    }
}
