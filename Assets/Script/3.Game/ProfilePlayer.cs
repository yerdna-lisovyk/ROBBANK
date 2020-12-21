
using UnityEngine;
using UnityEngine.UI;

public class ProfilePlayer 
{
    
    private string _playerName;
    private Sprite _spritePlayer;
    private float _playerCoin;
    private Classes.officer _class;
    private float _playerSpeed;
    private float _playingCarad;
    private float _maxPlayingCarad;
    private Invetory _invetoryPlayer;

    public bool IsAlive => _playerCoin >= 0;
    public float GetCoin => _playerCoin;
    public Classes.officer GetClass => _class;
    public float GetPlayerSpeed => _playerSpeed;
    public float GetPlayingCard=> _playingCarad;
    public float GetMaxPlayingCard => _maxPlayingCarad;
    public string GetPlayerName => _playerName;
    public Sprite GetSpritePlayer => _spritePlayer;
    public Invetory GetInvetory => _invetoryPlayer;

    public ProfilePlayer(string Name,string LoadPlayerSprite)
    {
        _playerName = Name;
        _spritePlayer = Resources.Load<Sprite>(LoadPlayerSprite);
        _playerCoin = 20;
        _playerSpeed = 1;
        _playingCarad = 0;
        _maxPlayingCarad = 1;
        _invetoryPlayer = new Invetory();
    }
    public void ApplyCoinDamage(float Damage)
    {
        _playerCoin += Damage;

    }
    public void SetPlayerCoin(float NewCoin)
    {
        _playerCoin = NewCoin;
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
