using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lv2Open : Open
{
    // Start is called before the first frame update
    public GameObject Fish;


    void Start()
    {
        GetQM();
    }

    void Update()
    {
        if (QM.GetComponent<QuestManager>().Level_ >= 2 && flag)
        {
            if (Fish != null)
                Fish.GetComponent<Animator>().enabled = true;
            flag = false;
            Destroy(gameObject);
        }
    }
}
