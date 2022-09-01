using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lv1Open : Open
{
    // Start is called before the first frame update
    void Start()
    {
        GetQM();
    }

    // Update is called once per frame
    void Update()
    {
        if(QM.GetComponent<QuestManager>().Level_ >=1 && flag) {
            flag = false;
            Destroy(gameObject);    
        } 
    }
}
