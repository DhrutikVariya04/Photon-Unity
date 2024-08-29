using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Home : MonoBehaviourPunCallbacks
{
    [SerializeField]
    GameObject FirstPage, RoomPage, Roomlist, PlayingPage;

    [SerializeField]
    TextField RoomID;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Submit();
        }
    }

    public void Submit()
    {
        //PhotonNetwork.NickName = Username.text;
        PhotonNetwork.ConnectUsingSettings();             
    }

    public void btnCreateRoom()
    {
        RoomPage.SetActive(false);
        PlayingPage.SetActive(true);
        PhotonNetwork.CreateRoom(" Hello ");
    }

    public void btnJoinRoom()
    {
        RoomPage.SetActive(false);
        PlayingPage.SetActive(true);
        PhotonNetwork.CreateRoom(" Hello ");
    }


    public override void OnConnected()
    {
        Debug.Log("OnConnected :");
        //Connected.color = Color.green;

    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("OnConnectedToMaster :");
        FirstPage.SetActive(false);
        RoomPage.SetActive(true);
    }

}
