using TMPro;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Realtime;
using System.Collections.Generic;

public class CreateAndjoinServer : MonoBehaviourPunCallbacks
{
    [SerializeField] TMP_Text Username;
    [SerializeField] TMP_InputField InputCreate;
    [SerializeField] TMP_InputField InputJoin;
    [SerializeField] TMP_Text status;

    public static CreateAndjoinServer Instance;

    private void Awake()
    {
        Username.text = PhotonNetwork.NickName;
        Instance = this;
    }

    private void Update()
    {
        
    }

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(InputCreate.text);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(InputJoin.text);
    }

    public void btnRoomList()
    {
        SceneManager.LoadScene("RoomList");
    }

    public override void OnJoinedRoom()
    {
        SceneManager.LoadScene("Game");
        print(PhotonNetwork.CountOfPlayersInRooms);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        print("OnJoinRoomFailed" + message);
    }

    public List<RoomInfo> roomInfos = new List<RoomInfo>();

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        roomInfos = roomList;
        print("OnRoomListUpdate");
        status.text = $"Room {roomList.Count}";

        for (int i = 0; i < roomList.Count; i++)
        {
            print(roomList[i].Name);
        }
    }
}
