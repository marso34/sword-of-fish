using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoSetting : MonoBehaviour
{
    public GameObject SetPanel;
    public GameObject SetToLob;
    public void OnClick()      //게임오버패널에서 설정버튼 가는 것
    {

        SetPanel.SetActive(true);   //환경설정 패널 띄움
        SetToLob.GetComponent<GoLobby>().IsGoGO(true);  
        //환경설정에서 뒤로가기 버튼 눌렀을 때 게임오버 패널이 그대로 나오게함
    }
}
