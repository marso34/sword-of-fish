using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GOFish : MonoBehaviour
{
    public GameObject[] charFish;   //물고기 프리팹 모음
    public GameObject player;   //만들어질 물고기 몸체 clone

    public int FishNum;     //SelectFish에서 받아온 선택한 물고기 번호

    public void Start()     //게임 입장시
    {
        IsLobby();
        //player = Instantiate(charFish[0]);      //기본 고등어 생성
        player.transform.SetParent(transform.parent.transform.GetChild(2));     //LobbyFish밑에 자식으로 clone생성

        //물고기 몸체 위치
        player.GetComponent<RectTransform>().anchoredPosition = new Vector3(-160, 0, 0);
        player.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f,0.5f);
        player.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.5f);
        player.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
        player.GetComponent<RectTransform>().sizeDelta = new Vector2(320, 320);
    }
    public void GetFishNum(int num)     //물고기 상점에서 물고기 착용할 때마다
    {
        Destroy(player);        //직전에 선택한 물고기 삭제
        FishNum = num;      //선택한 물고기 번호
        player = Instantiate(charFish[FishNum]);    //받아온 물고기 번호 clone 생성
        player.transform.SetParent(transform.parent.transform.GetChild(2));


        player.GetComponent<RectTransform>().anchoredPosition = new Vector3(-160, 0, 0);
        player.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
        player.GetComponent<RectTransform>().sizeDelta = new Vector2(320, 320);

    }

     public virtual void IsLobby()     //게임오버 패널에서 첫번째 캐릭터 겹쳐뜨는 것 방지
    {
        player = Instantiate(charFish[0]);
    }

}
