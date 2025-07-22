using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;

public class RoomMain : MonoBehaviour
{
    public TMP_Text player1Nickname;
    public TMP_Text player2Nickname;

    private void Awake()
    {
        Debug.Log("[RoomMain Awake]");
        
    }

    public void Init()
    {
        Debug.Log("[RoomMain Init]");
        Debug.Log($"{PhotonNetwork.LocalPlayer.NickName}가 방장인인가 {PhotonNetwork.IsMasterClient}");
        if (PhotonNetwork.IsMasterClient)
        {
            player1Nickname.text = PhotonNetwork.LocalPlayer.NickName;
        }
    }

    void Start()
    {
        Debug.Log("[RoomMain Start]");
    }

}
