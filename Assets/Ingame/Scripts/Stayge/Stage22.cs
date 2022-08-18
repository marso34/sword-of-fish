using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Stage22 : Stage
{
    // Start is called before the first frame update
    public int WaveLevel;
    public int EnemyCount;
    public int GoalLevel;
    public bool SucssesFlag;
    public bool WavingFlag;
    public GameObject Granpa;

    void Start()
    {
        EnemyCount = 0;
        SucssesFlag = false;
        WavingFlag = true;
        GoalCount = 0;
        GoalLevel = 4;
        WaveLevel = 0;
        QM = GameObject.FindGameObjectWithTag("QM");
        flag = true;
        TrashFlag = true;
        TrashGravity = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (flag)
        {
            //Granpa = GameObject.FindGameObjectWithTag("VicTem");
            GameObject Cam = GameObject.FindGameObjectWithTag("MainCamera");
            Cam.transform.position = new Vector3(0,0,Cam.transform.position.z);
            QM.GetComponent<QuestManager>().Player.transform.position = Vector3.zero;
            QM.GetComponent<QuestManager>().ResetPlayerStat();
            //TutorialName.SetActive(false);
            //GM.GetComponent<GameManager_>().ObjectCleaner();\
            
            QM.GetComponent<QuestManager>().ShapeNum = 1;
            Destroy(GameObject.FindGameObjectWithTag("V"));
            QM.GetComponent<QuestManager>().ResetCounter();
            QM.GetComponent<QuestManager>().ObjectCleanerNextStage();
            QM.GetComponent<QuestManager>().ResetMaxCounter();
            QM.GetComponent<QuestManager>().KnifeEnemyMaxCount = 0;
            QM.GetComponent<QuestManager>().BulletEnemyMaxCount = 0;
            QM.GetComponent<QuestManager>().BulletEC = 0;
            QM.GetComponent<QuestManager>().BossMaxCount = 0;
            QM.GetComponent<QuestManager>().MaxCount = 1;
            QM.GetComponent<QuestManager>().StagyStagtFlag = true;
            QM.GetComponent<QuestManager>().ObjMFlag = false;
            flag = false;
        }
        else
        {
            
            TrashOn();
            if (CheckWaveEnd() && WaveLevel < GoalLevel)
            {
                WaveRun();
                Debug.Log(WaveLevel + "레벨");
            }
            if (WaveLevel == GoalLevel) GoalCount++;
        }
        Debug.Log(EnemyCount + "적수");
    }
    public bool CheckWaveEnd()
    {
        if (EnemyCount <= 0)
        {   
            WaveLevel++; 
            WavingFlag = true;
            return true;
        }
        else return false;
    }
    public void WaveRun()
    {
        if (WavingFlag)
        {
            ShowWaveLevel();

            if (WaveLevel == 1)
            {
                for (int i = 0; i < 6; ++i)
                {
                    QM.GetComponent<QuestManager>().CreateKnifeE();
                    EnemyCount++;
                    Debug.Log("소환");
                }
                for (int j = 0; j < 2; ++j)
                {
                    QM.GetComponent<QuestManager>().CreateBulletE();
                    EnemyCount++;
                    Debug.Log("소환");
                }
            }

            else if (WaveLevel == 2)
            {
                for (int i = 0; i < 8; ++i)
                {
                    QM.GetComponent<QuestManager>().CreateKnifeE();
                    EnemyCount++;
                }
                for (int j = 0; j < 1; ++j)
                {
                    QM.GetComponent<QuestManager>().CreateBulletE();
                    EnemyCount++;
                }
            }

            else if (WaveLevel == 3)
            {
                for (int i = 0; i < 10; ++i)
                {
                    QM.GetComponent<QuestManager>().CreateKnifeE();
                    EnemyCount++;
                }
                for (int j = 0; j < 2; ++j)
                {
                    QM.GetComponent<QuestManager>().CreateBulletE();
                    EnemyCount++;
                }
            }
               
            WavingFlag = false;
            Debug.Log(EnemyCount + "적레벨");
        }

    }
    public void ShowWaveLevel()
    {
        GameObject.FindGameObjectWithTag("ShowText").gameObject.GetComponent<ShowInLevel>().showText("WaveLevel" + " " + WaveLevel);
    }
}
