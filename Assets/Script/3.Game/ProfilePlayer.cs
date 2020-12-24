
using UnityEngine;
using UnityEngine.UI;

public class ProfilePlayer 
{
    
    private string _playerName;
    private Sprite _spritePlayer;
    private int _playerCoin;
    private int _playerSpeed;
    private Invetory _invetoryPlayer;
    private int _playerCell;

    private int _playingCarad;
    private int _maxPlayingCarad;

    public bool IsAlive => _playerCoin >= 0;
    public int GetCoin => _playerCoin;
    public int GetPlayerSpeed => _playerSpeed;
    public bool IsPlayingMaxCard => _playingCarad == _maxPlayingCarad;
    public string GetPlayerName => _playerName;
    public Sprite GetSpritePlayer => _spritePlayer;
    public Invetory GetInvetory => _invetoryPlayer;
    public int GetPlayerCell => _playerCell;

    public ProfilePlayer(string Name,string LoadPlayerSprite)
    {
        _playerName = Name;
        _spritePlayer = Resources.Load<Sprite>(LoadPlayerSprite);
        _playerCoin = 20;
        _playerSpeed = 1;
        _playingCarad = 0;
        _maxPlayingCarad = 1;
        _playerCell = 1;
        _invetoryPlayer = new Invetory();
    }
    public void ApplyCoinDamage(int Damage)
    {
        _playerCoin += Damage;

    }
    public void SetPlayerCoin(int NewCoin)
    {
        _playerCoin = NewCoin;
    }

    public void SetPlayerCell(int NewPlayerCell)
    {
        _playerCell = NewPlayerCell;
    }
    public void SetPlayerSpeed(int Speed)
    {
        if (_playerSpeed + Speed < 0)
            _playerSpeed = 0;
        _playerSpeed += Speed; 
    }
}
