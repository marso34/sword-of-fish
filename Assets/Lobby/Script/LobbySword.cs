using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbySword : GOSword   //Lobby 무기 이미지 생성
{
    public override void IsLobby()
    {
        sword = Instantiate(charSword[0],transform.position,Quaternion.Euler(0,0,0));      //따로 선택 안했으면 시작할 때 첫번째 무기 이미지 생성
        sword.transform.parent = transform;
        sword.transform.position = Vector3.zero;
    }
}
