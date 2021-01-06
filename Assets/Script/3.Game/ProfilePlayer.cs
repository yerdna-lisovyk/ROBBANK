
using UnityEngine;
using System.Collections.Generic;

public class ProfilePlayer 
{
    
    private string _playerName;
    private Sprite _spritePlayer;

    private Invetory _invetoryPlayer;
    private Equipment _equipmentPlayer;
    private Voult _voultPlayer;

    private int _playerCoin;
    private int _playerSpeed;
    private int _playerCell;
    private bool _step;

    private List<Traps.EffectTrap> _activeEffect = new List<Traps.EffectTrap>();

    private int _playingCarad;
    private int _maxPlayingCarad;

    public bool IsAlive => _playerCoin >= 0;
    public int GetCoin => _playerCoin;
    public int GetPlayerSpeed => _playerSpeed;
    public bool IsPlayingMaxCard => _playingCarad == _maxPlayingCarad;
    public string GetPlayerName => _playerName;
    public Sprite GetSpritePlayer => _spritePlayer;
    public Invetory GetInvetory => _invetoryPlayer;
    public Equipment GetEquipment => _equipmentPlayer;
    public int GetPlayerCell => _playerCell;
    public bool IsStep => _step;
    public List<Traps.EffectTrap> GetActiveEffect => _activeEffect;


    private bool IsStopEffect()
    {
        foreach(var effect in _activeEffect)
        {
            if (effect == Traps.EffectTrap.STOP)
                return true;
        }
        return false;
    }
    public void SetStep(bool Step)
    {
        if (!IsStopEffect())
        {
            _step = Step;
        }

    }
    public ProfilePlayer(string Name,string LoadPlayerSprite)
    {
        _playerName = Name;
        _spritePlayer = Resources.Load<Sprite>(LoadPlayerSprite);
        _playerCoin = 20;
        _playerSpeed = 1;
        _playingCarad = 0;
        _maxPlayingCarad = 1;
        _playerCell = 1;
        _step = false;
        _invetoryPlayer = new Invetory();
        _equipmentPlayer = new Equipment();
        _voultPlayer = new Voult();
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
    public void ApplyPlayerSpeed(int Speed)
    {
        if (_playerSpeed + Speed < 0)
            _playerSpeed = 0;
        _playerSpeed += Speed; 
    }
}
