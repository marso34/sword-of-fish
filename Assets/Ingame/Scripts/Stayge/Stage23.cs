using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Stage23 : Stage
{
    // Start is called before the first frame update
    public int WaveLevel;
    public int EnemyCount;
    public int GoalLevel;
    public bool SucssesFlag;
    public bool WavingFlag;
    public GameObject Granpa;
    public bool flag_;
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
        flag_ = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (flag)
        {
            ShowText();
            //Granpa = GameObject.FindGameObjectWithTag("VicTem");
            GameObject Cam = GameObject.FindGameObjectWithTag("MainCamera");
            Cam.transform.position = new Vector3(0, 0, Cam.transform.position.z);
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
            Destroy(GameObject.FindGameObjectWithTag("V"));
            VEC = Instantiate(QM.GetComponent<QuestManager>().Vectorv, QM.GetComponent<QuestManager>().Player.transform.position, Quaternion.Euler(0, 0, 0));
        }
        else
        {

            TrashOn();
            if (CheckWaveEnd() && WaveLevel < GoalLevel)
            {
                if (flag_)
                {

                    Invoke("WaveRun", 3f);
                }
                flag_ = false;
                Debug.Log(WaveLevel + "·¹º§");
            }
            if (WaveLevel == GoalLevel) GoalCount++;
        }
        if (VEC != null && VEC.GetComponent<FlowingBigT>().BigT == null)
        {
            if (GameObject.FindWithTag("AiPlayer") != null)
                VEC.GetComponent<FlowingBigT>().setBigT(GameObject.FindWithTag("AiPlayer"));
            else if (GameObject.FindWithTag("Attacker") != null)
            {
                VEC.GetComponent<FlowingBigT>().setBigT(GameObject.FindWithTag("Attacker"));
            }
        }
        
        Debug.Log(EnemyCount + "Àû¼ö");
    }
    public bool CheckWaveEnd()
    {
        if (EnemyCount <= 0)
        {
            if (!WavingFlag)
            {
                WaveLevel++;
                WavingFlag = true;
                flag_ = true;
            }
            return true;
        }
        else return false;
    }
    public void WaveRun()
    {
        if (WavingFlag)
        {
            if (WaveLevel > 0)
                ShowWaveLevel();

            if (WaveLevel == 1)
            {
                for (int i = 0; i < 2; ++i)
                {
                    QM.GetComponent<QuestManager>().CreateKnifeE();
                    EnemyCount++;
                    Debug.Log("¼ÒÈ¯");
                }
                for (int j = 0; j < 2; ++j)
                {
                    QM.GetComponent<QuestManager>().CreateBulletE();
                    EnemyCount++;
                    Debug.Log("¼ÒÈ¯");
                }
            }

            else if (WaveLevel == 2)
            {
                for (int i = 0; i < 2; ++i)
                {
                    QM.GetComponent<QuestManager>().CreateKnifeE();
                    EnemyCount++;
                }
                for (int j = 0; j < 3; ++j)
                {
                    QM.GetComponent<QuestManager>().CreateBulletE();
                    EnemyCount++;
                }
            }

            else if (WaveLevel == 3)
            {
                for (int i = 0; i < 2; ++i)
                {
                    QM.GetComponent<QuestManager>().CreateKnifeE();
                    EnemyCount++;
                }
                for (int j = 0; j < 2; ++j)
                {
                    QM.GetComponent<QuestManager>().CreateBulletE();
                    EnemyCount++;
                }
                QM.GetComponent<QuestManager>().CreateBossE();
                EnemyCount++;
            }

            WavingFlag = false;
            Debug.Log(EnemyCount + "Àû·¹º§");
        }

    }
    public void ShowWaveLevel()
    {
        GameObject.FindGameObjectWithTag("ShowText").gameObject.GetComponent<ShowInLevel>().showText("WaveLevel" + " " + WaveLevel);
    }
    public void ShowText()
    {
        GameObject.FindGameObjectWithTag("ShowText").gameObject.GetComponent<ShowInLevel>().showText("ÀûµéÀ» ¸ðµÎ ¼¶¸êÇØÁà!");
        GameObject.FindGameObjectWithTag("QB").transform.GetChild(3).GetComponent<ShowQBText>().showText("ÀûµéÀ» ¸ðµÎ ¼¶¸êÇØÁà!");
    }
}
