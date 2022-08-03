using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage14 : Stage
{
    // Start is called before the first frame update
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
            QM.GetComponent<QuestManager>().ObjectCleanerNextStage();
            QM.GetComponent<QuestManager>().ResetMaxCounter();
            QM.GetComponent<QuestManager>().ResetCounter();
            QM.GetComponent<QuestManager>().BossMaxCount = 1;
            QM.GetComponent<QuestManager>().MaxCount = 1; // 보스 한명 잡을시 클리어
            flag = false;
            QM.GetComponent<QuestManager>().StagyStagtFlag = true;
        }
        GoalCount = QM.GetComponent<QuestManager>().Player.GetComponent<PlayerScript>().BosskillScore;
    }
}
