using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lv4Open : Open
{
    public GameObject Fish;
    void Start()
    {
        GetQM();
    }

    // Update is called once per frame
    void Update()
    {
        if (QM.GetComponent<QuestManager>().Level_ >= 4 && flag)
        {
            if (Fish != null)
                Fish.GetComponent<Animator>().enabled = true;
            flag = false;
            Destroy(gameObject);
        }
    }
}
