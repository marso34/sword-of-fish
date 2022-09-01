using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject QM;
    public bool flag;
    public void GetQM(){
        QM = GameObject.FindGameObjectWithTag("QM");
        flag = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
