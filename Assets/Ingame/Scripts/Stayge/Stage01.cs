using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage01 : Stage
{
    bool SFlag;
    float Timer;
    float WTimer;
    void Start()
    {
        GoalCount = 0;
        flag = true;
        QM = GameObject.FindGameObjectWithTag("QM");
        TrashGravity = 0.005f;
        TrashFlag = false;
        SFlag = false;
        Timer = 0;
        WTimer = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (flag)
        {
            ShowText();
            GameObject Cam = GameObject.FindGameObjectWithTag("MainCamera");
            QM.GetComponent<QuestManager>().ResetPlayerStat();
            //TutorialName.SetActive(false);
            //GM.GetComponent<GameManager_>().ObjectCleaner();
            QM.GetComponent<QuestManager>().ShapeNum = 1;
            if (GameObject.FindGameObjectWithTag("V") != null)
                Destroy(GameObject.FindGameObjectWithTag("V"));
            QM.GetComponent<QuestManager>().ResetCounter();
            QM.GetComponent<QuestManager>().ObjectCleanerNextStage();
            QM.GetComponent<QuestManager>().ResetMaxCounter();
            QM.GetComponent<QuestManager>().KnifeEnemyMaxCount = 0;
            QM.GetComponent<QuestManager>().BulletEnemyMaxCount = 0;
            QM.GetComponent<QuestManager>().BulletEC = 0;
            QM.GetComponent<QuestManager>().BossMaxCount = 0;
            QM.GetComponent<QuestManager>().MaxCount = 1;
            flag = false;
            QM.GetComponent<QuestManager>().StagyStagtFlag = true;
            QM.GetComponent<QuestManager>().ObjMFlag = false;

        }
        if (QM.GetComponent<QuestManager>().Player.GetComponent<PlayerScript>().BusterFlag == true)
        {
            Timer +=Time.deltaTime;
            if(Timer> WTimer){
                Timer = 0;
                GoalCount = 1;
            }
        }
        else Timer = 0;
        TrashOn();
    }

    public void ShowText()
    {
        GameObject.FindGameObjectWithTag("ShowText").gameObject.GetComponent<ShowInLevel>().showText("부스터 버튼을 오래 눌러줘");
        GameObject.FindGameObjectWithTag("QB").transform.GetChild(3).GetComponent<ShowQBText>().showText("");
    }
}
