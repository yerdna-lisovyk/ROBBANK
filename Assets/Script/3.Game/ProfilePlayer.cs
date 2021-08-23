using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfilePlayer
{
    public enum Classes
    {
        OFFICER,
        SCHOOLBOY,
        MOM_FRIEND
    }

    private string _playerName;
    private Sprite _spritePlayer;

    private Invetory _inventorsPlayer;
    private Equipment _equipmentPlayer;
    private Storage _storagePlayer;
    private Ammo _ammoPlayer;
    private Classes _class;

    private int _playerCoin;
    private int _playerSpeed;
    private int _playerCell;
    private int _permanentArmor;
    
    private bool _step;
    
    private List<StatusBar.Effect> _activeEffect = new List<StatusBar.Effect>();
    private List<StatusBar.TriggeredEffects> _triggeredEffect = new List<StatusBar.TriggeredEffects>();

    private Text _visibleCoin;

    private int _playingCard;
    private int _maxPlayingCard;
    
    public bool IsAlive => _playerCoin > 0;
    public int GetCoin => _playerCoin;
    public int GetPlayerSpeed => _playerSpeed;
    public int GetPermanentArmor => _permanentArmor;
    public string GetPlayerName => _playerName;
    public Sprite GetSpritePlayer => _spritePlayer;
    public Classes GetClasses => _class;
    public Invetory GetInventors => _inventorsPlayer;
    public Equipment GetEquipment => _equipmentPlayer;
    public Ammo GetAmmo => _ammoPlayer;
    public int GetPlayerCell => _playerCell;
    public bool IsStep => _step;
    public List<StatusBar.Effect> GetActiveEffect => _activeEffect;
    public List<StatusBar.TriggeredEffects> GetTriggeredEffect => _triggeredEffect;
    private bool IsPlayingMaxCard => _playingCard >= _maxPlayingCard;

    public void ApplyPermanentArmor(int NewArmor)
    {
        if (_permanentArmor + NewArmor < 0)
            _permanentArmor = 0;
        _permanentArmor += NewArmor;
        
    }
    public void SetActiveEffect(StatusBar.Effect Effect)
    {
        _activeEffect.Add(Effect);
    }
    public void SetTriggeredEffects(StatusBar.TriggeredEffects Effect)
    {
        _triggeredEffect.Add(Effect);
    }
    public ProfilePlayer(string Name, string LoadPlayerSprite)
    {
        _playerName = Name;
        _spritePlayer = Resources.Load<Sprite>(LoadPlayerSprite);
        _playerCoin = 20;
        _playerSpeed = 1;
        _playingCard = 0;
        _maxPlayingCard = 1;
        _playerCell = 1;
        _permanentArmor = 0;
        _step = false;
        _inventorsPlayer = new Invetory();
        _equipmentPlayer = new Equipment();
        _ammoPlayer = new Ammo(this);
        _storagePlayer = new Storage();
        _visibleCoin = GameObject.Find("Coin").GetComponent<Text>();
        _visibleCoin.text = _playerCoin.ToString();
        RandClass();
    }
    public void RandClass()
    {
        var array = Enum.GetValues(typeof(Classes));
        _class = (Classes)array.GetValue(UnityEngine.Random.Range(0, array.Length));
        Tooltip.ShowTooltip_Static("Ваш Класс", _class.ToString());
    }

    public void EndTurn()
    {
        _step = true;
        if (_class == Classes.OFFICER)
        {
            if (_maxPlayingCard > 1)
            {
                _maxPlayingCard--;
            }
        }
    }
    public void PlayingCard()
    {
        _playingCard++;
        if (IsPlayingMaxCard)
            EndTurn();
    }
    public void NewTurn()
    {
        if (IsActiveEffect(StatusBar.Effect.BIG_BACKPACK))
        {
            StatusBar.StaticNewStatus(5,StatusBar.Effect.STOP,this);
        }
        if (IsTriggeredEffect(StatusBar.TriggeredEffects.TR_SHACKLES))
        {
            ApplyPlayerSpeed(-2);
            DestroyTriggeredEffect(StatusBar.TriggeredEffects.TR_SHACKLES);
        }
        if (IsActiveEffect(StatusBar.Effect.SHACKLES))
        {
            var k = UnityEngine.Random.Range(1, 6);
            if (k > 4)
            {
                Tooltip.ShowTooltip_Static("Кнадалы сработали. Движение +2.", "Выпало, " + k.ToString());
                ApplyPlayerSpeed(2);
                SetTriggeredEffects(StatusBar.TriggeredEffects.TR_SHACKLES);
            }
        }
        if (IsActiveEffect(StatusBar.Effect.VAGABOND))
        {
            ApplyCoinDamage(-1);
        }
        if (!IsActiveEffect(StatusBar.Effect.STOP))
        {
            _playingCard = 0;
            _step = false;
            if (_class == Classes.OFFICER)
            {
                var k = UnityEngine.Random.Range(1, 6);
                if (k > 4)
                {
                    Tooltip.ShowTooltip_Static("Ваша особбенность сработала", "Выпало, " + k.ToString());
                    _maxPlayingCard++;
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
                var k = UnityEngine.Random.Range(1, 6);
                if (k <= 4)
                {
                    Tooltip.ShowTooltip_Static("Ваша осбенность не сработала. Выпало : " + k.ToString(), "Вы умерли)");
                    return;
                }
            }
        }

        if (Damage < 0 && IsActiveEffect(StatusBar.Effect.ARMOR_OUTFIT))
        {
           var damageDone=  GetEquipment.GetBody.GetComponent<Outfit.BulletproofVest>().DamageArmor(Damage);
           _playerCoin -= damageDone;
        }
        else
        {
            _playerCoin += Damage;
        }
        _visibleCoin.text = GetCoin.ToString();
    }
    public void SetPlayerCoin(int NewCoin)
    {
        _playerCoin = NewCoin;
        _visibleCoin.text = GetCoin.ToString();
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
    public bool IsActiveEffect(StatusBar.Effect Effect)
    {
        foreach (var activeEffect in _activeEffect)
        {
            if (activeEffect == Effect)
                return true;
        }
        return false;
    }
    
    public bool IsTriggeredEffect(StatusBar.TriggeredEffects effect)
    {
        foreach (var trigger in _triggeredEffect)
        {
            if (trigger == effect)
                return true;
        }
        return false;
    }
    public void DestroyTriggeredEffect(StatusBar.TriggeredEffects effect)
    {
        for (var i = 0; i < GetTriggeredEffect.Count; i++)
        {
            if (GetTriggeredEffect[i] == effect)
            {
                GetActiveEffect.RemoveAt(i);
                return;
            }
        }
    }
    public void DestroyStatus(StatusBar.Effect Effect)
    {
        for (var i = 0; i < GetActiveEffect.Count; i++)
        {
            if (GetActiveEffect[i] == Effect)
            {
                GetActiveEffect.RemoveAt(i);
                return;
            }
        }
    }
}
