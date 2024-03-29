using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor;
public class QuestManager : MonoBehaviour
{

    public GameObject[] Stayges;//스테이지 객체 배열
    public int Score;

    public int Level_;// 레벌
    public GameObject Levelboard;// 로비의 레벨 보드
    public GameObject Player;
    public GameObject Stayge; // 현재 실행되는 스테이지
    public GameObject GM;// 게임매니져 
    public GameObject IntroPanelName;
    public GameObject[] IntroPanelPlan = new GameObject[3];// 어떤 퀘스트인지 알림 최대 3줄
    public GameObject QuestBoard_;// 퀘스트 보드
                                  //-----------------
    public GameObject KnifeEnemy;
    public GameObject BulletEnemy;
    public GameObject BossEnemy2;// 1라운드 보스 타코야
    public GameObject BossEnemyCrab; // 2라운드 보스 크랩
    public GameObject VictimObj;
    public GameObject WaveObj;
    public GameObject BigTrashObj; // 크라켄 쓰레기
    public GameObject BigTrashObj2; // 킹크랩 쓰레기
    public GameObject TrashObj;
    public GameObject TrashObj2;

    public GameObject BubblesShiledObj;
    public int IngameLevel;
    //--------------------
    public bool LoseFlag;// 죽었거나 시간초 다됐을때
    public bool ObjMFlag;
    public int ShapeNum;  // 스테이지 종류 번호 0 = 시간초, 1 = ShapeA, 2 = ShapeB, 3 = ShapeC
    public int limitTime;// 제한시간
    public int MaxCount;//클리어조건을 담당하는 카운트 현재 갯수는 Player?가 가지고있게 하자 시체갯수, 킬갯수, 점령갯수, 
    //-----------------------------------------맵에 생성될 각 오브젝트의 총갯수를 설정함.
    public int KnifeEnemyMaxCount = 0;
    public int BulletEnemyMaxCount = 0;
    public int WaveMaxCount = 0;

    public int BigTrashMaxCount = 0;

    public int TrashMaxCount = 0;
    public int Trash2MaxCount = 0;
    public int VictimMaxCount = 0;

    public int BossMaxCount = 0;

    //-------------------- 현재 맵에 각 오브젝트가 몇개있나 카운트함
    public int KnifeEC = 0;
    public int BulletEC = 0;
    public int BossEC = 0;
    public int WaveOC = 0;
    public int BigTrashOC = 0;
    public int TrashOC = 0;
    public int Trash2OC = 0;
    public int VictimOC = 0;
    public int BubblesShiledOC = 0;
    //-----------------------------
    public int CurrentCount;// ShapeA일때 사용 현재 내가 모은 갯수
    public int[] Rank;// ShapeB일 떄 사용 현재 랭크 상위 4명만 표시`
    public int OccupationTime;//ShapeC일 때 사용 점령전 얼마나 찾는지.
    public bool Flag = true;// update에서 한번만 실행할 구문 경계 구분 
    public Image me;//안쓰는 변수
    //아이콘들은 인트로 패널에서 쓰임. 각 이미지.
    //----------------------------------------------------
    public Sprite TimeIcon;
    public GameObject SpearImg;
    public Sprite FleshIcon;
    public Sprite[] BossIcon;
    public Sprite bubbleIcon;
    public Sprite TrushIcon;
    public Sprite killIcon;
    public Sprite FishIcon;
    public Sprite RankIcon;
    public Sprite FlagIcon;
    public Sprite BockBossIcon;
    public Sprite TakoBossIcon;
    public GameObject CanTrash;
    public GameObject PaperTrash;
    //------------------------------------------------------ y ????? ????
    public GameObject IntroPanel;

    public GameObject StageTag;
    public GameObject StaygeLevel;
    public Sprite UIM_Stage;
    public GameObject TutorialName;
    //public GameObject TutorialPlan;
    public bool StagyStagtFlag;

