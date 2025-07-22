using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class PlayerDataManager : MonoBehaviourPunCallbacks
{
    public static PlayerDataManager Instance { get; private set; }

    public Player player1;
    public Player player2;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetPlayer1(Player player1)
    {
        this.player1 = player1;
    }
    public void SetPlayer2(Player player2)
    {
        this.player2 = player2;
    }
}
