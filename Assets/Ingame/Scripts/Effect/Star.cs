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
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Body" && other.transform.parent.tag == "Player")
        {
            other.transform.parent.gameObject.GetComponent<Player>().EatStar();

            var a = Instantiate(ItemEffect, transform.position, Quaternion.Euler(0f, 0f, 0f));
            var b = Instantiate(StarSound, transform.position, Quaternion.Euler(0f, 0f, 20f));
            Destroy(gameObject, 0.2f);
        }
    }
}
