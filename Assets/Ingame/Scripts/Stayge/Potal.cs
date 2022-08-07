using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potal : MonoBehaviour
{
    // Start is called before the first frame update
    public int Goal;
    void Start()
    {
       Goal = 0;
    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Body" && other.transform.parent.tag == "Player")
        {
            Debug.Log("¼º°ø");
            Invoke("succes",3f);
        }
    }
    void succes(){
        Goal = 1;
    }
}
