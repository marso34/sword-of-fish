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
        TrashFlag = true;
        initHardConst();
    }

    // Update is called once per frame
    void Update()
    {
        if (flag)
        {
           
            ShowText();
            GameObject Cam = GameObject.FindGameObjectWithTag("MainCamera");
            QM.GetComponent<QuestManager>().ResetPlayerStat();
            QM.GetComponent<QuestManager>().ShapeNum = 1;
            Destroy(GameObject.FindGameObjectWithTag("V"));
            //TutorialName.SetActive(false);
            //GM.GetComponent<GameManager_>().ObjectCleaner();
            QM.GetComponent<QuestManager>().ResetMaxCounter();
            QM.GetComponent<QuestManager>().KnifeEnemyMaxCount = 3 + HardConst/2;
            QM.GetComponent<QuestManager>().BulletEnemyMaxCount = 1 + HardConst;
            QM.GetComponent<QuestManager>().MaxCount = 18;// 킬 보드에 표시된 킬스코어 6달성시 클리어
            flag = false;
            QM.GetComponent<QuestManager>().StagyStagtFlag = true;
            QM.GetComponent<QuestManager>().ObjMFlag = true;
            VEC = Instantiate(QM.GetComponent<QuestManager>().Vectorv, QM.GetComponent<QuestManager>().Player.transform.position, Quaternion.Euler(0, 0, 0));
        }
        if (VEC != null && VEC.GetComponent<FlowingBigT>().BigT == null) {
            if (GameObject.FindWithTag("AiPlayer") != null)
                VEC.GetComponent<FlowingBigT>().setBigT(GameObject.FindWithTag("AiPlayer"));
            else if (GameObject.FindWithTag("Attacker") != null)
            {
                VEC.GetComponent<FlowingBigT>().setBigT(GameObject.FindWithTag("Attacker"));
            }
        }
        
        GoalCount = QM.GetComponent<QuestManager>().Player.GetComponent<PlayerScript>().killScore;
        TrashOn();
    }
    public void ShowText()
    {
        GameObject.FindGameObjectWithTag("ShowText").gameObject.GetComponent<ShowInLevel>().showText("적을 전부 섬멸해!");
        GameObject.FindGameObjectWithTag("QB").transform.GetChild(3).GetComponent<ShowQBText>().showText("적을 전부 섬멸해!");
    }
}
