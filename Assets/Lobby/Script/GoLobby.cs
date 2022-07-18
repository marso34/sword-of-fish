using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoLobby : MonoBehaviour
{
    //패널마다 있는 뒤로 가기 버튼
    public GameObject Lobby;
    public GameObject Setting;
    public GameObject FishShop;
    public GameObject KnifeShop;
    public GameObject GOPanel;

    public bool IsGO; //GO패널아닌 모든 inspector에서 체크
    public void Start()     
    {
        IsGO = true;
    }

    public void Back()
    {

        //로비만 띄움
        if (IsGO)
        {
            FishShop.SetActive(false);
            Lobby.SetActive(true);
            Setting.SetActive(false);
            FishShop.SetActive(false);
            KnifeShop.SetActive(false);
            GOPanel.SetActive(false);
        }
        else if (!IsGO)
        {
            FishShop.SetActive(false);
            Lobby.SetActive(false);
            Setting.SetActive(false);
            FishShop.SetActive(false);
            KnifeShop.SetActive(false);
            GOPanel.SetActive(true);
        }
        IsGO = true;
    }


    public void IsGoGO(bool isgo)   //게임오버 패널에서 뒤로 나가면 로비로 나가는 것 방지
    {
        if (isgo)
            IsGO = false;
    }
}