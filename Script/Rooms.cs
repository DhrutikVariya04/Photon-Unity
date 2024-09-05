using TMPro;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using System.Collections;
using UnityEngine.SceneManagement;

public class Rooms : MonoBehaviourPunCallbacks
{
    [SerializeField] TMP_Text status;
    [SerializeField] Button RoomPref;
    [SerializeField] GameObject Space;

    private void Start()
    {
        RefreshPage();
    }

    public void RefreshPage()
    {

        foreach (Transform child in Space.transform)
        {
            Destroy(child.gameObject);
        }

        var roomInfos = CreateAndjoinServer.Instance.roomInfos;
        status.text = $"Room {roomInfos.Count}";

        foreach (RoomInfo room in roomInfos)
        {
            var Pref = Instantiate(RoomPref, Space.transform);
            Pref.GetComponentInChildren<TMP_Text>().text = room.Name;
            Pref.onClick.AddListener(() => {

                PhotonNetwork.JoinRoom(room.Name);
            });
        }

    }

    public void Back()
    {
        SceneManager.LoadScene("Lobby");
    }

    public override void OnJoinedRoom()
    {
        SceneManager.LoadScene("Game");
    }
}
