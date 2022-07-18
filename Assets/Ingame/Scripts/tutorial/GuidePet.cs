using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuidePet : MonoBehaviour
{


    public GameObject Player;
    public GameObject GM;
    public GameObject Guide;
    public GameObject QM;
    public GameObject Slider1;
    public GameObject Stop;
    public GameObject TimeBoard;
    public GameObject KillBoard;
    public GameObject QB;
    public GameObject JoyStick;
    

    public bool lev4up = false; 
    
    public void OnCanvas()
    {

      /*
            transform.parent.transform.GetChild(3).transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);//슬라이더
            transform.parent.transform.GetChild(3).transform.GetChild(0).transform.GetChild(4).gameObject.SetActive(true); //스탑
            transform.parent.transform.GetChild(3).transform.GetChild(0).transform.GetChild(5).gameObject.SetActive(true); //아이템버튼
            transform.parent.transform.GetChild(3).transform.GetChild(1).gameObject.SetActive(true); //타임보드
            transform.parent.transform.GetChild(3).transform.GetChild(2).gameObject.SetActive(true); //조이스틱
            transform.parent.transform.GetChild(3).transform.GetChild(3).gameObject.SetActive(true); //퀘스트보드
            transform.parent.transform.GetChild(3).transform.GetChild(4).gameObject.SetActive(true); //킬보드
*/
        GameObject.FindWithTag("Slider").SetActive(true);
        GameObject.FindWithTag("Stop").SetActive(true);
        GameObject.FindWithTag("ItemBtn").SetActive(true);
        GameObject.FindWithTag("TimeBoard").SetActive(true);
        GameObject.FindWithTag("JoyStick").SetActive(true);
        GameObject.FindWithTag("QB").SetActive(true);
        GameObject.FindWithTag("KillBoard").SetActive(true);


        
    }
    public void OffCanvas()
    {
            /*
            transform.parent.transform.GetChild(3).transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false); //슬라이더
            transform.parent.transform.GetChild(3).transform.GetChild(0).transform.GetChild(4).gameObject.SetActive(false); //스탑
            transform.parent.transform.GetChild(3).transform.GetChild(0).transform.GetChild(5).gameObject.SetActive(false); //아이템버튼
            transform.parent.transform.GetChild(3).transform.GetChild(1).gameObject.SetActive(false); //타임보드
            transform.parent.transform.GetChild(3).transform.GetChild(2).gameObject.SetActive(false); //조이스틱
            transform.parent.transform.GetChild(3).transform.GetChild(3).gameObject.SetActive(false); //퀘스트보드
            transform.parent.transform.GetChild(3).transform.GetChild(4).gameObject.SetActive(false); //킬보드*/
        GameObject.FindWithTag("Slider").SetActive(false);
        GameObject.FindWithTag("Stop").SetActive(false);
        GameObject.FindWithTag("ItemBtn").SetActive(false);
        GameObject.FindWithTag("TimeBoard").SetActive(false);
        GameObject.FindWithTag("JoyStick").SetActive(false);
        GameObject.FindWithTag("QB").SetActive(false);
        GameObject.FindWithTag("KillBoard").SetActive(false);

    }
    public void BornGuide() 
    {
        QM.GetComponent<QuestManager>().bornguide(); //플레이어 멈추고 가이드 물고기를 플레이어 자식으로 둠
        Guide.transform.localPosition = new Vector3(-2, 4, 0); //내려오기 전에 화면 위에 있는 위치

        OffCanvas(); 
        /*
        if (QM.GetComponent<QuestManager>().TutorialLev == 1)
        {
            transform.parent.transform.GetChild(3).transform.GetChild(4).gameObject.SetActive(true); 
        }
        else if (QM.GetComponent<QuestManager>().TutorialLev == 2)
        {
            transform.parent.transform.GetChild(3).transform.GetChild(4).gameObject.SetActive(false);
        }
*/
    }



    public void ShowMove() //가이드 물고기 자막 옆으로 이동
    {
        Vector3 destination = new Vector3(-2, 2, 0);

        transform.localPosition = Vector3.Lerp(transform.localPosition, destination, 0.01f);
        //QM.GetComponent<QuestManager>().HideAiSkin();

    }
    public void GoOut() //가이드 물고기 위로 다시 이동
    {


        Vector3 EndDes = new Vector3(-2, 5, 0);
        Vector3 speed = Vector3.zero; 
        transform.localPosition = Vector3.Lerp(transform.localPosition, EndDes, 0.01f);
        Invoke("OnCanvas", 1f);
        
       
            
    }

    private void Update() //튜토리얼 단꼐별로 뜰 때마다 물고기 방향 고정
    {
        Vector3 direction = Guide.transform.localRotation * new Vector3(0,0,90);

    }
}
