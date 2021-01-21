using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfilePlayer
{
    public enum Classes
    {
        OFFICER,
        SCHOOLBOY
    }

    private string _playerName;
    private Sprite _spritePlayer;

    private Invetory _invetoryPlayer;
    private Equipment _equipmentPlayer;
    private Voult _voultPlayer;
    private Classes _class;

    private int _playerCoin;
    private int _playerSpeed;
    private int _playerCell;
    private bool _step;

    private List<Traps.Effect> _activeEffect = new List<Traps.Effect>();

    private Text _visebleCoin;

    private int _playingCarad;
    private int _maxPlayingCarad;

    public bool IsAlive => _playerCoin >= 0;
    public int GetCoin => _playerCoin;
    public int GetPlayerSpeed => _playerSpeed;
    public string GetPlayerName => _playerName;
    public Sprite GetSpritePlayer => _spritePlayer;
    public Invetory GetInvetory => _invetoryPlayer;
    public Equipment GetEquipment => _equipmentPlayer;
    public int GetPlayerCell => _playerCell;
    public bool IsStep => _step;
    public List<Traps.Effect> GetActiveEffect => _activeEffect;
    private bool IsPlayingMaxCard => _playingCarad >= _maxPlayingCarad;

    public ProfilePlayer(string Name, string LoadPlayerSprite)
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
        _visebleCoin = GameObject.Find("Coin").GetComponent<Text>();
        RandClass();
    }
    public void RandClass()
    {
        Array A = Enum.GetValues(typeof(Classes));
        _class = (Classes)A.GetValue(UnityEngine.Random.Range(0, A.Length));
    }

    public void EndTurn()
    {
        _step = true;
        if (_class == Classes.OFFICER)
        {
            if (_maxPlayingCarad > 1)
            {
                _maxPlayingCarad--;
            }
        }
    }
    public void PlayingCard()
    {
        _playingCarad++;
        if (IsPlayingMaxCard)
            EndTurn();
    }
    public void NewTurn()
    {
        if (!IsStopEffect())
        {
            _playingCarad = 0;
            _step = false;
            if (_class == Classes.OFFICER)
            {
                int k = UnityEngine.Random.Range(1, 6);
                if (k > 4)
                {
                    Tooltip.ShowTooltip_Static("Ваша особбенность сработала", "Выпало, " + k.ToString());
                    _maxPlayingCarad++;
                }
            }
        }
    }

    public void ApplyCoinDamage(int Damage)
    {
        if(_class == Classes.SCHOOLBOY)
        {
            if(_playerCoin == 1 && Damage <0)
            {
                int k = UnityEngine.Random.Range(1, 6);
                if (k <= 4)
                {
                    Tooltip.ShowTooltip_Static("Ваша осбенность не сработала. Выпало : " + k.ToString(), "Вы умерли)");
                    return;
                }
            }
        }
        _playerCoin += Damage;
        _visebleCoin.text = GetCoin.ToString();
    }
    public void SetPlayerCoin(int NewCoin)
    {
        _playerCoin = NewCoin;
        _visebleCoin.text = GetCoin.ToString();
    }

    public void SetPlayerCell(int NewPlayerCell)
    {
        _playerCell += NewPlayerCell;
    }
    public void ApplyPlayerSpeed(int Speed)
    {
        if (_playerSpeed + Speed < 0)
            _playerSpeed = 0;
        _playerSpeed += Speed;
    }
    private bool IsStopEffect()
    {
        foreach (var effect in _activeEffect)
        {
            if (effect == Traps.Effect.STOP)
                return true;
        }
        return false;
    }
}
