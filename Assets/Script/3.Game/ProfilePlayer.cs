﻿
using UnityEngine;
using UnityEngine.UI;

public class ProfilePlayer : Classes
{
    
    private float _playerCoin = 20;
    private Classes.schoolboy _class = null;
    private float _playerSpeed = 1;

    [SerializeField] private Text _visibleCoin = null;
    public bool IsAlive => _playerCoin >= 0;
    public float GetCoin => _playerCoin;
    public Classes.schoolboy GetClass => _class;
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
        _class = TakeClasses();
    }

}