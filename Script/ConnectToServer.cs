using TMPro;
using Photon.Pun;
using UnityEngine;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;
using WebSocketSharp;


public class ConnectToServer : MonoBehaviourPunCallbacks
{
    [DllImport("ToastPlugin")]
    private static extern void showToast(string message);

    [SerializeField]
    TMP_Text Username;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            BtnSubmit();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void BtnSubmit()
    {
        if (Username.text.IsNullOrEmpty())
        {
            PhotonNetwork.NickName = Username.text;
            PhotonNetwork.ConnectUsingSettings();
        }
        else
        {
            showToast("invalid username");
        }
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        print("DisConnected ...");
    }

    public override void OnJoinedLobby()
    {
        SceneManager.LoadScene("Lobby");
    }
}
