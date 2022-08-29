using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage03 : Stage
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
        TrashFlag = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (flag)
        {
            QM.GetComponent<QuestManager>().Player.GetComponent<PlayerScript>().FishNumber = 0;
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
            QM.GetComponent<QuestManager>().KnifeEnemyMaxCount = 0;
            QM.GetComponent<QuestManager>().BulletEnemyMaxCount = 0;
            QM.GetComponent<QuestManager>().BulletEC = 0;
            QM.GetComponent<QuestManager>().BossMaxCount = 0;
            QM.GetComponent<QuestManager>().MaxCount = 1;
            flag = false;
            QM.GetComponent<QuestManager>().StagyStagtFlag = true;
            QM.GetComponent<QuestManager>().ObjMFlag = true;
            VEC = Instantiate(QM.GetComponent<QuestManager>().Vectorv, QM.GetComponent<QuestManager>().Player.transform.position, Quaternion.Euler(0, 0, 0));
        }
        if (VEC != null && VEC.GetComponent<FlowingBigT>().BigT == null)
        {
            if (GameObject.FindWithTag("Trush") != null)
                VEC.GetComponent<FlowingBigT>().setBigT(GameObject.FindWithTag("Trush"));
        }
        if (QM.GetComponent<QuestManager>().Player.GetComponent<PlayerScript>().UseItem_ == true)
        {
            GoalCount = 1;
            QM.GetComponent<QuestManager>().Player.GetComponent<PlayerScript>().UseItem_ = false;
        }
        TrashOn();
    }

    public void ShowText()
    {
        GameObject.FindGameObjectWithTag("ShowText").gameObject.GetComponent<ShowInLevel>().showText("쓰레기를 부수고, 아이템버튼을 눌러줘");
        GameObject.FindGameObjectWithTag("QB").transform.GetChild(3).GetComponent<ShowQBText>().showText("");
    }
}
