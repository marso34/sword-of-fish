using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage23 : Stage
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
            QM.GetComponent<QuestManager>().ShapeNum = 1;
            QM.GetComponent<QuestManager>().ResetCounter();
            QM.GetComponent<QuestManager>().ObjectCleanerNextStage();
            QM.GetComponent<QuestManager>().ResetMaxCounter();
            QM.GetComponent<QuestManager>().KnifeEnemyMaxCount = 2;
            QM.GetComponent<QuestManager>().BulletEnemyMaxCount = 0;
            QM.GetComponent<QuestManager>().MaxCount = 10;
            QM.GetComponent<QuestManager>().ObjMFlag = true;
            flag = false;
            QM.GetComponent<QuestManager>().StagyStagtFlag = true;
        }
        GoalCount = 0; // QM.GetComponent<QuestManager>().Player.GetComponent<PlayerScript>().BigTrashC;
    }
}
