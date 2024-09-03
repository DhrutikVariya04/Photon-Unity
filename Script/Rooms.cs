using TMPro;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;

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
        var roomInfos = CreateAndjoinServer.Instance.roomInfos;

        status.text = $"Room {roomInfos.Count}";

        for (int i = roomInfos.Count; i > 0; i--)
        {
            var Pref = Instantiate(RoomPref, Space.transform);
        }
    }

}
