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
        Debug.Log($"[RoomyMain] �ٸ� �÷��̾ �뿡 ���� �߽��ϴ�. : {newPlayer}");
    }
    public override void OnJoinedRoom()
    {
        Debug.Log("[RoomMain] OnJoinedRoom");        
        Debug.Log($"[RoomMain] {PhotonNetwork.CurrentRoom.Name}�濡 �����߽��ϴ�.");
        Debug.Log($"{PhotonNetwork.LocalPlayer.NickName}�� �����ΰ�? : {PhotonNetwork.IsMasterClient}");
    }

    public void Init()
    {
        Debug.Log("[RoomMain Init]");
        Debug.Log($"{PhotonNetwork.LocalPlayer.NickName}�� �����ΰ�? : {PhotonNetwork.IsMasterClient}");
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
