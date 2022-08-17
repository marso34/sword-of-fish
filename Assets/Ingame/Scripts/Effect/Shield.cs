using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : Item
{
    public GameObject ShieldSound;

    private void Update()
    {
        shakeObj();
    }
    
    public override void eatItem(GameObject T)
    {
        T.transform.gameObject.GetComponent<PlayerScript>().EatItem(3);
        var a = Instantiate(ItemEffect, transform.position, Quaternion.Euler(0f, 0f, 0f));
        var b = Instantiate(ShieldSound, transform.position, Quaternion.Euler(0f, 0f, 20f));
        Destroy(gameObject, 0.2f);
    }
}
