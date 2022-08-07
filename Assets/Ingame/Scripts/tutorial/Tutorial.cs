using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Tutorial : MonoBehaviour
{
    public int Touch = 0; //?꽣移? ?슏?닔 珥덇린?솕

    public GameObject tutorial;
    public GameObject GM;
    public GameObject TutorialPlan; //?꽕紐? ?굹?삤?뒗 ?뀓?뒪?듃
    public GameObject TutorialName; //留? 泥섏쓬?뿉 ?떆?옉?븯湲? ?늻瑜닿퀬 ?뒠?넗由ъ뼹 ?쑉?뒗 ?씠誘몄??
    public GameObject QM;

    public GameObject player;


    public GameObject TutoBack; //Canvas/Image 寃???? 諛곌꼍


    public GameObject QB;


    public GameObject Guide;

    public GameObject Slider;

    public GameObject QuestBoard;

    public bool One;
    public bool TouchMo = false;

    public GameObject TutorialVideo1;   //연속베기 동영상
    public GameObject TutorialVideo2;   //아이템 동영상
    public bool OnVideo1 = false;
    public bool OnVideo2 = false;
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
    public GameObject TutorialCanvas;
    public bool EndTu;
    public void Start()
    {
        if (QM.GetComponent<QuestManager>().Level_ == 0)
        {
            tutorial = transform.gameObject;

            TuClone = GameObject.Find("Tutorial(Clone)").gameObject;
            canvas = GameObject.Find("GameManager").transform.Find("Canvas").gameObject;
            TutorialCanvas = GameObject.Find("Tutorial(Clone)").transform.Find("TutorialCanvas").gameObject;
            TuClone.transform.SetParent(canvas.transform);
            player = GameObject.Find("Player(Clone)").gameObject;

            TutorialLev = 1;    

            EndTutorial = false;
            EndTu =true; 
            TuClone.transform.localPosition = new Vector3(0, 0, 0);

            QM = GameObject.FindWithTag("QM");
            GM = GameObject.FindWithTag("GM");
        }


    }



    public void Tutorial_EndCheck()
    {

        if (EndTutorial && EndTu)
        {

            tutorial.SetActive(true);
            TutoBack.SetActive(true);
            Guide.SetActive(true);
            TutorialName.SetActive(true);
            QM.GetComponent<QuestManager>().Level_++;
            GM.GetComponent<GameManager_>().SuccesFlag = true;
            /*
            if(GameObject.FindWithTag("Tutorial")!=null)
            {
                Destroy(GameObject.FindWithTag("Tutorial"));
            }
            else
            {
                Debug.Log("튜토리얼 에러");
            }


            
            if(GameObject.FindWithTag("TutoBack")!=null)
            {
                Destroy(GameObject.FindWithTag("TutoBack"));
            }
            else
            {
                Debug.Log("튜토리얼 에러");
            }

            if(GameObject.FindWithTag("Guide")!=null)
            {
                Destroy(GameObject.FindWithTag("Guide"));
            }
            else
            {
                Debug.Log("튜토리얼 에러");
            }
            if(GameObject.FindWithTag("TutorialName(Clone)")!=null)
            {
                Destroy(GameObject.FindWithTag("TutorialName(Clone)"));
            }
            else
            {
                Debug.Log("튜토리얼 에러");
            }

*/
            
            Debug.Log("썽공");

            EndTu =false;
            Destroy(TutoBack);
            Destroy(Guide);
            Destroy(TutorialName);
            Destroy(tutorial);
        }

    }
    public void bornguide()
    { //플레이어 멈추고 가이드 물고기를 플레이어 자식으로 둠

        GameObject.Find("Tutorial(Clone)").gameObject.SetActive(true);
        GameObject.Find("Tutorial(Clone)").transform.Find("TuText").gameObject.SetActive(true);

    }


    public void NextTutorial()
    {
        player.GetComponent<PlayerScript>().StopMove();

        TutorialCanvas.SetActive(true);
        TutorialPlan.SetActive(false);

        Guide = GameObject.Find("Main Camera").transform.Find("GuidePet(Clone)").gameObject;
        Guide.GetComponent<GuidePet>().BornGuide();
        TutorialCanvas.GetComponent<TutorialCanvas>().Touch = 0;

        TutoBack.SetActive(true);


        TutorialLev++;
    }

    public void Update()
    {
        if(EndTu)
        {
            TutorialCanvas = GameObject.Find("Tutorial(Clone)").transform.Find("TutorialCanvas").gameObject;
            TutorialPlan = GameObject.Find("Tutorial(Clone)").transform.Find("TutorialCanvas").transform.Find("TuText").gameObject;
            TutoBack = GameObject.Find("GameManager").transform.Find("TutoBack(Clone)").gameObject;
            player = GameObject.FindWithTag("Player");
            TutorialName = GameObject.Find("GameManager").transform.Find("Canvas").transform.Find("IntroPanel").transform.Find("TutorialName(Clone)").gameObject;
        }



        QM.GetComponent<QuestManager>().ShapeNum = 10;
        Tutorial_EndCheck();


        //TutoBack.gameObject(SortingLayer(1));
        if (TutorialLev == 1) //이동
        {
            if (A)   //시작할때 튜토리얼 여러번켜져서 한번 켜지게 임시로 해둠
            {
                Debug.Log("ㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁ");
                TutoBack.SetActive(true);

                TutorialCanvas.SetActive(true);
                Vector3 direction = player.transform.localRotation * new Vector3(0, 0, -90);
                A = false;
            }



            TutorialPlan.GetComponent<Text>().text = "이동하면서 부스터를 사용해보세요";

            if (player.GetComponent<PlayerScript>().BusterFlag
                && player.GetComponent<PlayerScript>().cutGauge < 70 && player.transform.localRotation.z != 0)
            {

                timer += Time.deltaTime;
                if (timer > waitingTime - 2) //성공하고 좀이따 성공했다고 띄움
                {

                    timer = 0;
                    player.GetComponent<PlayerScript>().BusterFlag = false;
                    TutorialPlan.GetComponent<Text>().text = "스킬을 사용해보세요";
                    NextTutorial();

                }
            }


        }


        else if (TutorialLev == 2) //부스터 튜토리얼
        {

            player.GetComponent<PlayerScript>().FishNumber = 2;
            if (player.GetComponent<PlayerScript>().skillcheck) //playerscript의 PlaySkill()함수 켜지면 여기도 켜짐
            {
                timer += Time.deltaTime;

                if (timer > waitingTime) //스킬 쓰고 3초뒤에 성공
                {


                    timer = 0;
                    TutorialPlan.GetComponent<Text>().text = "쓰레기를 치우고 나온 아이템을 먹고" + "\n" + "아이템 버튼을 눌러 사용하세요";
                    TutorialCanvas.GetComponent<TutorialCanvas>().OnVideo1 = true;
                    TutorialCanvas.GetComponent<TutorialCanvas>().StopClick = true;
                    NextTutorial();
                    QM.GetComponent<QuestManager>().ResetCounter();
                    QM.GetComponent<QuestManager>().TrashMaxCount = 10;
                    ItemBtn = GameObject.Find("Player(Clone)").transform.Find("Canvas").transform.Find("NotEndGame").transform.Find("ItemBtn").gameObject;




                }
            }
        }

        else if (TutorialLev == 3)
        {
            //여기서 인게임 레벨 바꾸기


            if (ItemBtn.GetComponent<ItemBtn>().TutorialItem) //playerscript의 PlaySkill()함수 켜지면 여기도 켜짐
            {
                timer += Time.deltaTime;

                if (timer > waitingTime) //스킬 쓰고 3초뒤에 성공
                {


                    timer = 0;
                    TutorialPlan.GetComponent<Text>().text = "공격하는 물고기를 여러번 찌르고" + "\n" + "나온 시체를 먹으세요";
                    TutorialCanvas.GetComponent<TutorialCanvas>().OnVideo2 = true;
                    TutorialCanvas.GetComponent<TutorialCanvas>().StopClick = true;
                    TutorialCanvas.GetComponent<TutorialCanvas>().BornAtt = false;
                    NextTutorial();



                }
            }
        }

        else if (TutorialLev == 4)
        {
            //Cursor.visible = false;
            body = GameObject.Find("Player(Clone)").transform.Find("body").gameObject;

            if (TutorialCanvas.GetComponent<TutorialCanvas>().TouchMo == true && TutorialCanvas.GetComponent<TutorialCanvas>().BornAtt)
            {
                QM.GetComponent<QuestManager>().BulletEnemyMaxCount = 1;
            }


            if (body.GetComponent<BodyInteraction>().TutorialFlesh)
            {
                timer += Time.deltaTime;

                if (timer > waitingTime) //스킬 쓰고 3초뒤에 성공
                {

                    timer = 0;

                    player.GetComponent<PlayerScript>().StopMove();

                    EndTutorial = true;

                }
            }
        }
        QM.GetComponent<QuestManager>().StagyStagtFlag = true;

    }













}
