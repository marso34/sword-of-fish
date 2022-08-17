using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitKraken : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D other) {
        if((transform.parent.tag !="BossSkillA" && other.transform.tag =="Knife" && other.transform.parent.tag =="Player")){
            Debug.Log("PLAYER");
            transform.parent.GetComponent<Tentacle>().DestroyTentacle(other.gameObject);
            
        }
    }
    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
         if(other.transform.tag == "EXPL"){
            transform.parent.GetComponent<Tentacle>().HitEXPL_(other.gameObject);
        }
        if(other.transform.tag =="FRZ"){
             transform.parent.GetComponent<Tentacle>().HitFRZ();
        }
    }
}
