using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage00 : Stage
{
    void Start()
    {
        GoalCount = 0;
        flag = true;
        QM = GameObject.FindGameObjectWithTag("QM");
        GM = GameObject.FindGameObjectWithTag("GM");
    }

    void Update()
    {
        if (flag)
        {
            GM.GetComponent<GameManager_>().StartCutScene();
            flag = false;
        }

        
    }
}
