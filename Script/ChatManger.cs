using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatManager : MonoBehaviourPun
{

    public InputField userMessage;
    public Text allMessageText;


    public void sendMessage()
    {
        string msg = userMessage.text;
        photonView.RPC("receiveMessage", RpcTarget.All, PhotonNetwork.NickName, msg, 100);
    }


    [PunRPC]
    public void receiveMessage(string name, string message, int tt)
    {
        allMessageText.text += ($"{name} -> {message}\n");
    }

}
