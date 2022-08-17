using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hart : Item
{
    public GameObject HartSound;

    private void Update()
    {
        shakeObj();
    }
   
     public override void eatItem(GameObject T){
         if (T.transform.GetComponent<Player>().HP > 0 && T.transform.GetComponent<Player>().HP < 5)
                T.transform.GetComponent<Player>().HP++;

            var a = Instantiate(ItemEffect, transform.position, Quaternion.Euler(0f, 0f, 0f));
            var b = Instantiate(HartSound, transform.position, Quaternion.Euler(0f, 0f, 20f));
            Destroy(gameObject);
    }
}


