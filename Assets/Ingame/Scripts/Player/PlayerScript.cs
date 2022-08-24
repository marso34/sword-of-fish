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
        skin_ = Skin.GetComponent<Skin>();// 스킨오브젝트 참조
        SharkFlag = false;
        SlowFlag = false;
        BusterFlag = false;
        FRZFlag = false;
        timer = 0;
        timer_ = 0;
        waitingTime = 0.11f;
        waitingTime_ = 0.1f;

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
        RB = MyBody.transform.GetComponent<Rigidbody2D>();

        GameWaitInit();

        // var a = Instantiate(Spectrum, transform.position, Quaternion.Euler(0, 0, 0));
        // a.transform.parent = transform;
        // a.transform.localPosition = Vector3.zero;
        // a.transform.localScale = new Vector3(1f, 1f, 1f);

        StartCoroutine("Start_");
    }



    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
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
            transform.position = MyBody.transform.position;
            if (firstFlag)
            {
                firstFlag = false;
            }

            if (Life)
            {
                dir = value.joyTouch;
                if (cutGauge <= 0) BusterFlag = false;
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
                    //DefaultMoveSpeed();
                    BusterFlag = false;
                }
                GetPlayer_tp();
                Handlebar();

                if (Speed == MovementSpeed)
                    RecuveryBusterGage();

                BubbleP.gameObject.GetComponent<BubleParticle>().Speed = Speed;

            }
            else if (!Life)
            {
                transform.Find("Bubble Particle").gameObject.SetActive(false);

                cutGauge = 100;
                Destroy(GameObject.FindWithTag("BS"));
            }
            maincam_.GetComponent<Tracking_player>().BustValue(BusterFlag);
            ChangeKnife();
            ChangeBody();
            TestSkill(); // J
            TestItem(); // J

            // if (!BusterFlag && skin_.GetComponent<SpriteRenderer>().color == Color.white && !SkillFlag)
            // {
            //     DefaultMoveSpeed();
            //     DefaultRotateSpeed();
            // }
            AnimState(dir);

            CheckMaxSize();
            ShowBoard();
            mobileBuster();
            endchek();
            Check_Flag();
            //ReduceSize();

            if (HP <= 0) DieLife();


            
            // C = new Color((112f + 175f)/255f, (-219f + 227f)/255f, (-255f + 86f)/255f, 1f); // rgb(175, 227, 86) 
        }
    }

    /// <summary>
    
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>

    public void EatStar()
    {// ?뒪??? 癒뱀쓬
        //DefaultMoveSpeed();
        // InitState(); -> ?냽?룄 珥덇린?솕?룄 ?룷?븿, ?긽?뼱 ?뒪?궗 ?벝 ?븣?룄 ?썝?옒 ?냽?룄濡? ?룎?븘媛?..
        C = Color.white;
        OnStar();
        Invoke("OffStar", 3f);
    }
    public void OnStar()
    {
        MyBody.tag = "Shiled";
        Skin.GetComponent<Skin>().Flag = true;
        OnOutLine(1);
    }
    public void OffStar()
    {
        MyBody.tag = "Body";
        Skin.GetComponent<Skin>().Flag = false;
        OffOutLine();
    }
    public override void DieLife()
    {


        //源쒕묀?엫.肄붾뱶
        ShowDieAnim(0);
        state = State.Die;

        if (HP > 0)
        {
            var Sound1 = Instantiate(PlayerHitSound, transform.localPosition, Quaternion.Euler(0f, 0f, 0f));
            HP--;
            MyBody.tag = "Shiled";
            hitFlag = true;

            WhiteFlesh();
            Glitter();
            Invoke("InitBody__", 1.5f);
            MyKnife.GetComponent<HitFeel>().TimeStop(2f);

        }
        if (HP <= 0 && flagerror)
        {
            Speed = 0f;   // 나중에 수정
            PlayerMove(); // RigidBody2D의 velocity가 한번만 실행해도 그 속도대로 계속 움직임
            CreateFlesh();
            NotInit();
            Invoke("LifeOff", 0.015f);
            flagerror = false;
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
            timer += Time.deltaTime;
            if (timer > waitingTime)
            {
                cutGauge -= 2f;
                timer = 0;
            }
        }
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

    void TestItem() // 임시 테스트용 J
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
            FastSpeed(1);
            BusterFlag = true;
            if (cutGauge <= 0) BusterFlag = false;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (BusterFlag)
            {
                OffFastSpeed();
                BusterFlag = false;
            }
        }
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

    public void EatItem(int i)  // 1이면 폭탄, 2이면 얼음, 3이면 쉴드 -> 아이템 먹을 때 아이템에서 i 넘겨줌
    {
        ItemBtn.GetComponent<ItemBtn>().ChangeImage(i);
    }

    public void StopMove()  //이동튜토리얼에서 사용
    {
        value.joyTouch = Vector3.zero;
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        transform.localScale = new Vector3(1, 1, 1);
    }
}

