using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLob : MonoBehaviour
{

    public GameObject Lobby;
    public GameObject StartPanel;
    //public GameObject GMC;
    public GameObject startAd;

    public void OnClick()
    {
        Lobby.SetActive(true);
        StartPanel.SetActive(false);

        //Lobby.GetComponent<AddmobBanner>().StartAdInLob();
        //startAd.GetComponent<AddmobBanner>().StartAdInLob();


    }
}
