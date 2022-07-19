
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
//패널 관리, 게임 종료관리, 게임 시작 관리등
public class GameManager_ : MonoBehaviour
{
    public GameObject Lobby_;
    public GameObject InGame;
    public GameObject Intro;
    public GameObject Player;//플레이어 게임오브젝트
    public GameObject Player_p;
    //public GameObject AiPlayer;//ai게임오브젝트
    //public GameObject[] AiPlayers;
    //public GameObject[] Players;//ai와  플레이어 참조할 변수 [0]은플레이어
    GameObject[] Fleshs;
    GameObject[] Bubbles;
    public GameObject LobbyPlayerBody;//로비플레이어
    public GameObject LobbyPlayerKnife;
    public Camera maincam;// 메인캠
    //0은 myplayer
    public int MaxPlayerCount = 4;
    public bool enterFlag;
    public GameObject Flesh;//시체
                            // fakePanel 에서 받아옴.게임 시작 넘겨주기 위해.
    public bool StartKeyFlag;
    public bool resetFlag;
    // 소환에 필요한 객체
    public bool EndFlag = false;
    //public GameObject FakePanel;// 가짜 매칭 패널

    public bool StartFlag_;// 게임이 시작했는지, 페이크 패널이 사라지면 시작이다. fakePanel 에서 넘겨줌. true 로. PlayerScript로 넘겨주자.
    public bool enterGame;//게임입장시 트루
    public bool StartButtonFlag;

    public float GlobalTime;

    public GameObject WinPanel;
    public GameObject LosePanel;
    public bool SuccesFlag = false;
    public GameObject QM;
    private void Start()
    {

        Application.targetFrameRate = 60;
        GlobalTime = 1;
        resetFlag = false;
        // Players = new GameObject[MaxPlayerCount];
        // AiPlayers = new GameObject[MaxPlayerCount - 1];
        // Ai 값 할당
        StartKeyFlag = false;
        enterGame = false;
        // FakePanel.SetActive(false);
        StartFlag_ = false;
        StartButtonFlag = false;
        //SetResolution();
        Lobby_ = GameObject.FindGameObjectWithTag("Lobby").gameObject;
    }

    private void Update()
    {
       
        //OnPreCull();
        if (StartKeyFlag)
        {
            StartKey();
             EnterInit();
               enterGame = true;
            //  SetTarget();
            resetFlag = false;
            Debug.Log("aaaa");
            InGame = GameObject.FindGameObjectWithTag("InGame").gameObject;
         
            Player_p.GetComponent<PlayerScript>().StartFlag = true;
        }

       
        Player_p = GameObject.FindGameObjectWithTag("Player");
        if (Player_p != null)
        {

            if (GlobalTime > 0 && EndFlag == false)
            {
                GlobalTime += Time.deltaTime;
                Player_p.GetComponent<PlayerScript>().globalTime = GlobalTime;
            }

        }
        else if(Player_p ==null) ObjectCleaner();
    }

    public void GoLobby()
    {
        ResetGame();
        Lobby_.SetActive(true);
        Debug.Log("lobby");
        InGame.SetActive(false);
        LosePanel.SetActive(false);
        WinPanel.SetActive(false);
    }
    public void GoNext()
    {
        ResetGame();
        InGame.SetActive(true);
        Intro.SetActive(true);
        LosePanel.SetActive(false);
        WinPanel.SetActive(false);

    }

    public void ReStart_()
    {
        ResetGame();
        InGame.SetActive(true);
        Intro.SetActive(true);
        LosePanel.SetActive(false);
        WinPanel.SetActive(false);
    }


    public void ResetGame()
    {
        Debug.Log("reset");
        enterGame = false;
        resetFlag = true;
        EndFlag = true;
        StartKeyFlag = false;
        GlobalTime = 0;
        
        StartButtonFlag = false;
        ObjectCleaner();
        QM.GetComponent<QuestManager>().Flag = true;
        QM.GetComponent<QuestManager>().ResetCounter();
        QM.GetComponent<QuestManager>().IngameLevel = 1;
        QM.GetComponent<QuestManager>().ResetMaxCounter();
        QM.GetComponent<QuestManager>().ResetPlayerStat();
        Destroy(QM.GetComponent<QuestManager>().Player);
    }
    public void ObjectCleaner(){
        GameObject[] trush_ = GameObject.FindGameObjectsWithTag("Trush");
        GameObject[] Items = GameObject.FindGameObjectsWithTag("Item");
        GameObject[] Attackers = GameObject.FindGameObjectsWithTag("Attacker");
        GameObject[] AiPlayers = GameObject .FindGameObjectsWithTag("AiPlayer");
        GameObject Kraken = GameObject.FindGameObjectWithTag("Kraken");
        GameObject []BigTrash = GameObject.FindGameObjectsWithTag("BigTrash");
        GameObject V = GameObject.FindWithTag("V");
        Destroy(Kraken);
        Destroy(V);
        for (int i = 0; i < BigTrash.Length; ++i)
        {
            Destroy(BigTrash[i],0f);
        }
        for (int i = 0; i < trush_.Length; ++i)
        {
            Destroy(trush_[i],0f);
        }
        for (int i = 0; i < Items.Length; ++i)
        {
            Destroy(Items[i],0f);
        }
        for (int i = 0; i < Attackers.Length; ++i)
        {
            Destroy(Attackers[i],0f);
        }
        for(int i=0;i<AiPlayers.Length;++i){
            Destroy(AiPlayers[i],0f);
        }
    }
    public void Start___()
    {
        StartKeyFlag = true;
        StartButtonFlag = true;
    }
    void StartKey()
    {

      
        StartKeyFlag = false;


    }//T누르면 게임시작
    void EnterInit()
    {
         resetFlag = false;
          EndFlag = false;
        //FakePanel.SetActive(true);

        MyPlayerCreate();

        //Ai플레이어 9마리 생성
        /*for (int i = 1; i < MaxPlayerCount; i++)
        {
            CreateAiPlayer(i);
        }*/
     

    }//게임들어오면 하는일
    /*void CreateAiPlayer(int index)
    {     
        //Ai플레이어생성
        Players[index] = Instantiate(AiPlayer, RandomPosition(), Quaternion.Euler(0, 0, 0));
        giveProfil(index);
        SetExtra(Players[index]);
    }   //Ai 프로필 작성과 캐릭터생성
    */
    public void CreateVictem(Vector3 V, int AttackerCount)
    {// 특정위치에 생성, 어테커가 다죽으면 무적풀리고 플레이어에게 구출가능한 상태가 됨.

    }
    public void CreateAttacker(Vector3 VictemPosition, Vector3 UserPosition)
    {// 피해자위치에 생성 -> 플래이어에게 대포발사

    }

