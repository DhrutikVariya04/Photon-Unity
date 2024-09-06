using TMPro;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Realtime;
using System.Collections.Generic;
using System.Linq;

public class CreateAndjoinServer : MonoBehaviourPunCallbacks
{
    [SerializeField] TMP_Text Username;
    [SerializeField] TMP_InputField InputCreate;
    [SerializeField] TMP_Text status;

    public static CreateAndjoinServer Instance;

    private void Awake()
    {
        Username.text = PhotonNetwork.NickName;
        Instance = this;
    }

    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("Loading");
                return;
            }
        }
    }

    public void CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4;
        PhotonNetwork.CreateRoom(InputCreate.text, roomOptions);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(InputCreate.text);
    }

    public void btnRoomList()
    {
        SceneManager.LoadScene("RoomList");
    }

    public override void OnJoinedRoom()
    {
        SceneManager.LoadScene("Game");
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        print("OnJoinRoomFailed" + message);
    }

    public List<RoomInfo> roomInfos = new List<RoomInfo>();

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        roomInfos = roomList;
        status.text = $"Room {roomList.Count}";
    }

    public override void OnFriendListUpdate(List<FriendInfo> friendList)
    {
        print("OnFriendListUpdate: " + friendList.Count);
    }

}
