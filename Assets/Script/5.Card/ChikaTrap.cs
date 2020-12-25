using UnityEngine;

public class ChikaTrap : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<PlayerMove>().GetProfilePlayer.ApplyCoinDamage(-1);
        Debug.Log(collision.GetComponent<PlayerMove>().GetProfilePlayer.GetCoin);
        Destroy(gameObject.GetComponent<ChikaTrap>());
    }
}
