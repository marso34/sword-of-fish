using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangePanel : MonoBehaviour
{
    //로비에 있는 버튼들
    public GameObject Lobby;
    public GameObject FishShop;
    public GameObject SwordShop;
    public GameObject SwordShop_0;      //무기 페이지 0
    public GameObject SwordShop_1;      //무기 페이지 1
    public GameObject SettingPanel;
    public void ChangeSceneBtn()
    {
        switch (this.gameObject.name)
        {
            case "FishShopBtn":
                Lobby.SetActive(true);
                FishShop.SetActive(true);
                break;

            case "SwordShopBtn":
                Lobby.SetActive(true);
                SwordShop.SetActive(true);
                SwordShop_0.SetActive(true);
                SwordShop_1.SetActive(false);
                break;

            case "SettingBtn":
                Lobby.SetActive(true);
                SettingPanel.SetActive(true);
                break;
        }
    }
}
