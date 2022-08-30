using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage12 : Stage
{
    // Start is called before the first frame update
    void Start()
    {
        GoalCount = 0;
        flag = true;
        QM = GameObject.FindGameObjectWithTag("QM");
        TrashGravity = 0.005f;
        TrashFlag = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (flag)
        {
            initHardConst();
            ShowWaveLevel();
            GameObject Cam = GameObject.FindGameObjectWithTag("MainCamera");
            QM.GetComponent<QuestManager>().ResetPlayerStat();
            QM.GetComponent<QuestManager>().ShapeNum = 1;
            
            //TutorialName.SetActive(false);
            //GM.GetComponent<GameManager_>().ObjectCleaner();

            QM.GetComponent<QuestManager>().ResetMaxCounter();
            QM.GetComponent<QuestManager>().KnifeEnemyMaxCount = 2;
            QM.GetComponent<QuestManager>().BulletEnemyMaxCount = 1;// 총알쏘는 적 1마리 소환
            QM.GetComponent<QuestManager>().MaxCount = 10;//킬 보드에 표시된 킬스코어 4달성시 클리어
            flag = false;
            QM.GetComponent<QuestManager>().StagyStagtFlag = true;
            QM.GetComponent<QuestManager>().ObjMFlag = true;
            TrashOn();
            Destroy(GameObject.FindGameObjectWithTag("V"));
            VEC = Instantiate(QM.GetComponent<QuestManager>().Vectorv, QM.GetComponent<QuestManager>().Player.transform.position, Quaternion.Euler(0, 0, 0));
        }
        if (VEC != null && VEC.GetComponent<FlowingBigT>().BigT == null){
            if (GameObject.FindWithTag("AiPlayer") != null)
                VEC.GetComponent<FlowingBigT>().setBigT(GameObject.FindWithTag("AiPlayer"));
            else if (GameObject.FindWithTag("Attacker") != null)
            {
                VEC.GetComponent<FlowingBigT>().setBigT(GameObject.FindWithTag("Attacker"));
            }
        }
        GoalCount = QM.GetComponent<QuestManager>().Player.GetComponent<PlayerScript>().killScore;
    }
    public void ShowWaveLevel()
    {
        GameObject.FindGameObjectWithTag("ShowText").gameObject.GetComponent<ShowInLevel>().showText("적을 전부 섬멸해!");
        GameObject.FindGameObjectWithTag("QB").transform.GetChild(3).GetComponent<ShowQBText>().showText("적을 전부 섬멸해!");
    }
}
