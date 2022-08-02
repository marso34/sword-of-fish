using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor;
public class QuestManager : MonoBehaviour
{

    public GameObject[] Stayges;//스테이지 객체 배열


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
    public GameObject BossEnemy1;//중간보스 복어
    public GameObject BossEnemy2;// 1라운드 보스 타코야
    public GameObject VictimObj;
    public GameObject WaveObj;
    public GameObject BigTrashObj;
    public GameObject TrashObj;
    public GameObject TrashObj2;

    public GameObject BubblesShiledObj;
    public int IngameLevel;
    //--------------------
    public bool LoseFlag;// 죽었거나 시간초 다됐을때
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
    public int[] Rank;// ShapeB일 떄 사용 현재 랭크 상위 4명만 표시
    public int OccupationTime;//ShapeC일 때 사용 점령전 얼마나 찾는지.
    public bool Flag = true;// update에서 한번만 실행할 구문 경계 구분 
    public Image me;//안쓰는 변수
    //아이콘들은 인트로 패널에서 쓰임. 각 이미지.
    //----------------------------------------------------
    public Sprite TimeIcon;
    public GameObject SpearImg;
    public Sprite FleshIcon;
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
    public GameObject TutorialPlan;
    public bool StagyStagtFlag;

    public int TutorialLev;
    public int TempTuLev;
    //public bool TuLev1 = false;
    public bool EndTutorial; // 튜토리얼 끝났는지확인
    public bool TutorialCheck;

    public bool CheckFlesh;
    public bool CheckTrash;
    public Transform Canvas;
    public GameObject tutorial;
    public int ResetTouch;


    public float timer;
    public int waitingTime;
    public int TempFlesh;
    public GameObject TutoBack;
    public GameObject Guide;
    public bool A = true;
    public GameObject BokBoss;
    public GameObject JoyStick;
    public GameObject Slider; //슬라이더 이미지1

    public GameObject BusterBtn;
    public GameObject SkillBtn;
    public GameObject Stop;
    public GameObject QuestBoard;
    bool B = false;
    public GameObject Vectorv;
    public GameObject KillBoard;
    public GameObject TimeBoard;

    public int tempkill;
    public bool temp = false;
    public GameObject itembtn;
    public Transform IntroPenelT;
    public Transform PlayerT;
    public int TutorialLevel;
    public GameObject body;
    
