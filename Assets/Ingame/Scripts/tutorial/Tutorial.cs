using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Tutorial : MonoBehaviour
{
    public int Touch = 0; //?Ñ∞Ïπ? ?öü?àò Ï¥àÍ∏∞?ôî

    public GameObject tutorial;
    public GameObject GM;
    public GameObject TutorialPlan; //?Ñ§Î™? ?Çò?ò§?äî ?Öç?ä§?ä∏
    public GameObject TutorialName; //Îß? Ï≤òÏùå?óê ?ãú?ûë?ïòÍ∏? ?àÑÎ•¥Í≥† ?äú?Ü†Î¶¨Ïñº ?ú®?äî ?ù¥ÎØ∏Ï??
    public GameObject QM;
    public GameObject Tuto1; //?ä§?Å¨Î¶ΩÌä∏ Î∂ôÏñ¥?ûà?äî Î≥∏Ïù∏
    public GameObject player;
    public GameObject BusterBtn;
    public GameObject SkillBtn;

    public GameObject TutoBack; //Canvas/Image Í≤???? Î∞∞Í≤Ω
    public GameObject GuidePet; //?ï†?ïÑÎ≤ÑÏ??
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
        

    

    public void OffCanvas()//?ãúÍ∞? Î©àÏ∂îÎ©? ?ïà?êò?äî Í≤ÉÎì§Îß? ?ó¨Í∏∞ÏÑú ?à¨Î™ÖÌïòÍ≤? Î∞îÍøà
    {

        TutoBack.SetActive(true); //?äú?Ü†Î¶¨Ïñº ?Çò?ò§Î©? ?í§?óê Í≤???? ?ôîÎ©?
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
        if(Touch == 0) //?ï†?ïÑÎ≤ÑÏ?? ?Ç¥?†§?ò§Í≥? ?Ñ§Î™ÖÎÇò?ò§?äî Í≥?
        {

            GuidePet.SetActive(true);
            OffCanvas();
            GuidePet.GetComponent<GuidePet>().ShowMove();
            Invoke("ShowExplain", 1f); //1Ï¥àÎí§?óê ?Ñ§Î™? ?Çò?ò¥

        }

        if(Touch == 1)
        {

            GuidePet.GetComponent<GuidePet>().GoOut(); //?ôîÎ©? ?ïúÎ≤? ?Ñ∞ÏπòÌïòÎ©? ?ï†?ïÑÎ≤ÑÏ?? ?Åî
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
