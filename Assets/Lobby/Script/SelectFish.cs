using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectFish : SelectObj
{
    public GameObject FishNum;
    public GameObject LobbyFish;
    public GameObject GOFish;

    public void Start()
    {
        ObjNum = 5;     //현재 물고기 스킨 전체 갯수
    }

    public override void CallLobby(int i)
    {
        base.CallLobby(i);
        LobbyFish.GetComponent<GOFish>().GetFishNum(i);     //로비 물고기 스킨 생성
        GOFish.GetComponent<GOFish>().GetFishNum(i);        //게임오버 패널 물고기 스킨 생성
    }


}
