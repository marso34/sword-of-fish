using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage04 : Stage
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
            QM.GetComponent<QuestManager>().KnifeEnemyMaxCount = 1;
            QM.GetComponent<QuestManager>().BulletEnemyMaxCount = 1;
            QM.GetComponent<QuestManager>().BulletEC = 0;
            QM.GetComponent<QuestManager>().BossMaxCount = 0;
            QM.GetComponent<QuestManager>().MaxCount = 1;
            flag = false;
            QM.GetComponent<QuestManager>().StagyStagtFlag = true;
            QM.GetComponent<QuestManager>().ObjMFlag = true;
            QM.GetComponent<QuestManager>().Player.GetComponent<PlayerScript>().KomBoCount = 0;
            VEC = Instantiate(QM.GetComponent<QuestManager>().Vectorv, QM.GetComponent<QuestManager>().Player.transform.position, Quaternion.Euler(0, 0, 0));
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
        if (QM.GetComponent<QuestManager>().Player != null &&QM.GetComponent<QuestManager>().Player.GetComponent<PlayerScript>().KomBoCount >= 7)
        {
            GoalCount = 1;
        }
        TrashOn();
    }

    public void ShowText()
    {
        GameObject.FindGameObjectWithTag("ShowText").gameObject.GetComponent<ShowInLevel>().showText("ÄÞº¸¸¦ 7ÀÌ»ó ¿Ã·ÁºÁ!");
        GameObject.FindGameObjectWithTag("QB").transform.GetChild(3).GetComponent<ShowQBText>().showText("");
    }
}
