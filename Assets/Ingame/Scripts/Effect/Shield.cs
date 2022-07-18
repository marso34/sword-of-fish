using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ShieldSound;
    public ParticleSystem ItemEffect;
    float timer22 = 0;
    float watime2 = 0.6f;
    bool flag = true;

    private void Update()
    {
        timer22 += Time.deltaTime;
        if (timer22 > watime2)
        {
            flag = !flag;
            timer22 = 0;
        }
        if (flag)
            transform.Translate(Vector3.up * 0.6f * Time.deltaTime);
        else transform.Translate(Vector3.down * 0.6f * Time.deltaTime);
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if ((other.gameObject.tag == "Body" || other.gameObject.tag == "Shiled") && other.transform.parent.tag == "Player")
        {
            other.transform.parent.gameObject.GetComponent<PlayerScript>().EatItem(3);

            var a = Instantiate(ItemEffect, transform.position, Quaternion.Euler(0f, 0f, 0f));
            // 먹히는 소리재생 <- 내가 구현할것,.
             var KE1 = Instantiate(ShieldSound, transform.position, Quaternion.Euler(0f, 0f, 20f));
            Destroy(gameObject, 0.2f);
        }
    }
}
