using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : Item
{
    public GameObject StarSound;

    private void Update()
    {
        shakeObj();
    }
    public override void eatItem(GameObject T)
    {
        T.transform.gameObject.GetComponent<PlayerScript>().EatStar();
        var a = Instantiate(ItemEffect, transform.position, Quaternion.Euler(0f, 0f, 0f));
        var b = Instantiate(StarSound, transform.position, Quaternion.Euler(0f, 0f, 20f));
        Destroy(gameObject);
    }
   
}
