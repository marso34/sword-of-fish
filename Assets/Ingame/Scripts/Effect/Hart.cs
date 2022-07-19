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
    public void OnCollisionEnter2D(Collision2D other)
    {
        if ((other.gameObject.tag == "Body" || other.gameObject.tag == "Shiled") && other.transform.parent.tag == "Player")
        {
            if (other.transform.parent.GetComponent<Player>().HP > 0 && other.transform.parent.GetComponent<Player>().HP < 5)
                other.transform.parent.GetComponent<Player>().HP++;

            var a = Instantiate(ItemEffect, transform.position, Quaternion.Euler(0f, 0f, 0f));
            var b = Instantiate(HartSound, transform.position, Quaternion.Euler(0f, 0f, 20f));
            Destroy(gameObject, 0.2f);
        }
    }
}


