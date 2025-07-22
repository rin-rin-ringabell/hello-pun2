using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyMain : MonoBehaviourPunCallbacks
{
    public TMP_InputField roomNameInputField;
    public Button btnCreateRoom;
    public Button btnQuickJoinRoom;

    private void Awake()
    {
        Debug.Log("[LobbyMain] Awake");
    }

    public void Init()
    {
        Debug.Log("[LobbyMain] Init");
    }

    void Start()
    {
        Debug.Log("[LobbyMain] Start");
        btnCreateRoom.onClick.AddListener(() =>
        {
            if (string.IsNullOrEmpty(roomNameInputField.text))
            {
                Debug.Log("������ �Է� ���ּ���.");
            }
            else
            {
                Debug.Log($"���̸�: {roomNameInputField.text}");
                string roomName = roomNameInputField.text;
                RoomOptions options = new RoomOptions { MaxPlayers = 2 };
                PhotonNetwork.CreateRoom(roomName, options);
            }
        });
    }
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {

    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log($"LobbyMain] �� ���� ����!!!  : {returnCode}, {message}");
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("[LobbyMain] ���� ���� �Ǿ����ϴ�.");
        var asyncOperation = SceneManager.LoadSceneAsync("RoomScene");
        asyncOperation.completed += operation =>
        {
            GameObject.FindObjectOfType<RoomMain>().Init();
        };
    }
}