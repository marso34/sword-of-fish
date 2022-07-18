using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextPage : MonoBehaviour   //인벤토리에서 다음 페이지 넘어가는 버튼
{

    public GameObject prePageSword;     //현재 페이지
    public GameObject nextPage;     //다음 페이지

    public void OnClick()       
    {
        prePageSword.SetActive(false);      //현재 페이지 숨김
        nextPage.SetActive(true);       //다음 페이지 숨김

    }

}
