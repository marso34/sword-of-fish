using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//랜덤 함수

// 플레이어소환 값 초기화

public class FakePanel : MonoBehaviour
{   
    // 인게임패널이랑 같이 켜지지만 인게임 패널을 덮어버린다.
    
    public GameObject[] PlayersProfil = new GameObject[8];   
    GameObject [] LodingCycles = new GameObject[8];
    
    private void Start()
    {
       
    }
    public void SetProfil(int index, GameObject Player)//프로필 요소들 참조
    {       
        
        Destroy(LodingCycles[index]);
        // 프로필 닉네임에 플레이어 이름 넣기.            
    }      

    
}

