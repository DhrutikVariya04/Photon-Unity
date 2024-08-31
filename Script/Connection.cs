using TMPro;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;

public class Connection : MonoBehaviourPunCallbacks
{
    [SerializeField]
    GameObject FirstPage, RoomHome, Roomlist, PlayingPage;

    [SerializeField]
    Image ConImage;

    [SerializeField]
    TMP_Text ConText, status;

    public override void OnConnected()
    {
        ConImage.color = Color.green;
        ConText.text = "Connected";
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);

        FirstPage.SetActive(false);
        RoomHome.SetActive(true);
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        print("Disconnected");
        status.text = "Disconnected";
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("OnConnectedToMaster :");
        PhotonNetwork.JoinLobby();
    }

    public override void OnCreatedRoom()
    {
        print("OnCreatedRoom");
        status.text = "OnCreatedRoom";
        RoomHome.SetActive(false);
        PlayingPage.SetActive(true);
        //PhotonNetwork.CreateRoom(RoomID.text);

    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        print("OnCreateRoomFailed: " + message);
    }

    public override void OnJoinedRoom()
    {
        print("OnJoinedRoom");
        status.text = "OnJoinedRoom";
        RoomHome.SetActive(false);
        PlayingPage.SetActive(true);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        print("OnJoinRoomFailed: " + message);
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        //print("OnRoomListUpdate");
        status.text = "OnRoomListUpdate: " + roomList.Count;

        // create or join to password room
        foreach (RoomInfo info in roomList)
        {
            print(info.Name);
            if (info.RemovedFromList)
            {
                // Handle room removal from the list
                Debug.Log("Room removed: " + info.Name);
            }
            else
            {
                // Handle room addition or update
                Debug.Log("Room Name: " + info.Name + ", Player Count: " + info.PlayerCount);
            }
        }
    }

    public override void OnFriendListUpdate(List<FriendInfo> friendList)
    {
        print("OnFriendListUpdate");
        status.text = "OnFriendListUpdate";
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("OnJoinedLobby");
        status.text = "OnJoinedLobby";
        TypedLobby _defaultLobby = new TypedLobby("myLobby", LobbyType.SqlLobby);

        string sqlLobbyFilter = "C0 > 50 AND C0 < 150";
        PhotonNetwork.GetCustomRoomList(_defaultLobby, sqlLobbyFilter);
    }

    public override void OnLeftLobby()
    {
        Debug.Log("OnLeftLobby ");
        status.text = "OnLeftLobby";
    }
}
