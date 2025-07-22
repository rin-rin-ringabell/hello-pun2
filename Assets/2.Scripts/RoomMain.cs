using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

public class RoomMain : MonoBehaviourPunCallbacks
{
    public TMP_Text player1Nickname;
    public TMP_Text player2Nickname;

    private void Awake()
    {
        Debug.Log("[RoomMain Awake]");
        
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log($"[RoomyMain] 다른 플레이어가 룸에 입장 했습니다. : {newPlayer}");
    }
    public override void OnJoinedRoom()
    {
        Debug.Log("[RoomMain] OnJoinedRoom");        
        Debug.Log($"[RoomMain] {PhotonNetwork.CurrentRoom.Name}방에 입장했습니다.");
        Debug.Log($"{PhotonNetwork.LocalPlayer.NickName}가 방장인가? : {PhotonNetwork.IsMasterClient}");
    }

    public void Init()
    {
        Debug.Log("[RoomMain Init]");
        Debug.Log($"{PhotonNetwork.LocalPlayer.NickName}가 방장인가? : {PhotonNetwork.IsMasterClient}");
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
