using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOSword : MonoBehaviour    //게임오버 패널에서 생성되는 무기
{
    public GameObject[] charSword;  //무기 프리팹 모음
    public GameObject sword;    //만들어질 무기 clone

    public int SwordNum;    //SelectSword에서 받아온 무기 번호
    public void Start() //게임 입장시 
    {
        IsLobby();  //로비 패널에서 생성되는데 여기서 안쓸거라 함수 없애놈
        sword.transform.SetParent(transform.parent.transform.GetChild(1));      //LobbySword밑에 자식으로 clone생기게 함
        //무기 보이는 위치
        sword.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
        sword.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
        sword.GetComponent<RectTransform>().sizeDelta = new Vector2(320, 160);

    }
    public void GetSwordNum(int num)    //무기 상점에서 무기 착용할 때 마다
    {

        Destroy(sword);     //직전에 선택한 무기 clone 삭제
        SwordNum = num;     //선택한 무기 번호
        sword = Instantiate(charSword[SwordNum]);       //받아온 무기 번호의 clone 생성
        sword.transform.SetParent(transform.parent.transform.GetChild(1));

        sword.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
        sword.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
        sword.GetComponent<RectTransform>().sizeDelta = new Vector2(320, 160);

    }


    public virtual void IsLobby()
    {
        sword = Instantiate(charSword[0]);
    }
}
