using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class octnife : MonoBehaviour
{
    // Start is called before the
    // Update is called once per frame
    void Update()
    {
        
        
        GetComponent<SpriteRenderer>().color = Color.clear;  
        transform.localScale = new Vector3(0.3f,2,1);
        transform.localPosition = Vector3.zero;  
    }
    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.transform.tag =="Body" && other.transform.parent.tag =="Player"){
            transform.parent.GetComponent<Player>().DieLife();
        }
    }
}
