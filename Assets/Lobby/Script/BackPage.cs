using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackPage : MonoBehaviour   //인벤토리 두번째 페이지에서 첫번째 페이지로 가는 버튼
{
    public GameObject backPageSword;
    public GameObject backPage;
    public GameObject prePage;

    public void OnClick()
    {
        backPageSword.SetActive(true);
        prePage.SetActive(false);
        backPage.SetActive(true);
    }
}
