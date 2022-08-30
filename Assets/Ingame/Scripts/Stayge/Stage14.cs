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
            QM.GetComponent<QuestManager>().ObjectCleanerNextStage();
            GameObject Cam = GameObject.FindGameObjectWithTag("MainCamera");
            //보스 보여주고 플레이하는 캠액션, UI다끄고 카메라 방향 보스향했다가 다시 플레이어로 오고 UI다키고.
            QM.GetComponent<QuestManager>().ResetPlayerStat();
            QM.GetComponent<QuestManager>().ShapeNum = 1;
            Destroy(GameObject.FindGameObjectWithTag("V"));
            //TutorialName.SetActive(false);
            //GM.GetComponent<GameManager_>().ObjectCleaner();

            QM.GetComponent<QuestManager>().ResetMaxCounter();
            QM.GetComponent<QuestManager>().ResetCounter();
            QM.GetComponent<QuestManager>().BossMaxCount = 1;
            QM.GetComponent<QuestManager>().MaxCount = 1; // 보스 한명 잡을시 클리어
            flag = false;
            QM.GetComponent<QuestManager>().StagyStagtFlag = true;
            QM.GetComponent<QuestManager>().ObjMFlag = true;
            VEC = Instantiate(QM.GetComponent<QuestManager>().Vectorv, QM.GetComponent<QuestManager>().Player.transform.position, Quaternion.Euler(0, 0, 0));
        }
        if (VEC != null && VEC.GetComponent<FlowingBigT>().BigT == null)
        {
            if (GameObject.FindWithTag("Attacker") != null)
            {
                VEC.GetComponent<FlowingBigT>().setBigT(GameObject.FindWithTag("Attacker"));
            }
        }
        GoalCount = QM.GetComponent<QuestManager>().Player.GetComponent<PlayerScript>().BosskillScore;
        TrashOn();
    }
    public void ShowText()
    {
        GameObject.FindGameObjectWithTag("ShowText").gameObject.GetComponent<ShowInLevel>().showText("보거를 잡아줘!");
        GameObject.FindGameObjectWithTag("QB").transform.GetChild(3).GetComponent<ShowQBText>().showText("보거를 잡아줘!");
    }
}
