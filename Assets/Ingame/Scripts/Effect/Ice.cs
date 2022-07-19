using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : Item
{
    public GameObject IceEatSound;

    private void Update()
    {
        shakeObj();
    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        if ((other.gameObject.tag == "Body" || other.gameObject.tag == "Shiled") && other.transform.parent.tag == "Player")
        {
            other.transform.parent.gameObject.GetComponent<PlayerScript>().EatItem(2);

            var a = Instantiate(ItemEffect, transform.position, Quaternion.Euler(0f, 0f, 0f)); // æ∆¿Ã≈€ ∏‘¥¬ ¿Ã∆Â∆Æ
            var b = Instantiate(IceEatSound, transform.position, Quaternion.Euler(0f, 0f, 0f));
            Destroy(gameObject, 0.2f);
        }
    }
}
