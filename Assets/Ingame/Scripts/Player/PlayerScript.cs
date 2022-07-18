using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//flesh부분은 오류가있음 크기키우는함수도 개편될수있으니 유의바람.//  
public class PlayerScript : Player
{
    
    public JoystickValue value;
    public GameObject Knife;//MFish초기화할때쓰임
    public GameObject Body;//MBody초기화 할때 쓰임 
                           //LOBBYPLAYER???? ??????
    public int[] ShapeKillCount;
    //public int KnifeEnemyKillCount;
    //public int BulletEnemyKillCount;
    public int MaxBodyShape = 5;
    public Slider BusterBar;
    public GameObject Kombo;
    double timer;// 부스터 게이지 관리에서 쓰는 게임의 절대 시간 Time.deltaTime 가 들어가는 변수
    double timer1;

    float waitingTime2;
    float waitingTime;// 부스터 게이지 관리에서 쓰는 조건문 기준 시간, <- timer가 waitingTime이되면 특정 함수 실행
    double timer_;// 부스터 게이지 관리에서 쓰는 게임의 절대 시간 Time.deltaTime 가 들어가는 변수
    float waitingTime_;// 부스터 게이지 관리에서 쓰는 조건문 기준 시간, <- timer가 waitingTime이되면 특정 함수 실행

    private float maxGauge = 100f;//최대 부스터 게이지 양
    public float cutGauge = 100f;// 현재 존재하는 게이지양 

    GameObject[] AiPlayers_;

    public Text KillBoard;
    public Text TIMEBoard;

    public GameObject SkillBtn;
    public GameObject ItemBtn;
    public GameObject NotEndGame;
    public GameObject JoyStick;
    public float globalTime = 1;

    public bool StartFlag2;
    bool firstFlag;

    //연속킬 관련변수
    float CountTime;
    public int CountKill;
    float CountWaitTime;
    bool KCFlag;
    bool RaiseFlag;

    public GameObject TwoKillSound;
    public GameObject ThreeKillSound;
    public GameObject FourKillSound;

    public GameObject FiveKillSound;



    public Camera maincam_;
    public int TrushCount = 0;
    public GameObject HPCTR;
    public GameObject[] HeartArr;
    public GameObject[] BlackHeartArr;
    public int BosskillScore;
    public int BigTrashC;
    float ReduceTime = 0;
    float ReduceWTime = 0.3f;
    int MaxHP = 5;

    
    public bool killcheck = false; //y 적 죽이기 튜토리얼
    public void Start()
    {
        TuLev1 = false; //y 이동 튜토리얼 
        transform.position = Vector3.zero;
        HP = 5;
        BigTrashC = 0;
        BosskillScore = 0;
        Flag_get = false;
        Life = true;// 라이프 온
        S = Skin.transform.GetComponent<SpriteRenderer>();
        ShapeKillCount = new int[MaxBodyShape];
        for (int i = 0; i < MaxBodyShape; ++i) ShapeKillCount[i] = 0;
        StartFlag2 = false;
        killScore = 0;
        MovementSpeed = 2.3f + transform.localScale.y / 2f;//3.8
        BusterSpeed = 4.6f + transform.localScale.y / 2;// 부스터 속도 //10  
        RotationSpeed = 1500f;

        Speed = MovementSpeed;// 스피드 변수를 기본스피드로 다시 초기화             
        skin_ = Skin.GetComponent<Skin>();// 스킨오브젝트 참조

        timer = 0;
        timer_ = 0;
        waitingTime = 0.11f;
        waitingTime_ = 0.1f;

       // GameWaitInit();

        timer1 = 0;

        waitingTime2 = 0.05f;


        C.a = 1f;
        C.b = 1f;
        C.r = 1f;
        C.g = 1f;

        CountTime = 0f;
        CountKill = 0;

        CountWaitTime = 4f;
        RaiseFlag = false;
        KCFlag = false;
          GameWaitInit();
       
        StartCoroutine("Start_");
    }



