using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage11 : Stage
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
            Debug.Log("스테이지 정의!");
            QM.GetComponent<QuestManager>().ResetPlayerStat();
            QM.GetComponent<QuestManager>().ShapeNum = 1;
            //TutorialName.SetActive(false);
            //GM.GetComponent<GameManager_>().ObjectCleaner();
            QM.GetComponent<QuestManager>().ResetMaxCounter();// 모든 맥스카운터 0으로 초기화
            QM.GetComponent<QuestManager>().ResetCounter();// 모든 현재 존재하는 오브젝트 카운트한거 0으로 다 초기화
            QM.GetComponent<QuestManager>().KnifeEnemyMaxCount = 2;// 칼든 적물고기 최대 4마리소환
            QM.GetComponent<QuestManager>().MaxCount = 4;// 킬 보드에 표시된 킬스코어 2달성시 클리어
            QM.GetComponent<QuestManager>().Player.transform.localPosition = Vector3.zero;
            flag = false;
            QM.GetComponent<QuestManager>().StagyStagtFlag = true;
             QM.GetComponent<QuestManager>().ObjMFlag = false;
        }
        GoalCount = QM.GetComponent<QuestManager>().Player.GetComponent<PlayerScript>().killScore;
    }
}
