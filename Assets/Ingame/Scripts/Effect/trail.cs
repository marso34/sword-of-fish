using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trail : MonoBehaviour
{
    bool flag;
    // Start is called before the first frame update
    void Start()
    {
        flag = false;
        // Start
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (transform.parent.parent.localScale.x < 0 && !flag)
        {
            GameObject Temp = transform.parent.gameObject;
            transform.parent = null;           
            transform.localScale = new Vector3(1, 2f, 1);
            transform.parent = Temp.transform;
            transform.localPosition = new Vector3(1.2f, 0f, 1f);
            flag = true;

        }
        else if (transform.parent.parent.localScale.x > 0 && flag)
        {
            GameObject Temp = transform.parent.gameObject;
            
            transform.parent = null;
            transform.localScale = new Vector3(1, 2f, 1);
            transform.parent = Temp.transform;
            transform.localPosition = new Vector3(1.2f, 0f, 1f);
            flag = false;
        }
        */
    }
}
