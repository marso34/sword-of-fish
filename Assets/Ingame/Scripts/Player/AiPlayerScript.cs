using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//flesh부분은 오류가있음 크기키우는함수도 개편될수있으니 유의바람.
public class AiPlayerScript : Player
{
    bool flag;
    double timer; // 이동 뽑기에 쓰임
    float waitingTime; // 이동 뽑기에 쓰임

    GameObject Player;//사람
    public GameObject Target;// player 
    public GameObject Indicator;//노란점
    Vector3 TargetDirection;//me position - player position


    //부스터 플레그
    bool backFlag;
    GameObject[] AiPlayers_;
    bool firstMoveFlag;
    Vector3 MinFar;
    bool ViewFlag;
    public void Start()//일반적인 스타트 (코루틴) 반복문임.)
    {
        
        GM = GameObject.FindGameObjectWithTag("GM");
        Flag_get = false;
        AiPlayers_ = new GameObject[9];
        S = Skin.transform.GetComponent<SpriteRenderer>();

        skin_ = Skin.GetComponent<Skin>();// 스킨오브젝트 참조
        RotationSpeed = 720f;
        Life = true;// 라이프 온
        timer = 3;
        waitingTime = 3f;
        killScore = 0;
        MovementSpeed = 2.3f + transform.localScale.y / 2;//3.8
        BusterSpeed = 4.6f + transform.localScale.y / 2;// 부스터 속도 //10      
        Speed = MovementSpeed;// 스피드 변수를 기본스피드로 다시 초기화    


        C.a = 1f;
        C.b = 1f;
        C.r = 1f;
        C.g = 1f;
        SetRandomBody();
        SetRandomKnife();
        GameWaitInit();
        RB = MyBody.transform.GetComponent<Rigidbody2D>();

        firstMoveFlag = true;
        if (transform.tag == "Attacker") waitingTime = 0.1f;
        StartCoroutine("Start_");
        MinFar = new Vector3(13f, 5f, 1f);
        ViewFlag = false;

    }
    void SetBuster()//부스터 플레그 켜지면 부스터키기.
    {
        if (BusterFlag) chSpeed();
        else reSpeed();
    }
    private void Update()
    {
        transform.position = MyBody.transform.position;
        reset_();
        // *************************** 특이사항 ******* 죽일때마다 애니재생되는무기 넣기**********        
        //SetIndicator();
        if (transform.tag == "InkOct") FishNumber = 7;
        AiPlayers_ = GameObject.FindGameObjectsWithTag("AiPlayer");// 모든플레이어 담아야함
        Player = GameObject.FindGameObjectWithTag("Player");

        if (StartFlag == true && Player != null)
        {
            GameStartInit();
            Target = Player;
            Init_();
        }

        else if (Target != null)
        {
            if (firstMoveFlag)
            {

                firstMoveFlag = false;
            }
            if (Life)
            {
                if (transform.tag == "InkOct")
                    Init_();
                var T = (Player.transform.position - transform.position);
                if (Mathf.Abs(MinFar.magnitude) > Mathf.Abs(T.magnitude)) ViewFlag = true;
                else ViewFlag = false;
                if (ViewFlag)
                {
                    timer += Time.deltaTime;
                    if (timer > waitingTime && !backFlag)
                    {
                        dir = Move_().normalized;
                        timer = 0;
                        waitingTime = Random.Range(0f, 1.5f);
                        if (transform.tag == "Attacker") waitingTime = 0.1f;
                    }
                }
                else
                {
                    dir = PlayerTracking().normalized;
                    BusterFlag = false;
                }
                PlayerMove();//움직임 및 State초기화         
                SetBuster();
            }
            else if (!Life)
            {
                dir = Vector3.zero;
            }
            AnimState(dir);
            CheckWall();
            //CheckMaxSize();
            Check_Flag();
            //MyKnife.transform.localScale = new Vector3(0.1f, 2f, 1f);
            //MyKnife.transform.localPosition = new Vector3(0, 0.2f, 0f);
        }
        //겜 끝나면 오류뜰듯

    }
    public override void DieLife()
    {
        Speed = 0f;   // 나중에 수정 필요. 
        PlayerMove(); // RigidBody2D의 velocity가 한번만 실행해도 그 속도대로 계속 움직임
        if (transform.tag == "InkOct")
        {
            if (GameObject.FindWithTag("Kraken") != null)
                GameObject.FindWithTag("Kraken").GetComponent<Kraken>().CreateInkSwarm(transform.position, 0.4f);
            Destroy(gameObject);
        }
        else
        {
            OnOutLine(14);
            Invoke("OffOutLine", 0.07f);
            state = State.Die;
            LifeOff();

            QM = GameObject.FindGameObjectWithTag("QM");
            QM.GetComponent<QuestManager>().KnifeEC--;
            if (SkillFlag)
                OffSkillFlag(); // J
            InitState(); // J
            NotInit();
            //reSpeed();
            CreateFlesh();
            Destroy(gameObject, 2f);
        }
    }
    void StartInit()//시작시 실행
    {
        GameStartInit();
    }  //시작시 설정
    public void SetTargeting()
    {
        if (Player != null) Target = Player;
    }
    public void SetIndicator()
    {
        Vector2 direction = Target.transform.position - transform.position;

        RaycastHit2D ray = Physics2D.Raycast(transform.position, direction, 1000f, LayerMask.GetMask("CamBoxLayer"));

        if (ray.collider != null)
        {

            Indicator.transform.position = ray.point;

        }
        else Indicator.SetActive(true);
    }//노란점 플레이어에게 주기 아직구현안뎀
    public void EraserPlayer()
    {
        Destroy(gameObject);
    }//플레이어삭제 아직안쓰임
    Vector3 Move_()
    {
        float y = transform.localPosition.y;
        float x = transform.localPosition.x;

        if (x < 0)
            x *= -1f;
        if (y < 0)
            y *= -1f;

        if (x > 25f || y > 12f)
            return PlayerTracking();

        int Dice = Random.Range(0, 5);
        if (transform.tag == "AiPlayer")
        {
            if (Random.Range(0, 7) == 1) BusterFlag = true;
            else BusterFlag = false;
            if (Dice == 0) return FleshTracking();
            else if (Dice == 1) return LeftMove();
            else if (Dice == 2)
                return RightMove();
            // else return MinDirTracking();
            else if (Dice == 3)
                return FleshTracking();
            else return LeftMove();
        }
        if (transform.tag == "InkOct")
        {
            int Dice2 = Random.Range(0, 3);
            if (Dice == 0)
                return RightMove();
            // else return MinDirTracking();
            else if (Dice == 1)
                return PlayerTracking();
            else return LeftMove();
        }

        else return Vector3.zero;

    }// 이동방향값 랜덤하게 뽑는함수

