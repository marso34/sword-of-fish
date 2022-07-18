using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordToFish : MonoBehaviour
{
    //Sword상점에서 Fish상점으로 이동하는 버튼

    public GameObject Lobby;
    public GameObject Setting;
    public GameObject FishShop;
    public GameObject SwordShop;


    public void OnClick()
    {
        //FishShop만 띄움
        Lobby.SetActive(false);
        Setting.SetActive(false);
        FishShop.SetActive(true);
        SwordShop.SetActive(false);
    }
}
