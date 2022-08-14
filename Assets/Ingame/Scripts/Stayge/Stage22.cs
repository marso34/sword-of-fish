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

    void Start()
    {
        EnemyCount = 0;
        SucssesFlag = false;
        WavingFlag = true;
        GoalCount = 0;
        GoalLevel = 4;
    }

    // Update is called once per frame
    void Update()
    {
        if (flag)
        {
            QM.GetComponent<QuestManager>().ResetPlayerStat();
            //TutorialName.SetActive(false);
            //GM.GetComponent<GameManager_>().ObjectCleaner();
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
            flag = false;
        }
        else
        {
            if (CheckWaveEnd() && WaveLevel < GoalLevel){
                WaveRun();
            }
            if(WaveLevel ==GoalLevel) GoalCount++;
        }
    }
    public bool CheckWaveEnd()
    {
        if (EnemyCount <= 0) return true;
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
                }
                for (int j = 0; j < 2; ++j)
                {
                    QM.GetComponent<QuestManager>().CreateBulletE();
                    EnemyCount++;
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
            WaveLevel++;
            WavingFlag = false;
        }
    }
    public void ShowWaveLevel()
    {
        GameObject.FindGameObjectWithTag("ShowText").gameObject.GetComponent<ShowInLevel>().showText("WaveLevel" +" "+ WaveLevel);
    }
}
