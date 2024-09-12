using TMPro;
using Photon.Pun;
using UnityEngine;

public class ChatManager : MonoBehaviourPun
{
    [SerializeField]
    TMP_InputField MessagesField;

    [SerializeField]
    TMP_Text allText;

    private void Awake()
    {
        allText.text = "";
    }

    public void btnSend()
    {
        var message = MessagesField.text;
        if (message != "")
        {
            photonView.RPC("ReceiveMessages", RpcTarget.All, PhotonNetwork.NickName, message);
            MessagesField.text = "";
        }
    }

    [PunRPC]
    public void ReceiveMessages(string NickName, string message)
    {
        allText.text += $"{NickName} => {message}\n";
    }
}
