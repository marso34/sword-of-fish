using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitKraken : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D other) {
        if((transform.parent.tag !="BossSkillA" && other.transform.tag =="Knife" && other.transform.parent.tag =="Player") || other.transform.tag == "EXPL" ){
            Debug.Log("PLAYER");
            transform.parent.GetComponent<Tentacle>().DestroyTentacle(other.gameObject);
        }
    }
}
