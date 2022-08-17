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
    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    

    public void succes(){
        Invoke("upGoal",3f);
    }
    void upGoal(){
        Goal = 1;
    }
}
