using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stagy21 : Stage
{
    // Start is called before the first frame update
   
    public GameObject Potal;// 포탈에 닿아서 n초있으면 클리어
    public int ClearLevel;
    public GameObject[] Wall;

    void Start()
    {
        ClearLevel = 1;
        GoalCount = 0;
        flag = true;
        QM = GameObject.FindGameObjectWithTag("QM");
        TrashFlag = true;
        Potal = GameObject.FindGameObjectWithTag("Potal");

    }

    // Update is called once per frame
    void Update()
    {
        TrashOn();
        if (flag)
        {
            setWalls();
            QMInit();
            flag = false;
        }
        GoalCount = Potal.GetComponent<Potal>().Goal;
        ChRagerPoint();


    }
    void QMInit()
    {
        QM.GetComponent<QuestManager>().ResetPlayerStat();
        //TutorialName.SetActive(false);
        //GM.GetComponent<GameManager_>().ObjectCleaner();
        QM.GetComponent<QuestManager>().ShapeNum = 1;
        QM.GetComponent<QuestManager>().ResetCounter();
        QM.GetComponent<QuestManager>().ObjectCleanerNextStage();
        QM.GetComponent<QuestManager>().ResetMaxCounter();
        QM.GetComponent<QuestManager>().MaxCount = 1;
        QM.GetComponent<QuestManager>().StagyStagtFlag = true;
        QM.GetComponent<QuestManager>().ObjMFlag = false;
        QM.GetComponent<QuestManager>().Player.transform.position =  Wall[ClearLevel - 1].transform.position;
    }
    void setWalls()
    {
        Wall[0] = GameObject.FindGameObjectWithTag("1");
        Wall[1] = GameObject.FindGameObjectWithTag("2");
        Wall[2] = GameObject.FindGameObjectWithTag("3");
        Wall[3] = GameObject.FindGameObjectWithTag("4");
    }
    public void ChRagerPoint()
    {// wall자체 코드에서 벽부술시 레벨올리고, 이함수 호출

        QM.GetComponent<QuestManager>().Player.GetComponent<Player>().RagerPoint = Wall[ClearLevel - 1].transform.position;
    }
    public void upWall()
    {
        Wall[ClearLevel - 1].transform.localScale = new Vector3(2, 1, 1);
        ClearLevel++;
    }
   
}

