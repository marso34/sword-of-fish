using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lv3Open : Open
{
    public GameObject Fish;

    void Start()
    {
        GetQM();
    }

    // Update is called once per frame
    void Update()
    {
        if (QM.GetComponent<QuestManager>().Level_ >= 3 && flag)
        {
            if (Fish != null)
                Fish.GetComponent<Animator>().enabled = true;
            flag = false;
            Destroy(gameObject);
        }
    }
}
