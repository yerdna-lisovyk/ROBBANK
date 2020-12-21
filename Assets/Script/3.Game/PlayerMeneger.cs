using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeneger : MonoBehaviour
{
    private List<ProfilePlayer> _players = new List<ProfilePlayer>();
    private void Awake()
    {
        _players.Add(new ProfilePlayer("Andrey","Avatar"));
    }
    
    public ProfilePlayer GetPlayer(int NumPlayer)
    {
        return _players[NumPlayer];
    }
}
