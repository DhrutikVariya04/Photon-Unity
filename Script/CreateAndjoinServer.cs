using TMPro;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Realtime;

public class CreateAndjoinServer : MonoBehaviourPunCallbacks
{
    [SerializeField] TMP_Text Username;
    [SerializeField] TMP_InputField InputCreate;
    [SerializeField] TMP_InputField InputJoin;

    private void Awake()
    {
        Username.text = PhotonNetwork.NickName;
    }

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(InputCreate.text);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(InputJoin.text);
    }

    public override void OnJoinedRoom()
    {
        SceneManager.LoadScene("Game");
        print(PhotonNetwork.CountOfPlayersInRooms);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        print("OnJoinRoomFailed" );
    }
}