    public int TutorialLev;
    //public int TempTuLev;
    //public bool TuLev1 = false;
    //public bool EndTutorial; // 튜토리얼 끝났는지확인
    //public bool TutorialCheck;

    public bool CheckFlesh;
    public bool CheckTrash;
    public Transform Canvas;
    //public GameObject tutorial;
    public int ResetTouch;


    public float timer;
    public int waitingTime;
    public int TempFlesh;
    //public GameObject TutoBack;

    public bool A = true;
    public GameObject BokBoss;

    bool B = false;
    public GameObject Vectorv;

    public Transform IntroPenelT;
    public Transform PlayerT;

    public GameObject[] Stagys0;
    public GameObject[] Stagys1;
    public GameObject[] Stagys2;

    float Xc;
    float Yc;
    void Start()
    {
        Score = 0;

        GameLoad();//초기 렙설정
        

        if (Level_ == 0)
            IngameLevel = 0;
        else 
            IngameLevel = 1; //n스테이지진입후 n-n 스테이지레벨    

        LoseFlag = false;
        OccupationTime = 0;
        //TutorialLev = 0;
        waitingTime = 2;
        //TempTuLev = 0;
        Stayge = null;
        StagyStagtFlag = false;
        Flag = true;
        ObjMFlag = true;
        GM.GetComponent<GameManager_>().SuccesFlag = false;
        Levelboard.GetComponent<Text>().text = Level_.ToString();
    }
    void Update()
    {
        Test_Method();
        Levelboard.GetComponent<Text>().text = Level_.ToString();
        if (GM.GetComponent<GameManager_>().enterGame && GM.GetComponent<GameManager_>().EndFlag == false)
        {
            Player = GameObject.FindGameObjectWithTag("Player");

            if (Player != null)
            {
                FlagOnMethod();
                if (StagyStagtFlag)
                {
                    // Debug.Log("? ??" + KnifeEC + "???" + BulletEC);
                    QuestBoard_ = GameObject.FindGameObjectWithTag("QB");
                    if (Level_ < 1)
                    {
                        QuestBoard_.GetComponent<QB>().ShapeA.SetActive(false);
                    }
                    //if(Level_< 1) QuestBoard_
                    ShapeInit();
                    SucssesFlagOnOff();
                    EndGameCheck();
                    Objectmanager();
                    if (IngameLevel > 6) IngameLevel = 6;
                    if (IngameLevel < 0) IngameLevel = 0;
                }
            }
        }
       
    }
    public void FlagOnMethod()
    {//?? ???????? ??????? ????? ????
        if (Flag)
        {
            GM.GetComponent<GameManager_>().SuccesFlag = false;
            //GameObject.FindGameObjectWithTag("ShowText").gameObject.GetComponent<ShowInLevel>().showText("Level" + " " + IngameLevel.ToString());
            if (GameObject.FindGameObjectWithTag("Stage") != null)
            {
                Debug.Log(GameObject.FindGameObjectWithTag("Stage").GetComponent<Stage>().GoalCount + "yyyyy" + GameObject.FindGameObjectWithTag("Stage"));
                Destroy(GameObject.FindGameObjectWithTag("Stage"));
            }
            if (Level_ == 0)
            {
                Level_0_Action();
            }
            if (Level_ % 2 == 1)
            {
                Level_1_Action();
            }
            if (Level_ != 0 && Level_ % 2 == 0)
            {
                Level_2_Action();
            }
            //Debug.Log(IngameLevel + "????" + MaxCount + " " + KnifeEC);
            //if (Level_ == 8) Players[Random.Range(1, 7)].GetComponent<Player>().Flag_get = true;
            // Stayge = Instantiate(Stayges[Level_ - 1], Vector3.zero, Quaternion.Euler(0, 0, 0));

            if (QuestBoard_ != null)
                Debug.Log(QuestBoard_.tag);

            Flag = false;

        }
    }

