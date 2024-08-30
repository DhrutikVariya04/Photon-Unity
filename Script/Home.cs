using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using System.Collections.Generic;
using Photon.Realtime;

public class Home : MonoBehaviourPunCallbacks
{
    [SerializeField]
    GameObject FirstPage, RoomHome, Roomlist, PlayingPage;

    [SerializeField]
    Image ConImage;

    [SerializeField]
    TMP_InputField Username, RoomID;

    [SerializeField]
    TMP_Text ConText, status;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Submit();
        }
    }

    public void Submit()
    {
        PhotonNetwork.NickName = Username.text;
        PhotonNetwork.ConnectUsingSettings();
        FirstPage.SetActive(true);
        RoomHome.SetActive(false);
    }

    TypedLobby _defaultLobby = new TypedLobby("myLobby", LobbyType.SqlLobby);
    private static string ROOM_CODE = "roomCode";


    public void btnCreateRoom()
    {
        /*RoomPage.SetActive(false);
        PlayingPage.SetActive(true);*/
        //PhotonNetwork.CreateRoom(RoomID.text);

        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 10;
        roomOptions.CustomRoomProperties = new ExitGames.Client.Photon.Hashtable { { ROOM_CODE, RoomID.text } };
        roomOptions.CustomRoomPropertiesForLobby = new string[] { ROOM_CODE };
        PhotonNetwork.CreateRoom(RoomID.text, roomOptions, _defaultLobby);

    }

    public void btnJoinRoom()
    {
        /* RoomPage.SetActive(false);
         PlayingPage.SetActive(true);*/
        PhotonNetwork.JoinRoom(RoomID.text);
    }

    public void RoomList()
    {
        /*PlayingPage.SetActive(true);
        RoomHome.SetActive(false);*/
        //string str = "roomCode='"+ RoomID.text + "'";
        string str = ROOM_CODE + " = '" + RoomID.text + "'";

        PhotonNetwork.GetCustomRoomList(_defaultLobby, str);
    }

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

    public override void OnConnectedToMaster()
    {
        Debug.Log("OnConnectedToMaster :");
    }

    public override void OnCreatedRoom()
    {
        print("OnCreatedRoom");
        status.text = "OnCreatedRoom";
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        print("OnCreateRoomFailed: " + message);
    }

    public override void OnJoinedRoom()
    {
        print("OnJoinedRoom");
        status.text = "OnJoinedRoom";
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        print("OnJoinRoomFailed: " + message);
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        print("OnRoomListUpdate");
        status.text = "OnRoomListUpdate: "+ roomList.Count;

        // create or join to password room
        foreach (RoomInfo info in roomList)
        {
            print(info.Name);
        }
    }

    public override void OnFriendListUpdate(List<FriendInfo> friendList)
    {
        print("OnFriendListUpdate");
        status.text = "OnFriendListUpdate";
    }
}
