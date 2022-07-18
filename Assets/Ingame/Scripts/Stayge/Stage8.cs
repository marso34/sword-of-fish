using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage8 : MonoBehaviour
{
    public float time_;
    public float waitTime = 1;
    public GameObject QM;
    private void Start()
    {
        QM = GameObject.FindGameObjectWithTag("QM");
    }
    private void Update()
    {
        /*
        if (QM.GetComponent<QuestManager>().Players[0] !=null&&QM.GetComponent<QuestManager>().Players[0].GetComponent<Player>().Flag_get)
        {
            time_ += Time.deltaTime;
            if (time_ > waitTime)
            {
                time_ = 0;
                QM.GetComponent<QuestManager>().OccupationTime++;
            }
        }*/
    }
}
