using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stagy7 : MonoBehaviour
{
    public GameObject Trush;
    public GameObject Trush2;
    void Start()
    {
        for(int i=0; i < 5; ++i)
        {
            Vector3 RP = new Vector3(Random.Range(-13, 13), Random.Range(-8, 8), 0);
            Instantiate(Trush, RP,Quaternion.Euler(0,0,0));
        }
        for (int i = 0; i < 5; ++i)
        {
            Vector3 RP = new Vector3(Random.Range(-13, 13), Random.Range(-8, 8), 0);
            Instantiate(Trush2, RP, Quaternion.Euler(0, 0, 0));
        }
    }

    
   
}
