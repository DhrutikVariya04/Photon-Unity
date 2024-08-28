using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Home : MonoBehaviour
{
    [SerializeField]
    GameObject FirstPage, RoomPage;

    [SerializeField]
    TextMeshProUGUI Username;


    public void Submit()
    {
        print($"Name ---> {Username.text}");
        FirstPage.SetActive(false);
        RoomPage.SetActive(true);
    }
}