    void MyPlayerCreate()
    {
        Debug.Log("플소환");
        //로비에서 가져온 값
        int BN = LobbyPlayerBody.GetComponent<LobbyFish>().FishNum;
        int KN = LobbyPlayerKnife.GetComponent<LobbySword>().SwordNum;
        //메인플레이어생성
        Player_p = Instantiate(Player, RandomPosition(), Quaternion.Euler(0, 0, 0));
        //플레이어에게 카메라 붙이기
        maincam.GetComponent<Tracking_player>().target_set(Player_p);
        //MyPlayerInit
        Player_p.GetComponent<Player>().FishNumber = BN;//BN로비에서 가져오는것       
        Player_p.GetComponent<Player>().KnifeNumber = KN;
        Player_p.GetComponent<PlayerScript>().maincam_ = maincam;


        //giveProfil(0);
        SetExtra(Player_p);
    }// 내캐릭 생성 Players[0] 번째는 MyPlayer
    void giveProfil(int index)
    {
        //FakePanel.GetComponent<FakePanel>().SetProfil(index, Players[index]);//프로필주기.
    }//프로필 페이크페널로 넘겨주기
    void SetExtra(GameObject _Player1__)
    {
        _Player1__.GetComponent<Player>().GM = gameObject;
        //_Player1__.GetComponent<Player>().StartFlag = true;

        // _Player1__.SetActive(false);
    }//반복되는 코드 줄인거
    /*
    public void SetTarget()//생성하자마자 
    {       
        for (int i = 1; i < MaxPlayerCount; ++i)
        {
            Players[i].GetComponent<AiPlayerScript>().Target = Players[0];
            
        }
    }//모든 AI는 플레이어의위치알고있다 노란위치추적점을 플레이어 카메라에띄워야하기때문임 다만 이기능은구현아직 x
*/
    void ShowPlayers()
    {

        Player_p.SetActive(true);
    }//페이크 페널 끝나면 플레이어들 보여주기

    Vector3 RandomPosition() //랜덤한 백터 반환
    {
        return new Vector3(Random.Range(-13, 13), Random.Range(-8, 8), 0);
    }

    public void SetResolution()
    {
        int setWidth = 1920; // 사용자 설정 너비
        int setHeight = 1080; // 사용자 설정 높이

        int deviceWidth = Screen.width; // 기기 너비 저장
        int deviceHeight = Screen.height; // 기기 높이 저장

        Screen.SetResolution(Screen.width, Screen.width * setWidth / setHeight, true); // SetResolution 함수 제대로 사용하기

        if ((float)setWidth / setHeight < (float)deviceWidth / deviceHeight) // 기기의 해상도 비가 더 큰 경우
        {
            float newWidth = ((float)setWidth / setHeight) / ((float)deviceWidth / deviceHeight); // 새로운 너비
            Camera.main.rect = new Rect((1f - newWidth) / 2f, 0f, newWidth, 1f); // 새로운 Rect 적용
        }
        else // 게임의 해상도 비가 더 큰 경우
        {
            float newHeight = ((float)deviceWidth / deviceHeight) / ((float)setWidth / setHeight); // 새로운 높이
            Camera.main.rect = new Rect(0f, (1f - newHeight) / 2f, 1f, newHeight); // 새로운 Rect 적용
        }

    }
    private void OnCollisionEnter2D(Collision2D other2)
    {
        if (resetFlag == true)
            if (other2.transform.tag == "Flesh" || other2.transform.tag == "Bubble" || other2.transform.tag == "AiPlayer" || other2.transform.tag == "Player")
            {
                Destroy(other2.gameObject);

            }
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (resetFlag == true)
            if (other.transform.tag == "Flesh" || other.transform.tag == "Bubble" || other.transform.tag == "AiPlayer" || other.transform.tag == "Player")
            {
                Destroy(other.gameObject);
            }
    }
    void OnPreCull() => GL.Clear(true, true, Color.black);


}










