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

      
            transform.parent.transform.GetChild(3).transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
            transform.parent.transform.GetChild(3).transform.GetChild(0).transform.GetChild(4).gameObject.SetActive(true);
            transform.parent.transform.GetChild(3).transform.GetChild(0).transform.GetChild(5).gameObject.SetActive(true);
            transform.parent.transform.GetChild(3).transform.GetChild(1).gameObject.SetActive(true);
            transform.parent.transform.GetChild(3).transform.GetChild(2).gameObject.SetActive(true);
            transform.parent.transform.GetChild(3).transform.GetChild(3).gameObject.SetActive(true);
            transform.parent.transform.GetChild(3).transform.GetChild(4).gameObject.SetActive(true);

        

        
    }
    public void OffCanvas()
    {

            transform.parent.transform.GetChild(3).transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);//슬라이드
            transform.parent.transform.GetChild(3).transform.GetChild(0).transform.GetChild(4).gameObject.SetActive(false);//스탑
            transform.parent.transform.GetChild(3).transform.GetChild(0).transform.GetChild(5).gameObject.SetActive(false);//스탑
            transform.parent.transform.GetChild(3).transform.GetChild(1).gameObject.SetActive(false);//타임보드
            transform.parent.transform.GetChild(3).transform.GetChild(2).gameObject.SetActive(false);//킬보드
            transform.parent.transform.GetChild(3).transform.GetChild(3).gameObject.SetActive(false);//퀘스트보드
            transform.parent.transform.GetChild(3).transform.GetChild(4).gameObject.SetActive(false);   //조이스틱

    }
    public void BornGuide() //글 위에서 탄생
    {
        QM.GetComponent<QuestManager>().bornguide();
        //Guide.transform.SetParent(QM.GetComponent<QuestManager>().Player.transform);

        //Guide.transform.SetParent(GM.GetComponent<GameManager_>().Player_p.transform);
        //        Guide.transform.SetParent(GM.GetComponent<GameManager_>().Player_p.transform); 
        //Player = GameObject.Find("Player");
        
        //Guide.transform.SetParent(Player.transform);
        //QM.GetComponent<QuestManager>().HideAiSkin();
        Guide.transform.localPosition = new Vector3(-2, 4, 0);

        OffCanvas();
        if (QM.GetComponent<QuestManager>().TutorialLev == 1)
        {
            transform.parent.transform.GetChild(3).transform.GetChild(4).gameObject.SetActive(true);   //조이스틱
        }
        else if (QM.GetComponent<QuestManager>().TutorialLev == 2)
        {
            transform.parent.transform.GetChild(3).transform.GetChild(4).gameObject.SetActive(false);
        }

    }



    public void ShowMove() //글 옆으로 위치 이동
    {
        Vector3 destination = new Vector3(-2, 2, 0);

        transform.localPosition = Vector3.Lerp(transform.localPosition, destination, 0.01f);
        //QM.GetComponent<QuestManager>().HideAiSkin();

    }
    public void GoOut()
    {


        Vector3 EndDes = new Vector3(-2, 5, 0);
        Vector3 speed = Vector3.zero; 
        transform.localPosition = Vector3.Lerp(transform.localPosition, EndDes, 0.01f);
        Invoke("OnCanvas", 1f);
        
       
            
    }

    private void Update() //할아버지 생길때마다 회전초기화
    {

/*
        Player = GameObject.Find("Player");
        
        Guide.transform.SetParent(Player.transform);*/
        Vector3 direction = Guide.transform.localRotation * new Vector3(0,0,90);
        /*
        
        if (lev4up)
        {
            QM.GetComponent<QuestManager>().ShowAiSkin();
        }*/

    }
}
