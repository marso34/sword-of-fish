using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage16 : Stage
{
    void Start()
    {
        GoalCount = 0;
        flag = true;
        QM = GameObject.FindGameObjectWithTag("QM");
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
            QM.GetComponent<QuestManager>().KnifeEnemyMaxCount = 6;
            QM.GetComponent<QuestManager>().BulletEnemyMaxCount = 2;
            QM.GetComponent<QuestManager>().BulletEC = 2;
            QM.GetComponent<QuestManager>().BossMaxCount = 1;
            QM.GetComponent<QuestManager>().MaxCount = 1;
            flag = false;
            QM.GetComponent<QuestManager>().StagyStagtFlag = true;
        }
        GoalCount = QM.GetComponent<QuestManager>().Player.GetComponent<PlayerScript>().BosskillScore;
    }
}
