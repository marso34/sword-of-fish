using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage25 : Stage
{
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
            ShowText();
            GameObject Cam = GameObject.FindGameObjectWithTag("MainCamera");
            QM.GetComponent<QuestManager>().ResetPlayerStat();
            //TutorialName.SetActive(false);
            //GM.GetComponent<GameManager_>().ObjectCleaner();
            QM.GetComponent<QuestManager>().ShapeNum = 1;
            Destroy(GameObject.FindGameObjectWithTag("V"));
            QM.GetComponent<QuestManager>().ResetCounter();
            QM.GetComponent<QuestManager>().ObjectCleanerNextStage();
            QM.GetComponent<QuestManager>().ResetMaxCounter();
            QM.GetComponent<QuestManager>().KnifeEnemyMaxCount = 2;
            QM.GetComponent<QuestManager>().BulletEnemyMaxCount = 0;
            QM.GetComponent<QuestManager>().BulletEC = 1;
            QM.GetComponent<QuestManager>().BossMaxCount = 1;
            QM.GetComponent<QuestManager>().MaxCount = 1;
            flag = false;
            QM.GetComponent<QuestManager>().StagyStagtFlag = true;
            QM.GetComponent<QuestManager>().ObjMFlag = true;
            VEC = Instantiate(QM.GetComponent<QuestManager>().Vectorv, QM.GetComponent<QuestManager>().Player.transform.position, Quaternion.Euler(0, 0, 0));
        }
        // if (VEC.GetComponent<FlowingBigT>().BigT == null)
        // {
        //     if (GameObject.FindWithTag("Kraken") != null)
        //         VEC.GetComponent<FlowingBigT>().setBigT(GameObject.FindWithTag("Kraken"));
        // }
        GoalCount = QM.GetComponent<QuestManager>().Player.GetComponent<PlayerScript>().BosskillScore;
        TrashOn();
    }
    public void ShowText()
    {
        GameObject.FindGameObjectWithTag("ShowText").gameObject.GetComponent<ShowInLevel>().showText("≈∑≈©∑¶¿ª ¿‚æ∆¡‡!");
        GameObject.FindGameObjectWithTag("QB").transform.GetChild(3).GetComponent<ShowQBText>().showText("≈∑≈©∑¶¿ª ¿‚æ∆¡‡!");
    }
}
