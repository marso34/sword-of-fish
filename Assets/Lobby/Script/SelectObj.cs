using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectObj : MonoBehaviour
{
    public GameObject OffBtn;     //착용하기 버튼
    public int ObjNum;  //무기나 물고기 전체 개수
    public int PreObj; //현재 무기나 물고기 번호
    public GameObject[] ObjNumArr;   //선택중 버튼 뜨게 할 때 쓰는 함수
    public int i;

    public void OnClick()   //눌렀을 때 버튼 선택중이라고 뜨게 하기
    {
        for (i = 0; i < ObjNum; i++)
        {
            if (i == PreObj)
            {
                for (int j = 0; j < ObjNum; j++)
                    ObjNumArr[j].SetActive(false);  //선택 안된건 착용하기 버튼

                OnSelect();
                transform.GetChild(0).transform.gameObject.SetActive(true);     //선택한건 착용 중 버튼
                CallLobby(i);   //번호 확인하게 하기
            }
        }
    }

    public void OnSelect()  
    {
        OffBtn.SetActive(false);
    }

    public void NotSelect()
    {
        OffBtn.SetActive(true);
    }


    public virtual void CallLobby(int i)
    {
        Debug.Log(i);
    }
}
