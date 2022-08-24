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
        TrashFlag = true;
        TrashGravity = 0.005f;
    }

    // Update is called once per frame
    void Update()
    {
        if (flag)
        {
            ShowText();
            GameObject Cam = GameObject.FindGameObjectWithTag("MainCamera");
            Cam.transform.position = new Vector3(0, 0, Cam.transform.position.z);
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
            QM.GetComponent<QuestManager>().ObjMFlag = true;
            VEC = Instantiate(QM.GetComponent<QuestManager>().Vectorv, QM.GetComponent<QuestManager>().Player.transform.position, Quaternion.Euler(0, 0, 0));
        }
        if (VEC.GetComponent<FlowingBigT>().BigT == null)
        {
            if (GameObject.FindWithTag("AiPlayer") != null)
                VEC.GetComponent<FlowingBigT>().setBigT(GameObject.FindWithTag("AiPlayer"));
                else if(GameObject.FindWithTag("Attacker") != null){
                    VEC.GetComponent<FlowingBigT>().setBigT(GameObject.FindWithTag("Attacker"));
                }
        }
        TrashOn();
        GoalCount = QM.GetComponent<QuestManager>().Player.GetComponent<PlayerScript>().killScore;
    }


    public void ShowText()
    {
        GameObject.FindGameObjectWithTag("ShowText").gameObject.GetComponent<ShowInLevel>().showText("적을 전부 섬멸해!");
        GameObject.FindGameObjectWithTag("QB").transform.GetChild(3).GetComponent<ShowQBText>().showText("적을 전부 섬멸해!");
    }
}

