using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoomMain : MonoBehaviourPunCallbacks
{
    public TMP_Text player1Nickname;
    public TMP_Text player2Nickname;

    public Button btnReady;
    public Button btnStart;

    private void Awake()
    {
        Debug.Log("[RoomMain Awake]");
        
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log($"[RoomyMain] 다른 플레이어가 룸에 입장 했습니다. : {newPlayer}");
        player2Nickname.text = newPlayer.NickName;
    }
    public override void OnJoinedRoom()
    {
        Debug.Log("[RoomMain] OnJoinedRoom");        
        Debug.Log($"[RoomMain] {PhotonNetwork.CurrentRoom.Name}방에 입장했습니다.");
        Debug.Log($"{PhotonNetwork.LocalPlayer.NickName}가 방장인가? : {PhotonNetwork.IsMasterClient}");

        if (!PhotonNetwork.IsMasterClient)
        {
            player1Nickname.text = PhotonNetwork.MasterClient.NickName;
            player2Nickname.text = PhotonNetwork.LocalPlayer.NickName;
            btnStart.gameObject.SetActive(true);
            btnStart.interactable = false;
        }
    }

    public void Init()
    {
        Debug.Log("[RoomMain Init]");
        Debug.Log($"[RoomMain] {PhotonNetwork.CurrentRoom.Name}방을 만들었습니다.");
        Debug.Log($"{PhotonNetwork.LocalPlayer.NickName}가 방장인가? : {PhotonNetwork.IsMasterClient}");
        if (PhotonNetwork.IsMasterClient)
        {
            player1Nickname.text = PhotonNetwork.LocalPlayer.NickName;
            btnStart.gameObject.SetActive(false);
            btnStart.interactable = false;
            btnReady.gameObject.SetActive(false);
            btnReady.interactable = false;
        }
    }

    void Start()
    {
        Debug.Log("[RoomMain Start]");
        btnReady.onClick.AddListener(() =>
        {
            btnReady.interactable = false;
            GetComponent<PhotonView>().RPC("RPC_OnClickReadyButton", RpcTarget.MasterClient);
        });
        btnStart.onClick.AddListener(() =>
        {
            PhotonNetwork.LoadLevel("GameScene");
        });
    }

    [PunRPC]
    public void RPC_OnClickReadyButton(PhotonMessageInfo info)
    {
        Debug.Log($"[RPC_OnClickReadyButton] sender : {info.Sender.NickName}");
        btnStart.gameObject.SetActive(true);
        btnStart.interactable = true;
    }

}
