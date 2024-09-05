using TMPro;
using Photon.Pun;
using UnityEngine;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviourPunCallbacks
{
    [SerializeField]
    TMP_Text Username;

    private void Start()
    {
        printAllPlayer();
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        printAllPlayer();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        printAllPlayer();
    }

    public void LeftRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        SceneManager.LoadScene("Lobby");
    }

    void printAllPlayer()
    {
        Username.text = "";
        foreach (var p in PhotonNetwork.PlayerList)
        {
            Username.text += "\n" + p.NickName;
        }
    }

}
