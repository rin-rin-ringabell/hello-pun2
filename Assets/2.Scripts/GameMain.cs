using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameMain : MonoBehaviourPunCallbacks
{
    enum RPS
    {
        Rock,
        Paper,
        Scissors
    }
    public Button btnRock;
    public Button btnPaper;
    public Button btnScissors;

    public TMP_Text player1Nickname;
    public TMP_Text player2Nickname;

    public TMP_Text player1Result;
    public TMP_Text player2Result;


    private void Awake()
    {
        Debug.Log($"[GameMain Awake]");
        
        player1Nickname.text = PlayerDataManager.Instance.player1.NickName;
        player2Nickname.text = PlayerDataManager.Instance.player2.NickName;
    }

    public void Game()
    {

    }
}
