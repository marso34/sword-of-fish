using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCanvas : MonoBehaviour
{
        public int Touch = 0; //?Ñ∞Ïπ? ?öü?àò Ï¥àÍ∏∞?ôî

    public GameObject tutorial;
    public GameObject GM;
    public GameObject TutorialPlan; //?Ñ§Î™? ?Çò?ò§?äî ?Öç?ä§?ä∏
    public GameObject TutorialName; //Îß? Ï≤òÏùå?óê ?ãú?ûë?ïòÍ∏? ?àÑÎ•¥Í≥† ?äú?Ü†Î¶¨Ïñº ?ú®?äî ?ù¥ÎØ∏Ï??
    public GameObject QM;

    public GameObject player;


    public GameObject TutoBack; //Canvas/Image Í≤???? Î∞∞Í≤Ω
    public GameObject GuidePet; //?ï†?ïÑÎ≤ÑÏ??

    public GameObject QB;


    public GameObject Guide;

    public GameObject Slider;

    public GameObject QuestBoard;    

    public bool One;
    public bool TouchMo = false;

    public GameObject TutorialVideo1;   //ø¨º”∫£±‚ µøøµªÛ
    public GameObject TutorialVideo2;   //æ∆¿Ã≈€ µøøµªÛ
    public bool OnVideo1 =false;
    public bool OnVideo2 =false;
    float timer;
    float waitingTime;
    public bool StopClick;
    int i_wid;
    int i_hei;
    private RectTransform rectTransform;
    public bool TouchNo = false;
    public bool BornAtt = false;
    bool A = true;
    public GameObject canvas;
    public GameObject TuClone;
    public int TutorialLev;
    public bool EndTutorial;
    public GameObject ItemBtn;
    public GameObject body;
    public GameObject maincam_;
    public void Start() 
    {
                    QM = GameObject.FindWithTag("QM");
            GM = GameObject.FindWithTag("GM");
        if(QM.GetComponent<QuestManager>().Level_ == 0)
        {
            GuidePet = Instantiate(GuidePet);
            TuClone = GameObject.Find("Tutorial(Clone)").gameObject;
        canvas = GameObject.Find("GameManager").transform.Find("Canvas").gameObject;

        TuClone.transform.SetParent(canvas.transform);
        maincam_ = GameObject.FindWithTag("MainCamera");
        player = GameObject.Find("Player(Clone)").gameObject;
        GuidePet.transform.SetParent(maincam_.transform);
        GuidePet.GetComponent<GuidePet>().BornGuide();

        Touch = 0;
        timer = 0f;
        waitingTime = 6f;
        TutorialLev = 1;
        
        EndTutorial = false;

        i_wid = Screen.width;
        i_hei = Screen.height;
        rectTransform = GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(i_wid, i_hei);
        rectTransform.anchoredPosition = new Vector2(0,0);

        }

        

        Debug.Log("Ω∫≈∏§—§º");

    }
        

    



    public void OnClick()
    {
        Touch++;
        Debug.Log("≈¨∏Ø");
        //Touch1 = Touch;

    }
    public void ShowExplain()
    {
        TutorialPlan.SetActive(true);
        A = true;
        
    }
        public void OnPlayerCanvas() 
    {
        tutorial.SetActive(false);
        TutoBack.SetActive(false);
        GuidePet.SetActive(false);

    }


    public void OnPlayVideo1()
    {

        Instantiate(TutorialVideo2);
        TutorialVideo2 = GameObject.Find("TutorialVideo2(Clone)");
        Debug.Log("æ∆¿Ã≈€");
        Destroy(TutorialVideo2, 6f);
        Invoke("TouchY", 6f);

    }

    public void OnPlayVideo2()
    {

        Instantiate(TutorialVideo1);
        TutorialVideo1 = GameObject.Find("TutorialVideo1(Clone)");
        Debug.Log("æ∆¿Ã≈€");
        Destroy(TutorialVideo1, 6f);
        Invoke("TouchY", 6f);
    }
    
    public void TouchY() 
    {
        TouchNo = false;
        BornAtt = true;
        
    }

    public void Update()
    {
        tutorial = GameObject.Find("Tutorial(Clone)").transform.Find("TutorialCanvas").gameObject;
        TutorialPlan = GameObject.Find("Tutorial(Clone)").transform.Find("TutorialCanvas").transform.Find("TuText").gameObject;
        TutoBack = GameObject.Find("GameManager").transform.Find("TutoBack(Clone)").gameObject;
        player = GameObject.FindWithTag("Player");


        if(Touch == 0) 
        {
            //tutorial.SetActive(true);
            //GuidePet.SetActive(true);
            GuidePet.SetActive(true);
            OffCanvas();

            TouchMo = false;
            GuidePet.GetComponent<GuidePet>().ShowMove();
            Invoke("ShowExplain", 1f);

        }

        if(Touch != 0 && TouchNo == false)
        {

            GuidePet.GetComponent<GuidePet>().GoOut();
            TouchMo = true;

            //TutorialPlan.SetActive(false);
           
            Invoke("OnPlayerCanvas", 1f);
            
            


        }

        
        if(OnVideo1)
        {

            Debug.Log("?");
            
            Invoke("OnPlayVideo1", 1f);
            TouchNo = true;
            OnVideo1 = false;
        }
        if(OnVideo2)
        {
            Invoke("OnPlayVideo2", 1f);
            TouchNo = true;
            OnVideo2 = false;
        }
    }

        public void OffCanvas()
    {
        if(A)
        {
            tutorial.SetActive(true);
            TutoBack.SetActive(true);
            GameObject.Find("Player(Clone)").transform.Find("Canvas").gameObject.SetActive(false);
            A = false;
            Debug.Log("ƒµπˆΩ∫ off");

        }
        

        
    }


}

