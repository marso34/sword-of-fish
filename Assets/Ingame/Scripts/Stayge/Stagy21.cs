using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stagy21 : Stage
{
    // Start is called before the first frame update
    public GameObject Player;
    public GameObject Potal;// 포탈에 닿아서 n초있으면 클리어
    public int ClearLevel;
    public GameObject[] Wall;
    public GameObject ResponePoint;
    public GameObject[] TrashWallPoint;
    public GameObject TrashWall;
    public GameObject TrashMap;

    void Start()
    {
        ClearLevel = 1;
        GoalCount = 0;
        flag = true;
        QM = GameObject.FindGameObjectWithTag("QM");
        TrashFlag = true;
        Potal = GameObject.FindGameObjectWithTag("Potal");
        TrashGravity = 0.1f;
        initHardConst();
    }

    void Update()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Player.GetComponent<PlayerScript>().BusterFlag = false;
        TrashOn();
        if (flag)
        {
            ShowText();
            setWalls();
            QMInit();
            flag = false;

            var t = GameObject.FindGameObjectWithTag("V");
            if (t != null)
                Destroy(t);
        }

        if (Player.GetComponent<Player>().Life)
        {
            if (Player.GetComponent<Player>().MyBody.tag == "Body")
                Player.GetComponent<Player>().RB.velocity += Vector2.right * 2.6f;
        }
        else 
            Player.GetComponent<Player>().RB.velocity = Vector2.zero;
        GoalCount = Potal.GetComponent<Potal>().Goal;
    }
    void QMInit()
    {
        QM.GetComponent<QuestManager>().ResetPlayerStat();
        //TutorialName.SetActive(false);
        // GM.GetComponent<GameManager_>().ObjectCleaner();
        QM.GetComponent<QuestManager>().ShapeNum = 1;
        QM.GetComponent<QuestManager>().ResetCounter();
        QM.GetComponent<QuestManager>().ObjectCleanerNextStage();
        QM.GetComponent<QuestManager>().ResetMaxCounter();
        QM.GetComponent<QuestManager>().MaxCount = 1;
        QM.GetComponent<QuestManager>().StagyStagtFlag = true;
        QM.GetComponent<QuestManager>().ObjMFlag = false;
        GameObject Cam = GameObject.FindGameObjectWithTag("MainCamera");
        Cam.transform.position = new Vector3(ResponePoint.transform.position.x, ResponePoint.transform.position.y, Cam.transform.position.z);
        QM.GetComponent<QuestManager>().Player.transform.position = ResponePoint.transform.position;

        for (int i = 0; i < TrashWallPoint.Length; i++)
        {
            var TW = Instantiate(TrashWall, RandomPositionY(TrashWallPoint[i].transform.position), Quaternion.Euler(0, 0, 0));
            TW.transform.parent = transform;
        } // 쓰레기 벽 생성
    }
    void setWalls()
    {
        for (int i = 1; i < 6; ++i)
        {
            Wall[i - 1] = GameObject.FindGameObjectWithTag(i.ToString());
        }
    }

    Vector3 RandomPositionY(Vector3 V)
    {
        return new Vector3(V.x, V.y + Random.Range(-4f, 4f), V.z);
    }

    public void upWall()
    {
        Destroy(Wall[ClearLevel - 1]);
        ClearLevel++;
    }
    public void ShowText()
    {
        GameObject.FindGameObjectWithTag("ShowText").gameObject.GetComponent<ShowInLevel>().showText("쓰레기를 피해!!");
        GameObject.FindGameObjectWithTag("QB").transform.GetChild(3).GetComponent<ShowQBText>().showText("쓰레기를 피해!!");
    }

}

