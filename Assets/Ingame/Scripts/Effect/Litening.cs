using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Litening : MonoBehaviour
{
    public GameObject LiteningSound;
    public ParticleSystem ItemEffect;
      float timer22 = 0;
    float watime2 = 0.6f;
      bool flag = true;

    // Start is called before the first frame update
    private void Update() {
        shakeObj();
    }
    public void OnCollisionEnter2D(Collision2D other){
        if ((other.gameObject.tag == "Body" || other.gameObject.tag == "Shiled") && other.transform.parent.tag =="Player") {
                other.transform.parent.GetComponent<PlayerScript>().Handlebar(100f);
                var a = Instantiate(ItemEffect, transform.position, Quaternion.Euler(0f, 0f, 0f));
                var KE1 = Instantiate(LiteningSound, transform.position, Quaternion.Euler(0f, 0f, 20f ));
                // 먹히는 소리재생 <- 내가 구현할것,.
            Destroy(gameObject,0.2f);
        }
    }
    void shakeObj(){
        timer22 += Time.deltaTime;
        if(timer22 > watime2){
            flag = !flag;
            timer22 = 0;
        }
         if(flag)
                    transform.Translate(Vector3.up * 0.6f * Time.deltaTime);
                else  transform.Translate(Vector3.down * 0.6f * Time.deltaTime);
    }
}

  