    public void Test_Method()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            IngameLevel++;
            Flag = true;
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            IngameLevel--;
            Flag = true;
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            Level_++;
            Flag = true;
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            Level_--;
            Flag = true;
        }

        if (Input.GetKeyDown(KeyCode.G)) Player.transform.localScale = new Vector3(Player.transform.localScale.x + 1f, Player.transform.localScale.y + 1f, 1f);
        if (Input.GetKeyDown(KeyCode.R)) Player.GetComponent<Player>().HP++;

        //if (Input.GetKeyDown(KeyCode.P)) Level_++;
        if (Input.GetKeyDown(KeyCode.O)) Level_--;
    }
    public void SucssesFlagOnOff()// 게임 실패 검사
    {
        if (ShapeNum == 5) TimeOut_EndCheck();
        else if (ShapeNum == 1) ShapeA_EndCheck();
        //else if (ShapeNum == 2) ShapeB_EndCheck();
        //else if (ShapeNum == 10) tutorial.GetComponent<Tutorial>().Tutorial_EndCheck();
    }// 게임 끝나는거 체
    public void Level_0_Action()
    {
        if (IngameLevel < 5)
        {
            CurrentCount = 0;

            Stayge = Instantiate(Stagys0[IngameLevel - 1], Vector3.zero, Quaternion.Euler(0, 0, 0));
        }
    }
    public void Level_1_Action() // 소 스테이지 레벨마다 퀘스트 초기화 
    {
        if (IngameLevel < 5)
        {
            CurrentCount = 0;

            Stayge = Instantiate(Stagys1[IngameLevel], Vector3.zero, Quaternion.Euler(0, 0, 0));
        }
    }
    public void Level_2_Action()
    {
        if (IngameLevel < 6)
        {
            CurrentCount = 0;
            TrashMaxCount = 5;
            Trash2MaxCount = 5;
            Stayge = Instantiate(Stagys2[IngameLevel - 1], Vector3.zero, Quaternion.Euler(0, 0, 0));
        }
    }
    public void CurrentCountInit()//퀘스트 완료조건 정의
    {
        CurrentCount = Stayge.GetComponent<Stage>().GoalCount;
        // Debug.Log(CurrentCount + "카운트");
    }//ShapeA에서 사용
    public void ResetPlayerStat()//각 소 스테이지 마다 초기화 돼야 할 플레이어변수 초기화
    {
        //Player.GetComponent<PlayerScript>().killScore = 0;
        Player.GetComponent<PlayerScript>().BosskillScore = 0;
        Player.GetComponent<PlayerScript>().BigTrashC = 0;
    }
    public void ObjectCleanerNextStage()//다음 소 스테이지로 갈 때 필수적으로 지워야할것들만 지움
    {
        GameObject[] Items = GameObject.FindGameObjectsWithTag("Item");
        GameObject[] Attackers = GameObject.FindGameObjectsWithTag("Attacker");
        GameObject[] AiPlayers = GameObject.FindGameObjectsWithTag("AiPlayer");
        GameObject Kraken = GameObject.FindGameObjectWithTag("Kraken");
        GameObject KingCrab = GameObject.FindGameObjectWithTag("KingCrab");
        GameObject[] BigTrash = GameObject.FindGameObjectsWithTag("BigTrash");

        for (int i = 0; i < Attackers.Length; ++i)
        {
            Destroy(Attackers[i], 0f);
        }
        for (int i = 0; i < AiPlayers.Length; ++i)
        {
            Destroy(AiPlayers[i], 0f);
        }
    }
    public void Init_Stayge()// 대 스테이지 초기화 게임시작 누를시 한번만 실행
    {
        limitTime = 0;
        if (Level_ == 0)
        {
            GameObject.Find("IntroPanel").transform.Find("plan").gameObject.SetActive(true);
            GameObject.Find("IntroPanel").transform.Find("Stage1").gameObject.SetActive(true);
            GameObject.Find("IntroPanel").transform.Find("plan1").gameObject.SetActive(true);
            GameObject.Find("IntroPanel").transform.Find("Stagy Level").gameObject.SetActive(true);

            Color a;
            a.a = 1;
            a.b = 1;
            a.g = 1;
            a.r = 1;

            GameObject uim_Stage = GameObject.Find("GameManager/Canvas/IntroPanel");
            Color color = uim_Stage.GetComponent<Image>().color = a;
            IntroPanel.GetComponent<Image>().sprite = UIM_Stage;


            limitTime = 1;
            ShapeNum = 1;
            IntroPanelName.GetComponent<Text>().fontSize = 150;
            IntroPanelName.GetComponent<Text>().text = "튜토리얼";
            IntroPanelPlan[1].SetActive(true);
            //IntroPanelPlan[1].GetComponent<Image>().sprite = BossIcon[Level_ - 1];
            IntroPanelPlan[1].transform.GetChild(0).GetComponent<Text>().text = "";
        }
        if (Level_ % 2 == 1)
        {
            IntroPanelName.GetComponent<Text>().fontSize = 200;
            GameObject.Find("IntroPanel").transform.Find("plan").gameObject.SetActive(true);
            GameObject.Find("IntroPanel").transform.Find("Stage1").gameObject.SetActive(true);
            GameObject.Find("IntroPanel").transform.Find("plan1").gameObject.SetActive(true);
            GameObject.Find("IntroPanel").transform.Find("Stagy Level").gameObject.SetActive(true);

            Color a;
            a.a = 1;
            a.b = 1;
            a.g = 1;
            a.r = 1;

            GameObject uim_Stage = GameObject.Find("GameManager/Canvas/IntroPanel");
            Color color = uim_Stage.GetComponent<Image>().color = a;
            IntroPanel.GetComponent<Image>().sprite = UIM_Stage;


            limitTime = 1;
            ShapeNum = 1;
            IntroPanelName.GetComponent<Text>().text = Level_.ToString();
            IntroPanelPlan[1].SetActive(true);
            // IntroPanelPlan[1].GetComponent<Image>().sprite = BossIcon[Level_ - 1];
            IntroPanelPlan[1].transform.GetChild(0).GetComponent<Text>().text = "적들을 처치하세요";
        }
        else if (Level_ != 0 && Level_ % 2 == 0)
        {

            GameObject.Find("IntroPanel").transform.Find("plan").gameObject.SetActive(true);
            GameObject.Find("IntroPanel").transform.Find("Stage1").gameObject.SetActive(true);
            GameObject.Find("IntroPanel").transform.Find("plan1").gameObject.SetActive(true);
            GameObject.Find("IntroPanel").transform.Find("Stagy Level").gameObject.SetActive(true);

            Color a;
            a.a = 1;
            a.b = 1;
            a.g = 1;
            a.r = 1;

            GameObject uim_Stage = GameObject.Find("GameManager/Canvas/IntroPanel");
            Color color = uim_Stage.GetComponent<Image>().color = a;
            IntroPanel.GetComponent<Image>().sprite = UIM_Stage;


            limitTime = 1;
            ShapeNum = 1;
            IntroPanelName.GetComponent<Text>().text = Level_.ToString();
            IntroPanelPlan[1].SetActive(true);
            IntroPanelPlan[1].GetComponent<Image>().sprite = FishIcon;
            IntroPanelPlan[1].transform.GetChild(0).GetComponent<Text>().text = "킹크렙의 산맥";
        }


        CurrentCount = 0;
        OccupationTime = 0;
        GM.GetComponent<GameManager_>().GlobalTime = limitTime;
    }//스테이지 정의
    public void TimeOut_EndCheck()// 시간다됐나 체크 지금은 사용안함
    {
        if (GM.GetComponent<GameManager_>().GlobalTime <= 0)
        {

            Level_++;
            Flag = true;

        }
    }//timeout으로 끝나는판
    public void Objectmanager()// 소 스테이지 초기화에서 정해준 오브젝트 최대 갯수만큼 각 오브젝트 계속 생성, 
    {
        if (ObjMFlag)
        {
            // Debug.Log("이거 실행된다...");
            if (KnifeEnemyMaxCount > KnifeEC)
            {
                Invoke("CreateKnifeE", 4.5f);
                KnifeEC++;
            }// 칼 적 생성
            if (BulletEnemyMaxCount > BulletEC)
            {
                Invoke("CreateBulletE", 4.5f);// 총알 적 생성
                BulletEC++;
            }
            if (WaveMaxCount > WaveOC) Invoke("CreateWaveO", 2.5f);// 물결오브제 생성
            if (BigTrashMaxCount > BigTrashOC)
            {
                CreateBigTrashO();//큰쓰레기 생성 캠액션 할것.
                BigTrashOC++;
            }
            if (TrashMaxCount > TrashOC)
            {

                CreateTrashO();//캔 쓰레기 생성
                TrashOC++;
            }
            if (Trash2MaxCount > Trash2OC)
            {
                CreateTrash2O();
                Trash2OC++;
            }
            if (BossMaxCount > BossEC)
            {
                CreateBossE();
                BossEC++;
            }
        }
    }

    Vector3 ObjRandomPosition()// 랜덤위치
    {
        return new Vector3(Random.Range(-13, 13), Random.Range(-8, 8), 0f);
    }
    public int RandomSignDice()
    {
        return Random.Range(0, 2);


    }
    public bool CheckSignDice(float x_, float y_)
    {
        if (x_ == Xc && y_ == Yc) return true;
        else return false;
    }
    Vector3 EnemyRandomPosition() //랜덤한 백터 반환
    {
        if (Player != null)
        {
            float x = Player.transform.position.x;
            float y = Player.transform.position.y;
            if (x < 0) Xc = +1f;
            else Xc = -1f;
            if (y < 0) Yc = +1f;
            else Yc = -1f;
        }
        float x_ = 0f;
        float y_ = 0f;


        x_ = 23f;
        y_ = 11f;


        if (RandomSignDice() == 0) return new Vector3(x_ * Xc, Random.Range(-1 * y_, y_), 0);
        else return new Vector3(Random.Range(-1 * x_, x_), y_ * Yc, 0);

    }
    Vector3 SetPosition(float x, float y, float z)
    {
        return new Vector3(x, y, z);
    }
    public Vector3 RandomSize()
    {
        int SizeDice = Random.Range(0, 8);
        float Size;
        Size = Random.Range(0.8f, 3.0f);
        return new Vector3(Size, Size, 1f);
    }
    //같은 오브젝트들끼리 중첩되서 소환되면 둘다 삭제 하고 다시소환되기. 다른오브젝트면 우선순위낮은 놈이 삭제되기.
    public void CreateKnifeE()
    {// 몹 크기 랜덤으로
        if (Player != null)
        {
            var Enemy = Instantiate(KnifeEnemy, EnemyRandomPosition(), Quaternion.Euler(0f, 0f, 0f));
            Enemy.transform.localScale = RandomSize();
            Enemy.GetComponent<Player>().StartFlag = true;
        }

    }
    public void CreateBulletE()
    {// 몹크기 랜덤으로
        var Enemy = Instantiate(BulletEnemy, EnemyRandomPosition(), Quaternion.Euler(0f, 0f, 0f));
        Enemy.transform.localScale = RandomSize();
        Enemy.name = "Attacker";
    }
    public void CreateBossE()
    {
        if (IngameLevel == 2 || IngameLevel == 3)
        {
            var Boss = Instantiate(BokBoss, EnemyRandomPosition(), Quaternion.Euler(0f, 0f, 0f)); //위치정해저있어야됨 좌우로 계쏙 움직임.
            Boss.name = "Boss";
        }
        else if (IngameLevel == 5)
        {
            var Boss = Instantiate(BossEnemyCrab, SetPosition(0, -13.1f, 0f), Quaternion.Euler(0f, 0f, 0f)); // 킹크랩 보스 나중에 위치 수정
            Boss.name = "Boss";
        }
        else if (IngameLevel == 4)
        {
            var Boss = Instantiate(BossEnemy2, SetPosition(0, -13.47f, 0f), Quaternion.Euler(0f, 0f, 0f)); // 크라켄 보스
            Boss.name = "Boss";
        }
    }
    public void CreateVictimO()
    {// 위치 정해져있어야할듯.
        var Obj = Instantiate(VictimObj, SetPosition(0f, 0f, 0f), Quaternion.Euler(0f, 0f, 0f));      //currentcount를 victim에서 올려준다 먹힐 때 이거 염두해두자         
        VictimOC++;
    }
    public void CreateWaveO()//미구현
    {
        var Obj = Instantiate(WaveObj, ObjRandomPosition(), Quaternion.Euler(0f, 0f, 0f));
        WaveOC++;
    }
    public void CreateBigTrashO()
    {//위치 정해져 있어야할듯? 바닥 쪽에
        if (Level_ % 2 == 1)
        {
            var Obj = Instantiate(BigTrashObj, SetPosition(0, -0.67f, 0f), Quaternion.Euler(0f, 0f, 0f)); // 크라켄 쓰레기
            Obj.name = "_Kraken";
        }
        else if (Level_ != 0 && Level_ % 2 == 0)
        {
            var Obj = Instantiate(BigTrashObj2, SetPosition(0, -13.3f, 0f), Quaternion.Euler(0f, 0f, 0f)); // 킹크랩 쓰레기
            Obj.name = "TrashCrab";
        }


    }
    public void CreateTrashO()
    {
        var Obj = Instantiate(TrashObj, ObjRandomPosition(), Quaternion.Euler(0f, 0f, 0f));
        Obj.name = "Can";
    }
    public void CreateTrash2O()
    {
        var Obj = Instantiate(TrashObj2, ObjRandomPosition(), Quaternion.Euler(0f, 0f, 0f));
        Obj.name = "Paper";
    }
    public void CreateBubblesShiled()
    {
        var Obj = Instantiate(BubblesShiledObj, SetPosition(0f, 0f, 0f), Quaternion.Euler(0f, 0f, 0f));
        BubblesShiledOC++;
    }
    public void CreateTrashRope()
    {

    }
    public void CamAnimation()//미구현
    {
        //검정화면만들기  UI지우기, 캠이동하기, 소리재생, 원래 캐릭비추기 특정 몹 비추기
    }

    public void ResetMaxCounter()//모든 오브젝트 최대 생성 갯수 0으로 초기화
    {
        BossMaxCount = 0;
        WaveMaxCount = 0;
        TrashMaxCount = 0;
        Trash2MaxCount = 0;
        VictimMaxCount = 0;
        BigTrashMaxCount = 0;
        KnifeEnemyMaxCount = 0;
        BulletEnemyMaxCount = 0;
    }
    public void ResetCounter()//모든 오브젝트 현재 소환된 갯수 0으로 초기화
    {
        KnifeEC = 0;
        BulletEC = 0;
        BossEC = 0;
        VictimOC = 0;
        WaveOC = 0;
        BigTrashOC = 0;
        TrashOC = 0;
        Trash2OC = 0;

    }
    public void ShapeInit()// 각 퀘스트별 형태 정의
    {
        if (QuestBoard_ != null)
        {
            if (ShapeNum == 1) ShapeA_Init();
            //else if (ShapeNum == 2) ShapeB_Init();
            //if (ShapeNum == 10) tutorial.GetComponent<Tutorial>().Tutorial_Init();
        }

    }// Shape초기화
    public void ShapeA_Init()
    {
        if (Stayge != null)
        {
            CurrentCountInit();
            if (Level_ > 0)
            {
                Text T = QuestBoard_.GetComponent<QB>().ShapeA.transform.GetChild(2).GetComponent<Text>();
                QuestBoard_.GetComponent<QB>().ShapeA.SetActive(true);
                QuestBoard_.GetComponent<QB>().ShapeA.transform.GetChild(1).GetComponent<Image>().sprite = Stayge.GetComponent<Stage>().Icon;
                if (Level_ != 0 && Level_ % 2 == 0 && IngameLevel == 3)
                    T.text = "적 수 : " + Stayge.GetComponent<Stage23>().EnemyCount.ToString();
                else if (Level_ != 0 && Level_ % 2 == 0 && IngameLevel == 2) T.text = "HP : " + Stayge.GetComponent<Stage>().BossHP.ToString();
                else
                {
                    T.text = CurrentCount.ToString() + " / " + MaxCount.ToString();
                }
            }
            else
            {
                QuestBoard_.GetComponent<QB>().ShapeA.SetActive(false);
            }
        }
    }//???????? ????
    public void ShapeA_EndCheck()//shapeA에 대한 성공체크(갯수다모으는거)
    {
        if (CurrentCount >= MaxCount)
        {
            Debug.Log("성공공공");
            Debug.Log("맥스" + MaxCount);

            if ((Level_ % 2 == 1 && IngameLevel == 5) || (Level_ != 0 && Level_ % 2 == 0 && IngameLevel == 6) || (Level_ == 0 && IngameLevel == 5))
            {
                GM.GetComponent<GameManager_>().SuccesFlag = true;
                ResetPlayerStat();
                ResetMaxCounter();
                ResetCounter();
                Flag = true;
            }
            else
            {
                Flag = true;
                IngameLevel++;
            }
        }

    }
    //??????
    public void EndGameCheck()// 게임 끝낫나 체크
    {
        if (GM.GetComponent<GameManager_>().EndFlag == false)
        {

            if (LoseFlag || Player.GetComponent<PlayerScript>().StartFlag2 && Player.GetComponent<PlayerScript>().Life == false)
            {
                Player.GetComponent<Player>().MyBody.tag = "NotBody";
                GM.GetComponent<GameManager_>().EndFlag = true;
                GM.GetComponent<GameManager_>().LosePanel.SetActive(true);
                IngameLevel = 1;
                LoseFlag = false;
                Flag = true;
                StagyStagtFlag = false;

            }
            else if (GM.GetComponent<GameManager_>().SuccesFlag)
            {
                Player.GetComponent<Player>().MyBody.tag = "NotBody";
                Debug.Log("성공성공");
                Level_++;
                IngameLevel = 1;
                GM.GetComponent<GameManager_>().EndFlag = true;
                GM.GetComponent<GameManager_>().WinPanel.SetActive(true);
                Score = (Score + 1) * (1 + Player.GetComponent<PlayerScript>().killScore) / ((int)Player.GetComponent<PlayerScript>().globalTime + 1);
                GM.GetComponent<GameManager_>().WinPanel.transform.GetChild(4).GetComponent<Text>().text = "Score : " + Score.ToString();
                GM.GetComponent<GameManager_>().SuccesFlag = false;

                Flag = true;
                StagyStagtFlag = false;
                GameSave();
            }

        }
    }//??????????? ??

    public void GameSave()
    {
        PlayerPrefs.SetInt("Level", Level_);
        PlayerPrefs.Save();
    }
    public void GameLoad()
    {
        if (!PlayerPrefs.HasKey("Level"))
        {
            Level_ = 0;
            return;
        }
        else Level_ = PlayerPrefs.GetInt("Level");
    }
}