    public bool TIsMove = false;
    void Start()
    {
        Level_ = 0;//초기 렙설정
        IngameLevel = 1; //n스테이지진입후 n-n 스테이지레벨    
        TutorialLevel = 0;
        LoseFlag = false;
        OccupationTime = 0;
        TutorialLev = 0;
        waitingTime = 2;
        TempTuLev = 0;
        StagyStagtFlag = false;
    }
    void Update()
    {
        if (GM.GetComponent<GameManager_>().enterGame && GM.GetComponent<GameManager_>().EndFlag == false)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
            Test_Method();
            FlagOnMethod();
            if (Player != null && StagyStagtFlag)
            {
                // Debug.Log("? ??" + KnifeEC + "???" + BulletEC);
                QuestBoard_ = GameObject.FindGameObjectWithTag("QB");

                ShapeInit();
                SucssesFlagOnOff();
                EndGameCheck();
                Objectmanager();
                if (IngameLevel > 8) IngameLevel = 5;
                if (IngameLevel < 0) IngameLevel = 0;
            }
        }

    }
    public void FlagOnMethod()
    {//?? ???????? ??????? ????? ????
        if (Flag)
        {
            if (Level_ == 0)
            {
                Level_0_Action();
            }

            if (Level_ == 1)
            {
                Level_1_Action();
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
            IngameLevel = 3;
            Flag = true;
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            IngameLevel = 4;
            Flag = true;
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            IngameLevel = 6;
            Flag = true;
        }

        if (Input.GetKeyDown(KeyCode.G)) Player.transform.localScale = new Vector3(Player.transform.localScale.x + 1f, Player.transform.localScale.y + 1f, 1f);
        if (Input.GetKeyDown(KeyCode.R)) Player.GetComponent<Player>().HP++;
        Levelboard.GetComponent<Text>().text = Level_.ToString();
        //if (Input.GetKeyDown(KeyCode.P)) Level_++;
        if (Input.GetKeyDown(KeyCode.O)) Level_--;
    }
    public void SucssesFlagOnOff()// 게임 실패 검사
    {
        if (ShapeNum == 5) TimeOut_EndCheck();
        else if (ShapeNum == 1) ShapeA_EndCheck();
        //else if (ShapeNum == 2) ShapeB_EndCheck();
        else if (ShapeNum == 3) ShapeC_EndCheck();
        else if (ShapeNum == 10) Tutorial_EndCheck();
    }// 게임 끝나는거 체
    public void Level_0_Action()
    {
        if (Level_ == 0)
        {
            /*
            ResetPlayerStat();

            if(TutorialLev < 3)
            {
                KnifeEnemyMaxCount = 0;
                BulletEnemyMaxCount = 0;
                MaxCount = 1;
            }

            else if(TutorialLev >= 3)
            {
                TrashMaxCount = 5;
                Trash2MaxCount = 5;

            }*/
        }
    }
    public void Level_1_Action() // 소 스테이지 레벨마다 퀘스트 초기화 
    {
        if (Level_ == 1)
        {
            ResetPlayerStat();
            if (IngameLevel == 1)
            {
                Destroy(GameObject.FindGameObjectWithTag("tt"));
                //TutorialName.SetActive(false);
                //GM.GetComponent<GameManager_>().ObjectCleaner();
                ResetMaxCounter();// 모든 맥스카운터 0으로 초기화
                ResetCounter();// 모든 현재 존재하는 오브젝트 카운트한거 0으로 다 초기화
                KnifeEnemyMaxCount = 4;// 칼든 적물고기 최대 4마리소환
                MaxCount = 2;// 킬 보드에 표시된 킬스코어 2달성시 클리어
                Player.transform.localPosition = Vector3.zero;
            }
            else if (IngameLevel == 2)
            {
                ResetMaxCounter();
                KnifeEnemyMaxCount = 5;
                BulletEnemyMaxCount = 1;// 총알쏘는 적 1마리 소환
                MaxCount = 4;//킬 보드에 표시된 킬스코어 4달성시 클리어
            }
            else if (IngameLevel == 3)
            {
                ResetMaxCounter();
                KnifeEnemyMaxCount = 5;
                BulletEnemyMaxCount = 2;
                MaxCount = 6;// 킬 보드에 표시된 킬스코어 6달성시 클리어
            }
            else if (IngameLevel == 4)
            {
                ObjectCleanerNextStage();
                ResetMaxCounter();
                //ResetCounter();
                BossMaxCount = 1;
                MaxCount = 1; // 보스 한명 잡을시 클리어
            }
            else if (IngameLevel == 5)
            {
                ResetMaxCounter();
                ResetCounter();
                KnifeEnemyMaxCount = 5;
                BulletEnemyMaxCount = 3;
                MaxCount = 9;// 킬 보드에 표시된 킬스코어 9달성시 클리어
            }
            else if (IngameLevel == 6)
            {
                Instantiate(Vectorv, Player.transform.position, Quaternion.Euler(0, 0, 0));
                ResetCounter();
                ObjectCleanerNextStage();
                //?÷?????? ???? ??? ?÷?????????? ??????????? ???? ?????. ??? ?????? ??????????? ?? ??????? ????
                ResetMaxCounter();
                KnifeEnemyMaxCount = 0;
                BulletEnemyMaxCount = 0;
                BigTrashMaxCount = 1;
                MaxCount = 1;// 큰쓰레기 1개 부술시 클리어
            }
            else if (IngameLevel == 7)
            {
                Destroy(GameObject.FindGameObjectWithTag("V"));
                ResetCounter();
                ObjectCleanerNextStage();
                ResetMaxCounter();
                KnifeEnemyMaxCount = 2;
                BulletEC = 2;
                BossMaxCount = 1;
                MaxCount = 1;
                // 보스잡을시 클리어
            }
            TrashMaxCount = 5;
            Trash2MaxCount = 5;
            CurrentCount = 0;
        }
    }
    public void Level_2_Action()
    {
        if (Level_ == 2)
        {
            if (IngameLevel == 1)
            {
            }
            if (IngameLevel == 2)
            {
            }
            if (IngameLevel == 3)
            {
            }
            if (IngameLevel == 4)
            {

            }
            if (IngameLevel == 5)
            {

            }
        }
    }
    public void CurrentCountInit()//퀘스트 완료조건 정의
    {
        if (IngameLevel == 1)
        {
            CurrentCount = Player.GetComponent<PlayerScript>().killScore;
        }
        else if (IngameLevel == 2)
        {
            CurrentCount = Player.GetComponent<PlayerScript>().killScore;// 레벨에 따라 CurrentCount를 채워주는것은 달라져야한다.
        }
        else if (IngameLevel == 3)
        {
            CurrentCount = Player.GetComponent<PlayerScript>().killScore;
        }
        else if (IngameLevel == 4)
        {
            CurrentCount = Player.GetComponent<PlayerScript>().BosskillScore;//Maxcount가 특정 물고기 번호
        }
        else if (IngameLevel == 5)
        {
            CurrentCount = Player.GetComponent<PlayerScript>().killScore;//Maxcount가 특정 물고기 번호
        }
        else if (IngameLevel == 6)
        {
            CurrentCount = Player.GetComponent<PlayerScript>().BigTrashC;
        }

        else if (IngameLevel == 7)
        {
            CurrentCount = Player.GetComponent<PlayerScript>().BosskillScore;
        }
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
            ShapeNum = 10;
            IntroPanel.SetActive(true);


            TutorialLev = 1;

            GameObject.FindWithTag("plan").SetActive(false);
            GameObject.FindWithTag("Stage1").SetActive(false);
            GameObject.FindWithTag("plan1").SetActive(false);
            GameObject.FindWithTag("Stagy Level").SetActive(false);

            tutorial = Instantiate(tutorial);
            TutorialName = Instantiate(TutorialName);
            TutoBack = Instantiate(TutoBack);

            
            tutorial.transform.SetParent(Canvas);
            TutoBack.transform.SetParent(GM.transform);
            tutorial.transform.SetSiblingIndex(0);
            tutorial.SetActive(false);
            TutoBack.SetActive(false);
            TutorialPlan.SetActive(false);
            A = true;
            
            TutorialName.transform.SetParent(IntroPenelT);
            TutorialName.transform.localPosition = new Vector3(0, 0, 0);      
            //GameObject.FindWithTag("IntroPanel").SetActive(false);


        }




        else if (Level_ == 1)
        {

            GameObject.Find("IntroPanel").transform.Find("plan").gameObject.SetActive(true);
            GameObject.Find("IntroPanel").transform.Find("Stage").gameObject.SetActive(true);
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
            IntroPanelName.GetComponent<Text>().text = "1";
            IntroPanelPlan[1].SetActive(true);
            IntroPanelPlan[1].GetComponent<Image>().sprite = FishIcon;
            IntroPanelPlan[1].transform.GetChild(0).GetComponent<Text>().text = "크라켄의 둥지";



        }
        else if (Level_ == 2)
        {
            ShapeNum = 1;
            //IntroPanelName.GetComponent<Text>().text = "2";
            //IntroPanelPlan[1].SetActive(true);
            //IntroPanelPlan[1].GetComponent<Image>().sprite = FleshIcon;
            //IntroPanelPlan[1].transform.GetChild(0).GetComponent<Text>().text = "10개의 고기를 먹으세요";
            limitTime = 1;
            MaxCount = 25;
            KnifeEnemyMaxCount = 3;
            BulletEnemyMaxCount = 2;
        }
        else if (Level_ == 3)
        {
            ShapeNum = 1;
            IntroPanelName.GetComponent<Text>().text = "3";
            IntroPanelPlan[1].SetActive(true);
            IntroPanelPlan[1].GetComponent<Image>().sprite = killIcon;
            IntroPanelPlan[1].transform.GetChild(0).GetComponent<Text>().text = "10킬 하세요";
            limitTime = 90;
            MaxCount = 10;
        }
        else if (Level_ == 4)
        {
            ShapeNum = 1;
            IntroPanelName.GetComponent<Text>().text = "4";
            IntroPanelPlan[1].SetActive(true);
            IntroPanelPlan[1].GetComponent<Image>().sprite = FishIcon;
            IntroPanelPlan[1].transform.GetChild(0).GetComponent<Text>().text = "돌고래4마리 를 잡으세요";
            limitTime = 90;
            MaxCount = 4;
        }
        else if (Level_ == 5)
        {
            ShapeNum = 2;
            IntroPanelName.GetComponent<Text>().text = "5";
            IntroPanelPlan[1].SetActive(true);
            IntroPanelPlan[1].GetComponent<Image>().sprite = RankIcon;
            IntroPanelPlan[1].transform.GetChild(0).GetComponent<Text>().text = "1등을 유지하세요";
            limitTime = 40;
            MaxCount = 1;
        }
        else if (Level_ == 6)
        {
            ShapeNum = 3;
            IntroPanelName.GetComponent<Text>().text = "6";
            IntroPanelPlan[1].SetActive(true);
            IntroPanelPlan[1].GetComponent<Image>().sprite = bubbleIcon;
            IntroPanelPlan[1].transform.GetChild(0).GetComponent<Text>().text = "물방울을 점령하세요";
            limitTime = 40;
            MaxCount = 10;
        }
        else if (Level_ == 7)
        {
            ShapeNum = 1;
            IntroPanelName.GetComponent<Text>().text = "7";
            IntroPanelPlan[1].SetActive(true);
            IntroPanelPlan[1].GetComponent<Image>().sprite = TrushIcon;
            IntroPanelPlan[1].transform.GetChild(0).GetComponent<Text>().text = "쓰레기를 정리하세요";
            limitTime = 60;
            MaxCount = 25;
        }
        else if (Level_ == 8)
        {
            ShapeNum = 3;
            IntroPanelName.GetComponent<Text>().text = "8";
            IntroPanelPlan[1].SetActive(true);
            IntroPanelPlan[1].GetComponent<Image>().sprite = FlagIcon;
            IntroPanelPlan[1].transform.GetChild(0).GetComponent<Text>().text = "깃발을 탈취하세요";
            limitTime = 60;
            MaxCount = 10;
        }
        CurrentCount = 0;
        OccupationTime = 0;
        GM.GetComponent<GameManager_>().GlobalTime = limitTime;
    }//스테이지 정의
    public void TimeOut_EndCheck()// 시간다됐나 체크 지금은 사용안함
    {
        if (GM.GetComponent<GameManager_>().GlobalTime <= 0)
        {
            //GM.GetComponent<GameManager_>().SuccesFlag = true;
            Level_++;
            Flag = true;

        }
    }//timeout으로 끝나는판
    public void Objectmanager()// 소 스테이지 초기화에서 정해준 오브젝트 최대 갯수만큼 각 오브젝트 계속 생성, 
    {
        // Debug.Log("이거 실행된다...");
        if (KnifeEnemyMaxCount > KnifeEC)
        {
            Invoke("CreateKnifeE", 2.5f);
            KnifeEC++;
        }// 칼 적 생성
        if (BulletEnemyMaxCount > BulletEC)
        {
            Invoke("CreateBulletE", 2.5f);// 총알 적 생성
            BulletEC++;
        }
        if (WaveMaxCount > WaveOC) Invoke("CreateWaveO", 2.5f);// 물결오브제 생성
        if (BigTrashMaxCount > BigTrashOC) CreateBigTrashO();//큰쓰레기 생성 캠액션 할것.
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
        if (BossMaxCount > BossEC) CreateBossE();//보스 생성 캠액션할것.켐 액션 할것.
    }
    Vector3 ObjRandomPosition()// 랜덤위치
    {
        return new Vector3(Random.Range(-13, 13), Random.Range(-8, 8), 0f);
    }
    Vector3 EnemyRandomPosition() //랜덤한 백터 반환
    {
        float x = Player.transform.position.x;
        float y = Player.transform.position.y;
        float Xc;
        float Yc;
        if (x < 0) Xc = 1;
        else Xc = -1;
        if (y < 0) Yc = 1;
        else Yc = 1;
        float realX = x + 8 * Xc;
        float realY = y + 5 * Xc;
        return new Vector3(Random.Range(realX, realX + Xc * 3), Random.Range(realY, realY + Yc * 2), 0f);
    }
    Vector3 SetPosition(float x, float y, float z)
    {
        return new Vector3(x, y, z);
    }
    public Vector3 RandomSize()
    {
        int SizeDice = Random.Range(0, 8);
        float Size;
        float bigSize = Player.transform.localScale.y + 1.2f;
        float littleBigSize = Player.transform.localScale.y + 0.5f;
        if (SizeDice == 0)
            Size = Random.Range(Player.transform.localScale.y, bigSize);
        else if (SizeDice == 1 || SizeDice == 2) Size = Random.Range(Player.transform.localScale.y, littleBigSize);
        else Size = Player.transform.localScale.y;
        if (Size > 3) Size = 3;
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
        if (IngameLevel == 4)
        {
            var Boss = Instantiate(BokBoss, SetPosition(0f, 0f, 0f), Quaternion.Euler(0f, 0f, 0f)); //위치정해저있어야됨 좌우로 계쏙 움직임.
            Boss.name = "Boss";


        }
        else if (IngameLevel == 7)
        {
            var Boss = Instantiate(BossEnemy2, SetPosition(0, -15.55f, 0f), Quaternion.Euler(0f, 0f, 0f));
            Boss.name = "Boss";
        }
        BossEC++;
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
        var Obj = Instantiate(BigTrashObj, SetPosition(0, 0, 0f), Quaternion.Euler(0f, 0f, 0f));
        BigTrashOC++;
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
    public void CreateTrashRope(){
        
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
            else if (ShapeNum == 3) ShapeC_Init();
            else if (ShapeNum == 10) Tutorial_Init();
        }


    }// Shape초기화
    public void ShapeA_Init()
    {
        CurrentCountInit();
        QuestBoard_.GetComponent<QB>().ShapeA.SetActive(true);
        if (Level_ == 1)
        {
            if (IngameLevel < 4){
                QuestBoard_.GetComponent<QB>().ShapeA.transform.GetChild(0).GetComponent<Image>().sprite = killIcon;
            }
            else if (IngameLevel ==4){
                QuestBoard_.GetComponent<QB>().ShapeA.transform.GetChild(0).GetComponent<Image>().sprite = BockBossIcon;
            }
            else if (IngameLevel == 5){
                QuestBoard_.GetComponent<QB>().ShapeA.transform.GetChild(0).GetComponent<Image>().sprite = killIcon;
            }
            else if (IngameLevel == 6){
                QuestBoard_.GetComponent<QB>().ShapeA.transform.GetChild(0).GetComponent<Image>().sprite = TrushIcon;
            }
            else if(IngameLevel == 7){
                QuestBoard_.GetComponent<QB>().ShapeA.transform.GetChild(0).GetComponent<Image>().sprite = TakoBossIcon;
            }
            QuestBoard_.GetComponent<QB>().ShapeA.transform.GetChild(1).GetComponent<Text>().text = CurrentCount.ToString() + " / " + MaxCount.ToString();
        }
        if(Level_ == 2){
            if(IngameLevel == 1){
                //쓰레기줄 생성, 가운데 쓰레기 부수면 통과.
            }
            if(IngameLevel == 2){
                // 아기 물고기 디펜스  
            }
            if(IngameLevel == 3){
                // 새로운 물고기 10마리, 어태커 3마리 잡기
            }
            if(IngameLevel == 4){
                // 거대쓰레기 산 파괴
            }
            if(IngameLevel == 5){
                // 
            }
            
        }

    }//갯수보두 초기화
    /*
    public void ShapeB_Init()
    {
        Rank = new int[Players.Length];
        for (int i = 0; i < Players.Length; ++i)
            Rank[i] = Players[i].GetComponent<Player>().killScore;


        QuestBoard_.GetComponent<QB>().ShapeB.SetActive(true);
        System.Array.Sort(Rank);
        System.Array.Reverse(Rank);
        bool flag__ = true;
        for (int i = 0; i < 4; ++i)
        {

            QuestBoard_.GetComponent<QB>().ShapeB.GetComponent<ShapeB>().Ranks[i].GetComponent<Text>().text = Rank[i].ToString();
            if (Rank[i] == .GetComponent<Player>().killScore && flag__)
            {
                QuestBoard_.GetComponent<QB>().ShapeB.GetComponent<ShapeB>().Ranks[i].GetComponent<Text>().text = "Me";
                flag__ = false;
            }
        }
      //QuestBoard_.GetComponent<QB>().ShapeB.GetComponent<ShapeB>().first;
    }//랭킹보드초기화*/
    public void ShapeC_Init()
    {
        QuestBoard_.GetComponent<QB>().ShapeC.SetActive(true);
        QuestBoard_.GetComponent<QB>().ShapeC.transform.GetChild(0).GetComponent<Image>().fillAmount = (float)OccupationTime / 10f;
    }//점령전초기화
    public void ShapeA_EndCheck()//shapeA에 대한 성공체크(갯수다모으는거)
    {
        if (CurrentCount >= MaxCount)
        {
            if (IngameLevel == 7)
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
        /*
        else if (GM.GetComponent<GameManager_>().GlobalTime <= 0)
        {
            GM.GetComponent<GameManager_>().SuccesFlag = false;
            LoseFlag = true;
    }*/
    }
    /* public void ShapeB_EndCheck()
     {
         if (GM.GetComponent<GameManager_>().GlobalTime <= 0)
         {
             if (Rank[0] == .GetComponent<Player>().killScore)
             {
                // GM.GetComponent<GameManager_>().SuccesFlag = true;
                 Level_++;
                 Flag = true;
             }
             else 
             {
                 GM.GetComponent<GameManager_>().SuccesFlag = false;
                 LoseFlag = true;
             }
         }


     }   //랭킹보드로 끝나는판
     */
    public void ShapeC_EndCheck()
    {
        if (OccupationTime >= MaxCount)
        {
            //GM.GetComponent<GameManager_>().SuccesFlag = true;
            Level_++;
            Flag = true;
        }
        /*
        else if (GM.GetComponent<GameManager_>().GlobalTime <= 0)
        {
            GM.GetComponent<GameManager_>().SuccesFlag = false;
            LoseFlag = true;

        }
*/
    }//점령전
    public void EndGameCheck()// 게임 끝낫나 체크
    {
        if (GM.GetComponent<GameManager_>().EndFlag == false)
        {
            if (LoseFlag || Player.GetComponent<PlayerScript>().StartFlag2 && Player.GetComponent<PlayerScript>().Life == false)
            {

                GM.GetComponent<GameManager_>().EndFlag = true;
                GM.GetComponent<GameManager_>().LosePanel.SetActive(true);
                IngameLevel = 1;
                LoseFlag = false;
                Flag = true;
            }
            else if (GM.GetComponent<GameManager_>().SuccesFlag)
            {
                // Level_++;
                IngameLevel = 1;
                GM.GetComponent<GameManager_>().EndFlag = true;
                GM.GetComponent<GameManager_>().WinPanel.SetActive(true);
                GM.GetComponent<GameManager_>().SuccesFlag = false;
                Level_ = 1;
                Flag = true;
            }
        }
    }//게임끝났는지 체크
    public void Tutorial_EndCheck()
    {
        if (EndTutorial)
        {
            Level_++;
            GM.GetComponent<GameManager_>().SuccesFlag = true;


        }

    }



    public void bornguide() 
    { //플레이어 멈추고 가이드 물고기를 플레이어 자식으로 둠

        GameObject.Find("Canvas").transform.Find("Tutorial(Clone)").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("Tutorial(Clone)").transform.Find("TuText").gameObject.SetActive(true);

    } 


    public void NextTutorial()
    {
        Player.GetComponent<PlayerScript>().StopMove();
                    
        tutorial.SetActive(true);
        TutorialPlan.SetActive(false);

        Guide = GameObject.Find("Player(Clone)").transform.Find("GuidePet(Clone)").gameObject;
        Guide.GetComponent<GuidePet>().BornGuide();
        tutorial.GetComponent<Tutorial>().Touch = 0;
                    
        TutoBack.SetActive(true);
                    
                    
        TutorialLev++;
    }
    
    public void Tutorial_Init() //플레이어 캔버스에 있는거 넣어둠
    {

                
        TutorialPlan = GameObject.Find("Canvas").transform.Find("Tutorial(Clone)").transform.Find("TuText").gameObject;
        tutorial = GameObject.Find("Canvas").transform.Find("Tutorial(Clone)").gameObject;
        //TutorialPlan = GameObject.Find("Canvas").transform.Find("Tutorial(Clone)").transform.Find("TuText").gameObject;
        TutoBack = GameObject.Find("GameManager").transform.Find("TutoBack(Clone)").gameObject;
        //TutoBack.gameObject(SortingLayer(1));
        if (TutorialLev == 1) //이동
        {
                
                
                if(A)   //시작할때 튜토리얼 여러번켜져서 한번 켜지게 임시로 해둠
                {
                    //tutorial.SetActive(true);

                    //TutorialPlan.SetActive(true);
                    TutoBack.SetActive(true);
                    
                    tutorial.SetActive(true);
                    Vector3 direction = Player.transform.localRotation * new Vector3(0,0,-90);
                    A = false;
                }
            

            
            TutorialPlan.GetComponent<Text>().text = "이동하면서 부스터를 사용해보세요";
            
            if (Player.GetComponent<PlayerScript>().BusterFlag
                && Player.GetComponent<PlayerScript>().cutGauge < 70 && Player.transform.localRotation.z != 0) 
            {

                timer += Time.deltaTime;
                if (timer > waitingTime-2) //성공하고 좀이따 성공했다고 띄움
                {
                    
                    timer = 0;
                    Player.GetComponent<PlayerScript>().BusterFlag = false;
                    TutorialPlan.GetComponent<Text>().text = "스킬을 사용해보세요";
                    NextTutorial();

                }
            }


        }


        else if (TutorialLev == 2) //부스터 튜토리얼
        {

            Player.GetComponent<PlayerScript>().FishNumber = 2;
            if (Player.GetComponent<PlayerScript>().skillcheck) //playerscript의 PlaySkill()함수 켜지면 여기도 켜짐
            {
                timer += Time.deltaTime;

                if (timer > waitingTime) //스킬 쓰고 3초뒤에 성공
                {

                    
                    timer = 0;
                    TutorialPlan.GetComponent<Text>().text = "쓰레기를 치우고 나온 아이템을 먹고"+"\n"+"아이템 버튼을 눌러 사용하세요";
                    tutorial.GetComponent<Tutorial>().OnVideo1 = true;
                    tutorial.GetComponent<Tutorial>().StopClick = true;
                    NextTutorial();
                    itembtn = GameObject.Find("Player(Clone)").transform.Find("Canvas").transform.Find("NotEndGame").transform.Find("ItemBtn").gameObject;

                    Trash2MaxCount = 5;


                }
            }
        }

        else if (TutorialLev == 3)
        {
            //여기서 인게임 레벨 바꾸기

            if (itembtn.GetComponent<ItemBtn>().TutorialItem) //playerscript의 PlaySkill()함수 켜지면 여기도 켜짐
            {
                timer += Time.deltaTime;

                if (timer > waitingTime) //스킬 쓰고 3초뒤에 성공
                {

                    
                    timer = 0;
                    TutorialPlan.GetComponent<Text>().text = "공격하는 물고기를 여러번 찌르고"+"\n"+"나온 시체를 먹으세요";
                    tutorial.GetComponent<Tutorial>().OnVideo2 = true;
                    tutorial.GetComponent<Tutorial>().StopClick = true;
                    tutorial.GetComponent<Tutorial>().BornAtt = false;
                    NextTutorial();

                    

                }
            }
        }

        else if (TutorialLev ==4) 
        {
            //Cursor.visible = false;
            body = GameObject.Find("Player(Clone)").transform.Find("body").gameObject;

            if(tutorial.GetComponent<Tutorial>().TouchMo == true && tutorial.GetComponent<Tutorial>().BornAtt)
            {
                BulletEnemyMaxCount = 1;
            }

            
            if(body.GetComponent<BodyInteraction>().TutorialFlesh)
            {
                timer += Time.deltaTime;

                if (timer > waitingTime) //스킬 쓰고 3초뒤에 성공
                {

                    timer = 0;
                    
                    Player.GetComponent<PlayerScript>().StopMove();
                    Destroy(tutorial);
                    Destroy(TutoBack);
                    Destroy(TutorialName);
                    EndTutorial = true;
                    
                }
            }
        }

    }


}