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
    }

    // Update is called once per frame
    void Update()
    {
        if (flag)
        {
            QM.GetComponent<QuestManager>().ResetPlayerStat();
            QM.GetComponent<QuestManager>().ShapeNum = 1;

            //TutorialName.SetActive(false);
            //GM.GetComponent<GameManager_>().ObjectCleaner();

            QM.GetComponent<QuestManager>().ResetMaxCounter();
            QM.GetComponent<QuestManager>().KnifeEnemyMaxCount = 6;
            QM.GetComponent<QuestManager>().BulletEnemyMaxCount = 1;// �Ѿ˽�� �� 1���� ��ȯ
            QM.GetComponent<QuestManager>().MaxCount = 13;//ų ���忡 ǥ�õ� ų���ھ� 4�޼��� Ŭ����
            flag = false;
            QM.GetComponent<QuestManager>().StagyStagtFlag = true;
        }
        GoalCount = QM.GetComponent<QuestManager>().Player.GetComponent<PlayerScript>().killScore;
    }
}