    Vector3 MinDirTracking()
    {

        Vector3 min = Player.transform.position - transform.position;
        Vector3 TrDir;
        for (int i = 0; i < PlayerCount - 1; i++)
        {
            if (AiPlayers_[i] != transform.gameObject)
            {
                TrDir = AiPlayers_[i].transform.position - transform.position;
                if (min.magnitude > TrDir.magnitude) min = TrDir;
            }
        }

        BusterFlag = false;
        return min;
    }//가장가까운적 방향 반환
    Vector3 EnemyTrackingMove() //랜덤한적 따라가기 랜덤한적 방향반환
    {
        BusterFlag = false;
        int R = Random.Range(0, PlayerCount - 1);
        return AiPlayers_[R].transform.position - transform.position;
    }
    Vector3 PlayerTracking()
    {

        return Player.transform.position - transform.position;
    }// 유저 따라가기 유저방향 반환
    Vector3 LeftMove()
    {

        float DirY = Random.Range(-0.9f, 0.9f);
        Vector3 Left_ = new Vector3(-1, DirY, 0);


        return Left_;


    }// 왼쪽방향의 랜덤위아래 방향
    Vector3 RightMove()//오른쪽의 랜덤위아래 방향
    {

        float DirY = Random.Range(-0.9f, 0.9f);
        Vector3 Right_ = new Vector3(1, DirY, 0);

        return Right_;


    }
    Vector3 FleshTracking()
    {
        BusterFlag = true;
        if (GameObject.FindGameObjectWithTag("Flesh") != null)
            return GameObject.FindGameObjectWithTag("Flesh").transform.position;
        //else return EnemyTrackingMove();
        else return PlayerTracking();

    }//시체 추적
    public override void CheckWall()
    {

        RaycastHit2D ray2 = Physics2D.Raycast(transform.position, (Vector3.zero - transform.position).normalized, 1000f, LayerMask.GetMask("Wall"));
        if (ray2.collider != null)
        {
            transform.position = ray2.point;
        }

    }//맵밖으로 못나가게하는함수

}