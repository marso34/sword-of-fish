using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //로딩 후 로비 띄움

    public GameObject Lobby;
    public GameObject Setting;
    public GameObject FishShop;
    public GameObject SwordShop;
    public GameObject StartPanel;

    public GameObject retry;

    public void Start()
    {
        StartPanel.SetActive(true);
        Lobby.SetActive(false);
        Setting.SetActive(false);
        FishShop.SetActive(false);
        SwordShop.SetActive(false);

       // retry.SetActive(false);
    }
}
