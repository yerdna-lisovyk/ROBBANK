
using UnityEngine;
using UnityEngine.UI;

public class ProfilePlayer : MonoBehaviour
{
    
    private float _playerCoin = 20;
    private Classes.officer _class;
    private float _playerSpeed = 1;

    [SerializeField] private Text _visibleCoin = null;
    public bool IsAlive => _playerCoin >= 0;
    public float GetCoin => _playerCoin;
    public Classes.officer GetClass => _class;
    public float GetPlayerSpeed => _playerSpeed;


    public void ApplyCoinDamage(int Damage)
    {
        _playerCoin += Damage;
        _visibleCoin.text = _playerCoin.ToString();

    }
    public void SetPlayerCoin(float NewCoin)
    {
        _playerCoin = NewCoin;
        _visibleCoin.text = _playerCoin.ToString();
    }

    public void SetPlayerSpeed(float Speed)
    {
        if (_playerSpeed + Speed < 0)
            _playerSpeed = 0;
        _playerSpeed += Speed; 
    }

    public void SetClass()
    {
        _class = new Classes.officer();
    }

}
