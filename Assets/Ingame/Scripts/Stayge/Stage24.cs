using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage24 : Stage
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
            //TutorialName.SetActive(false);
            //GM.GetComponent<GameManager_>().ObjectCleaner();
            Instantiate(QM.GetComponent<QuestManager>().Vectorv, QM.GetComponent<QuestManager>().Player.transform.position, Quaternion.Euler(0, 0, 0));
            QM.GetComponent<QuestManager>().ResetCounter();
            QM.GetComponent<QuestManager>().ObjectCleanerNextStage();
            //?��?????? ???? ??? ?��?????????? ??????????? ???? ?????. ??? ?????? ??????????? ?? ??????? ????
            QM.GetComponent<QuestManager>().ResetMaxCounter();
            QM.GetComponent<QuestManager>().KnifeEnemyMaxCount = 2;
            QM.GetComponent<QuestManager>().BulletEnemyMaxCount = 0;
            QM.GetComponent<QuestManager>().BigTrashMaxCount = 1;
            QM.GetComponent<QuestManager>().MaxCount = 1;// ū������ 1�� �μ��� Ŭ����
            flag = false;
            QM.GetComponent<QuestManager>().StagyStagtFlag = true;
        }
        GoalCount = QM.GetComponent<QuestManager>().Player.GetComponent<PlayerScript>().BigTrashC;
    }
}