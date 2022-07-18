using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Tutorial : MonoBehaviour
{
    public int Touch = 0; //터치 횟수 초기화

    public GameObject tutorial;
    public GameObject GM;
    public GameObject TutorialPlan; //설명 나오는 텍스트
    public GameObject TutorialName; //맨 처음에 시작하기 누르고 튜토리얼 뜨는 이미지
    public GameObject QM;
    public GameObject Tuto1; //스크립트 붙어있는 본인
    public GameObject player;
    /*
    public GameObject Slider; //슬라이더 이미지1
    public GameObject Slider1; //슬라이더 이미지2
    public GameObject BusterBtn;
    public GameObject SkillBtn;
    public GameObject Stop;
    public GameObject JoyStick;
    public GameObject KillBoard;
    public GameObject TimeBoard; 
    public GameObject SkillBtn2; //스킬 버튼 안에 채워지는 이미지*/
    public GameObject TutoBack; //Canvas/Image 검은 배경
    public GameObject GuidePet; //할아버지
    public void Start() 
    {
        
        GuidePet.GetComponent<GuidePet>().BornGuide();

        
        /*
        JoyStick = GM.GetComponent<GameManager_>().Player_p.transform.GetChild(3).gameObject.transform.GetChild(4).gameObject;
        KillBoard = GM.GetComponent<GameManager_>().Player_p.transform.GetChild(3).gameObject.transform.GetChild(2).gameObject;
        TimeBoard = GM.GetComponent<GameManager_>().Player_p.transform.GetChild(3).gameObject.transform.GetChild(1).gameObject;
        

        BusterBtn = GM.GetComponent<GameManager_>().Player_p.transform.GetChild(3).gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
        SkillBtn = GM.GetComponent<GameManager_>().Player_p.transform.GetChild(3).gameObject.transform.GetChild(0).gameObject.transform.GetChild(3).gameObject;
        SkillBtn2 = GM.GetComponent<GameManager_>().Player_p.transform.GetChild(3).gameObject.transform.GetChild(0).gameObject.transform.GetChild(3).gameObject.transform.GetChild(0).gameObject;
        Stop = GM.GetComponent<GameManager_>().Player_p.transform.GetChild(3).gameObject.transform.GetChild(0).gameObject.transform.GetChild(4).gameObject;
*/
        Touch = 0;
    
    }
        

    

    public void OffCanvas()//시간 멈추면 안되는 것들만 여기서 투명하게 바꿈
    {

        TutoBack.SetActive(true); //튜토리얼 나오면 뒤에 검은 화면
        Color a;
        a.a = 0;
        a.b = 1;
        a.g = 1;
        a.r = 1;

        Color b;
        b.a = 1;
        b.b = 1;
        b.g = 1;
        b.r = 1;


        Color color1 = QM.GetComponent<QuestManager>().BusterBtn.GetComponent<Image>().color = a; 
        Color color2 = QM.GetComponent<QuestManager>().SkillBtn.GetComponent<Image>().color = a; 
        Color color3 = QM.GetComponent<QuestManager>().SkillBtn2.GetComponent<Image>().color = a; 

        if(QM.GetComponent<QuestManager>().TutorialLev == 2)
        {
            Color color4 = QM.GetComponent<QuestManager>().BusterBtn.GetComponent<Image>().color = b; 
        }

        if(QM.GetComponent<QuestManager>().TutorialLev == 3)
        {
            Color color5 = QM.GetComponent<QuestManager>().SkillBtn.GetComponent<Image>().color = b; 
            Color color6 = QM.GetComponent<QuestManager>().SkillBtn2.GetComponent<Image>().color = b; 
        }

    }



    public void Update()
    {
        if(Touch == 0) //할아버지 내려오고 설명나오는 곳
        {

            GuidePet.SetActive(true);
            OffCanvas();
            GuidePet.GetComponent<GuidePet>().ShowMove();
            Invoke("ShowExplain", 1f); //1초뒤에 설명 나옴

        }

        if(Touch == 1)
        {

            GuidePet.GetComponent<GuidePet>().GoOut(); //화면 한번 터치하면 할아버지 끔
            Invoke("OffTu", 1f);
        }



 
    }
    public void OffTu()
    {
        OnPlayerCanvas();
    }
    public void OnClick()
    {
        Touch++;
        //Touch1 = Touch;

    }


    public void ShowExplain()
    {
        TutorialPlan.SetActive(true);
        
    }


    public void OnPlayerCanvas() //투명화했던거 튜토리얼 끄면 다시 불투명하게 바꿈
    {
        tutorial.SetActive(false);
        //Tuto1.SetActive(false);
        TutoBack.SetActive(false);
        Color a;
        a.a = 0;
        a.b = 1;
        a.g = 1;
        a.r = 1;

        Color b;
        b.a = 1;
        b.b = 1;
        b.g = 1;
        b.r = 1;

        Color color1 = QM.GetComponent<QuestManager>().BusterBtn.GetComponent<Image>().color = b; 
        Color color2 = QM.GetComponent<QuestManager>().SkillBtn.GetComponent<Image>().color = b; 
        Color color3 = QM.GetComponent<QuestManager>().SkillBtn2.GetComponent<Image>().color = b; 
        GuidePet.SetActive(false);
        

    }
}