    private void Update()
    {



        reset_();// 리겜하면 실행
        if (Life == false) NotInit();
        // *************************** ?????? ******* ????????? ????????¹??? ???**********
        if (StartFlag == true && !StartFlag2) // 플레이어n명이면 게임시작 
        {
            GameStartInit();
            StartFlag2 = true;
            Init_();

        }
        if (StartFlag2 == true)//찐스타트
        {

            if (firstFlag)
            {
                
                

                firstFlag = false;

            }

            dir = value.joyTouch;

            if (Life)
            {

        
                HPManager();
                if (KCFlag)
                {
                    if (RaiseFlag)
                    {
                        CountKill++;
                        RaiseFlag = false;
                        KomboKillSounds();
                    }
                    CountTime += Time.deltaTime;
                    if (CountTime > CountWaitTime)
                    {
                        CountTime = 0;
                        KCFlag = false;

                        CountKill = 0;
                    }
                }
                PlayerMove();//움직임 및 State초기화  
                
                if (cutGauge > 0 && isMove)
                    GetPlayer_BusterInput();
                else if (cutGauge <= 0 || !isMove)
                {
                    Destroy(GameObject.FindWithTag("BS"));
                    reSpeed();
                    BusterFlag = false;
                }
                GetPlayer_tp();
                Handlebar();

                if (Speed == MovementSpeed)
                    RecuveryBusterGage();




            }
            else if (!Life)
            {


                cutGauge = 100;
                Destroy(GameObject.FindWithTag("BS"));
            }
            maincam_.GetComponent<Tracking_player>().BustValue(BusterFlag);
            ChangeKnife();
            ChangeBody();
            TestSkill(); // J
            TestItem(); // J

            if (!BusterFlag && skin_.GetComponent<SpriteRenderer>().color == Color.white && !SkillFlag) TempReSpped();
            AnimState(dir);
            CheckWall();
            CheckMaxSize();
            ShowBoard();
            mobileBuster();
            endchek();
            Check_Flag();
            //ReduceSize();

            if (HP <= 0) DieLife();

        }
        
    }
    public void HPManager()
    {
        for (int i = 0; i < MaxHP; ++i)
        {
            if (i < MaxHP - HP)
            {
                HeartArr[i].SetActive(false);
                BlackHeartArr[i].SetActive(true);
            }
            else
            {
                BlackHeartArr[i].SetActive(false);
                HeartArr[i].SetActive(true);
            }
        }
    }


