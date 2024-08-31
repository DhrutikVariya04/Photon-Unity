using TMPro;
using Photon.Pun;
using UnityEngine;
using Photon.Realtime;
using System.Collections.Generic;

public class Home : MonoBehaviourPunCallbacks
{
    [SerializeField]
    TMP_InputField Username, RoomID;

    [SerializeField]
    GameObject FirstPage, RoomHome;

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
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 10;
        roomOptions.CustomRoomProperties = new ExitGames.Client.Photon.Hashtable { { "C0", 100 } };
        roomOptions.CustomRoomPropertiesForLobby = new string[] { "C0" };
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
}
