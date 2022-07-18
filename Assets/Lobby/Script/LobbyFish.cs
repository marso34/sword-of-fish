using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyFish : GOFish     //로비 물고기 스킨 생성
{
    public GameObject GM;
    public override void IsLobby()
    {
        player = Instantiate(charFish[0]);      //선택 안했으면 첫번째 물고기 스킨 생성
       

    }
    
}
