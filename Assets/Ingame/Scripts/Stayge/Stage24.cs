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
        TrashGravity = 0.1f;
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
            Cam.transform.position = new Vector3(0, 0, Cam.transform.position.z);
            QM.GetComponent<QuestManager>().ResetPlayerStat();
            QM.GetComponent<QuestManager>().ShapeNum = 1;
            //TutorialName.SetActive(false);
            //GM.GetComponent<GameManager_>().ObjectCleaner();
            Destroy(GameObject.FindGameObjectWithTag("V"));
            VEC = Instantiate(QM.GetComponent<QuestManager>().Vectorv, QM.GetComponent<QuestManager>().Player.transform.position, Quaternion.Euler(0, 0, 0));
            if (GameObject.FindWithTag("BTP") != null) ;
            VEC.GetComponent<FlowingBigT>().setBigT(GameObject.FindWithTag("BTP"));
            QM.GetComponent<QuestManager>().ResetCounter();
            QM.GetComponent<QuestManager>().ObjectCleanerNextStage();
            //?÷?????? ???? ??? ?÷?????????? ??????????? ???? ?????. ??? ?????? ??????????? ?? ??????? ????
            QM.GetComponent<QuestManager>().ResetMaxCounter();
            QM.GetComponent<QuestManager>().KnifeEnemyMaxCount = 2 + HardConst;
            QM.GetComponent<QuestManager>().BulletEnemyMaxCount = 0 + HardConst;
            QM.GetComponent<QuestManager>().BigTrashMaxCount = 1;
            QM.GetComponent<QuestManager>().Player.GetComponent<PlayerScript>().BigTrashC = 0;
            QM.GetComponent<QuestManager>().MaxCount = 1;// 큰쓰레기 1개 부술시 클리어
            QM.GetComponent<QuestManager>().ObjMFlag = false;
            flag = false;
            QM.GetComponent<QuestManager>().StagyStagtFlag = true;
            QM.GetComponent<QuestManager>().ObjMFlag = true;
            QM.GetComponent<QuestManager>().Player.transform.position = Vector3.zero;
        }
        if (VEC != null && VEC.GetComponent<FlowingBigT>().BigT == null)
        {
            if (GameObject.FindWithTag("BTP") != null)
            {
                VEC.GetComponent<FlowingBigT>().setBigT(GameObject.FindWithTag("BTP"));
            }
        }
        GoalCount = QM.GetComponent<QuestManager>().Player.GetComponent<PlayerScript>().BigTrashC;
        TrashOn();
    }
    public void ShowText()
    {
        GameObject.FindGameObjectWithTag("ShowText").gameObject.GetComponent<ShowInLevel>().showText("쓰레기 더미를 부셔줘!");
        GameObject.FindGameObjectWithTag("QB").transform.GetChild(3).GetComponent<ShowQBText>().showText("쓰레기 더미를 부셔줘!");
    }
}
