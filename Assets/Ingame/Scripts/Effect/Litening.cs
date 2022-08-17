using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Litening : Item
{
    public GameObject LiteningSound;

    private void Update()
    {
        shakeObj();
    }
    public override void eatItem(GameObject T)
    {
        T.transform.GetComponent<PlayerScript>().Handlebar(100f);
        var a = Instantiate(ItemEffect, transform.position, Quaternion.Euler(0f, 0f, 0f));
        var b = Instantiate(LiteningSound, transform.position, Quaternion.Euler(0f, 0f, 20f));
        Destroy(gameObject, 0.2f);
    }
}


