using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // Start is called before the first frame update
    bool inflag;
    void Start()
    {
        inflag = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.GetComponent<BigTrash>().Flag == false && inflag)
        {
            transform.parent.parent.GetComponent<Stagy21>().upWall();
           
            inflag = false;
            
        }
    }
}
