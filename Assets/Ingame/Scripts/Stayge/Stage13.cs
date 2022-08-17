using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage13 : Stage
{
    // Start is called before the first frame update
    void Start()
    {
        GoalCount = 0;
        flag = true;
        QM = GameObject.FindGameObjectWithTag("QM");
        TrashGravity = 0.005f;
    }

    // Update is called once per frame
    void Update()
    {
        if (flag)
        {
            GameObject Cam = GameObject.FindGameObjectWithTag("MainCamera");
            Cam.transform.position = new Vector3(0,0,Cam.transform.position.z);
            QM.GetComponent<QuestManager>().ResetPlayerStat();
            QM.GetComponent<QuestManager>().ShapeNum = 1;
            //TutorialName.SetActive(false);
            //GM.GetComponent<GameManager_>().ObjectCleaner();
            QM.GetComponent<QuestManager>().ResetMaxCounter();
            QM.GetComponent<QuestManager>().KnifeEnemyMaxCount = 2;
            QM.GetComponent<QuestManager>().BulletEnemyMaxCount = 1;
            QM.GetComponent<QuestManager>().MaxCount = 18;// 킬 보드에 표시된 킬스코어 6달성시 클리어
            flag = false;
            QM.GetComponent<QuestManager>().StagyStagtFlag = true;
             QM.GetComponent<QuestManager>().ObjMFlag = true;
        }
        GoalCount = QM.GetComponent<QuestManager>().Player.GetComponent<PlayerScript>().killScore;
        TrashOn();
    }
}
