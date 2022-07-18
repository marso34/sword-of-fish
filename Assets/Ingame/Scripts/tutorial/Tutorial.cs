using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Tutorial : MonoBehaviour
{
    public int Touch = 0; //?°μΉ? ?? μ΄κΈ°?

    public GameObject tutorial;
    public GameObject GM;
    public GameObject TutorialPlan; //?€λͺ? ??€? ??€?Έ
    public GameObject TutorialName; //λ§? μ²μ? ???κΈ? ?λ₯΄κ³  ?? λ¦¬μΌ ?¨? ?΄λ―Έμ??
    public GameObject QM;
    public GameObject Tuto1; //?€?¬λ¦½νΈ λΆμ΄?? λ³ΈμΈ
    public GameObject player;
    public GameObject BusterBtn;
    public GameObject SkillBtn;

    public GameObject TutoBack; //Canvas/Image κ²???? λ°°κ²½
    public GameObject GuidePet; //? ?λ²μ??
    public void Start() 
    {
        
        GuidePet.GetComponent<GuidePet>().BornGuide();

        BusterBtn = GameObject.FindWithTag("BusterBtn");
        SkillBtn = GameObject.FindWithTag("SkillBtn");



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
        

    

    public void OffCanvas()//?κ°? λ©μΆλ©? ??? κ²λ€λ§? ?¬κΈ°μ ?¬λͺνκ²? λ°κΏ
    {

        TutoBack.SetActive(true); //?? λ¦¬μΌ ??€λ©? ?€? κ²???? ?λ©?
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
        //Color color3 = QM.GetComponent<QuestManager>().SkillBtn2.GetComponent<Image>().color = a; 

        if(QM.GetComponent<QuestManager>().TutorialLev == 2)
        {
            Color color4 = QM.GetComponent<QuestManager>().BusterBtn.GetComponent<Image>().color = b; 
        }

        if(QM.GetComponent<QuestManager>().TutorialLev == 3)
        {
            Color color5 = QM.GetComponent<QuestManager>().SkillBtn.GetComponent<Image>().color = b; 
            //Color color6 = QM.GetComponent<QuestManager>().SkillBtn2.GetComponent<Image>().color = b; 
        }

    }



    public void Update()
    {
        if(Touch == 0) //? ?λ²μ?? ?΄? €?€κ³? ?€λͺλ?€? κ³?
        {

            GuidePet.SetActive(true);
            OffCanvas();
            GuidePet.GetComponent<GuidePet>().ShowMove();
            Invoke("ShowExplain", 1f); //1μ΄λ€? ?€λͺ? ??΄

        }

        if(Touch == 1)
        {

            GuidePet.GetComponent<GuidePet>().GoOut(); //?λ©? ?λ²? ?°μΉνλ©? ? ?λ²μ?? ?
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


    public void OnPlayerCanvas() 
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
        //Color color3 = QM.GetComponent<QuestManager>().SkillBtn2.GetComponent<Image>().color = b; 
        GuidePet.SetActive(false);
        

    }
}
