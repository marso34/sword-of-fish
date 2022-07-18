using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSword : SelectObj    //Sword(0~5)Btn에 들어간 스크립트
{
    public GameObject SwordNum;     //무기 번호
    public GameObject LobbySword;       //로비에 생성될 무기
    public GameObject GOSword;      //게임오버 패널에 생성될 무기

    public void Start()
    {
        ObjNum = 6;     //무기 총 갯수
    }

    public override void CallLobby(int i)   //각 무기마다 부여된 번호
    {
        base.CallLobby(i);      
        LobbySword.GetComponent<GOSword>().GetSwordNum(i);
        GOSword.GetComponent<GOSword>().GetSwordNum(i);
    }
}
