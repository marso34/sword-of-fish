using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage15 : Stage
{
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
            //VEC = Instantiate(QM.GetComponent<QuestManager>().Vectorv, QM.GetComponent<QuestManager>().Player.transform.position, Quaternion.Euler(0, 0, 0));
            //if(GameObject.FindWithTag("BTP")!= null);
            //VEC.GetComponent<FlowingBigT>().setBigT(GameObject.FindWithTag("BTP"));
            QM.GetComponent<QuestManager>().ResetCounter();
            QM.GetComponent<QuestManager>().ObjectCleanerNextStage();
            QM.GetComponent<QuestManager>().ResetMaxCounter();
            QM.GetComponent<QuestManager>().KnifeEnemyMaxCount = 2 + HardConst;
            QM.GetComponent<QuestManager>().BulletEnemyMaxCount = 2 + HardConst;
            QM.GetComponent<QuestManager>().BigTrashMaxCount = 1;
            QM.GetComponent<QuestManager>().MaxCount = 1;// 큰쓰레기 1개 부술시 클리어
            flag = false;
            QM.GetComponent<QuestManager>().StagyStagtFlag = true;
             QM.GetComponent<QuestManager>().ObjMFlag = true;
            QM.GetComponent<QuestManager>().Player.transform.position = Vector3.zero;
            VEC = Instantiate(QM.GetComponent<QuestManager>().Vectorv, QM.GetComponent<QuestManager>().Player.transform.position, Quaternion.Euler(0, 0, 0));
        }
        if (VEC != null && VEC.GetComponent<FlowingBigT>().BigT == null)
        {
            if (GameObject.FindWithTag("BTK") != null)
            {
                VEC.GetComponent<FlowingBigT>().setBigT(GameObject.FindWithTag("BTK"));
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
