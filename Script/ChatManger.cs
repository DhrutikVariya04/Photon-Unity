using TMPro;
using Photon.Pun;
using UnityEngine;

public class ChatManager : MonoBehaviourPun
{
    [SerializeField]
    TMP_InputField MessagesField;

    [SerializeField]
    TMP_Text allText;
    public void btnSend()
    {
        var message = MessagesField.text;
        photonView.RPC("ReceiveMessages", RpcTarget.All,PhotonNetwork.NickName,message);
    }

    [PunRPC]
    public void ReceiveMessages(string NickName, string message)
    {
        allText.text += $"{NickName} ===> {message}\n";
    }
}