    public void endchek()
    {
        if (GM.GetComponent<GameManager_>().EndFlag)
        {
            NotInit();
            NotEndGame.SetActive(false);
            value.joyTouch = Vector3.zero;
            JoyStick.SetActive(false);
            StartFlag2 = false;
            MyKnife.SetActive(false);
        }
    }
    public void mobileBuster()
    {
        if (BusterFlag == true)
        {
            chSpeed();
            timer += Time.deltaTime;
            if (timer > waitingTime)
            {
                cutGauge -= 2f;
                timer = 0;
            }
        }
        else if (BusterFlag == false) reSpeed();
    }
    void ReduceSize()
    {
        ReduceTime += Time.deltaTime;
        if (ReduceTime > ReduceWTime)
        {
            if (transform.localScale.x < 0)
                transform.localScale = new Vector3(transform.localScale.x + 0.003f, transform.lossyScale.y - 0.003f, 1);
            else transform.localScale = new Vector3(transform.localScale.x - 0.003f, transform.lossyScale.y - 0.003f, 1);
            SizeDownKnife();
            ReduceTime = 0;
        }
        if (transform.localScale.y < 1) transform.localScale = (transform.localScale / transform.localScale.y);
    }
    public void SizeDownKnife()
    {
        SeparationKnife();
        if (MyKnife.transform.localScale.x < 0) MyKnife.transform.localScale = new Vector3(MyKnife.transform.localScale.x + 0.003f, MyKnife.transform.localScale.y - 0.03f, 1);
        else MyKnife.transform.localScale = new Vector3(MyKnife.transform.localScale.x - 0.003f, MyKnife.transform.localScale.y - 0.003f, 1);
        CombinationKnife();
        CheckMaxKnife();
    }//칼크기 키우기
    void ChangeKnife()//임시 테스트용
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SetRandomKnife();
        }
    }
    void ChangeBody()//임시 테스트용
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            SetRandomBody();
        }
    }

    void TestSkill()//임시 테스트용 J
    {
        if (Input.GetKeyDown(KeyCode.A))
            PlaySkill();
            // SkillBtn.GetComponent<SkillBtn>().UseSkill(); 

    }

    void TestItem()
    {
        if (Input.GetKeyDown(KeyCode.Z))
            ItemBtn.GetComponent<ItemBtn>().ChangeImage(1);
        if (Input.GetKeyDown(KeyCode.X))
            ItemBtn.GetComponent<ItemBtn>().ChangeImage(2);
        if (Input.GetKeyDown(KeyCode.C))
            ItemBtn.GetComponent<ItemBtn>().ChangeImage(3);
        if (Input.GetKeyDown(KeyCode.S))
            ItemBtn.GetComponent<ItemBtn>().UseItem();
    }

    private void GetPlayer_BusterInput()// 부스터 구현
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            var bubbleSound = Instantiate(BubbleSound, transform.position, Quaternion.Euler(0, 0, 0));
            bubbleSound.transform.parent = transform;
            chSpeed();
            BusterFlag = true;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            chSpeed();

            BusterFlag = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Destroy(GameObject.FindWithTag("BS"));
            reSpeed();
            BusterFlag = false;
        }
    }
    public void TempReSpped()
    {
        MovementSpeed = TempMovementSp + transform.localScale.y / 2; // J
        BusterSpeed = TempBusterSp + transform.localScale.y / 2; // J
        RotationSpeed = TempRotateSp + transform.localScale.y / 2; // J
    }
    public void RecuveryBusterGage()//부스터회복
    {
        timer_ += Time.deltaTime;
        if (timer_ > waitingTime_ && cutGauge < maxGauge)
        {
            if (!isMove)
                cutGauge += 1f;
            else if (isMove)
                cutGauge += 0.9f;
            timer_ = 0;
            transform.localScale = new Vector3(transform.localScale.x * 0.9992f, transform.localScale.y * 0.9992f, 1);
        }
    }

    public void Handlebar(float aa)//타스크립트에서도 사용하기 때문에 오버라이드함. 부스터 게이지 줄엿다 늘렷다 관리
    {
        cutGauge += aa;

        if (cutGauge > 100.0) cutGauge = maxGauge;

        if (cutGauge <= 0)
        {
            cutGauge = 0;
        }
        BusterBar.value = Mathf.Lerp(BusterBar.value, (float)cutGauge / (float)maxGauge, Time.deltaTime * 10);//Mathf.Lerp 검색! 부스터게이지 변동코드.
    }

    public void Handlebar() //부스터 게이지 줄엿다 늘렷다 관리
    {
        BusterBar.value = Mathf.Lerp(BusterBar.value, (float)cutGauge / (float)maxGauge, Time.deltaTime * 10);
    }

    public void ShowBoard()//킬과 시간보이기
    {
        KillBoard.text = killScore.ToString();
        TIMEBoard.text = ((int)globalTime).ToString();
    }
    public void EraserPlayer()//플레이어 지우기 아직안쓰임
    {
        Destroy(gameObject);
    }
   
   
    public override void KillScoreUp()
    {
        Debug.Log(transform.tag + "죽였따");
        Kombo.GetComponent<KomboKillImage>().Init_Img(CountKill);
        ++killScore;
        killcheck = true;
        //SizeUpKnife();
        CountTime = 0;
        KCFlag = true;
        RaiseFlag = true;
        Handlebar(10f);
    }//킬하면 실행되는함수

    public void KomboKillSounds()
    {

        var Sound1 = Instantiate(KillSound, transform.localPosition, Quaternion.Euler(0f, 0f, 0f));
        Sound1.transform.parent = transform.parent;
        Sound1.transform.localPosition = Vector3.zero;
        if (Life)
        {
            if (CountKill == 2)
            {
                var Sound2 = Instantiate(TwoKillSound, transform.localPosition, Quaternion.Euler(0f, 0f, 0f));

            }
            else if (CountKill == 3)
            {
                var Sound3 = Instantiate(ThreeKillSound, transform.localPosition, Quaternion.Euler(0f, 0f, 0f));

            }
            else if (CountKill == 4)
            {
                var Sound4 = Instantiate(FourKillSound, transform.localPosition, Quaternion.Euler(0f, 0f, 0f));

            }
            else if (CountKill == 5)

            {
                var Sound5 = Instantiate(FiveKillSound, transform.localPosition, Quaternion.Euler(0f, 0f, 0f));

            }
            else if (CountKill == 6)

            {
                var Sound5 = Instantiate(FiveKillSound, transform.localPosition, Quaternion.Euler(0f, 0f, 0f));
                CountKill = 0;
            }


        }
        if (!Life)
        {
            //var a = 1;
        }

    }//일단 이기능은 삭제

    public void EatItem(int i)
    {
        ItemBtn.GetComponent<ItemBtn>().ChangeImage(i);
    }

    public void StopMove()  //이동튜토리얼에서 사용
    {
        value.joyTouch = Vector3.zero;
        transform.rotation = Quaternion.Euler(0f, 0f,  0f);
        transform.localScale = new Vector3(1, 1, 1);
    }
}

