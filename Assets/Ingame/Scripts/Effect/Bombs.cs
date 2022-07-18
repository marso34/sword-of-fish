using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombs : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject BombSound;
    public GameObject BombSound2;
    public ParticleSystem ItemEffect;
    public ParticleSystem Explosion;

    public bool Active = false;
    float timer = 0f;
    float timer_ = 0f;
    float timer22 = 0;
    float watime2 = 0.6f;
    bool flag = true;
    int c = 0;

    void shakeObj()
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

    private void Update()
    {
        if (Active)
        {

            transform.GetChild(0).gameObject.SetActive(false);
            timer += Time.deltaTime;
            timer_ += Time.deltaTime;

            if (timer >= 0.3f) // ±ôºýÀÓ
            {
                timer = 0f;
                c ^= 1;
            }

            GetComponent<SpriteRenderer>().color = (c == 0) ? Color.white : Color.red;

            if (timer_ >= 1f)
            {
                var KE1 = Instantiate(BombSound, transform.position, Quaternion.Euler(0f, 0f, 20f)); // Æø¹ß ¼Ò¸®
                var a = Instantiate(Explosion, transform.position, Quaternion.Euler(0f, 0f, 0f));
                Destroy(gameObject);
            }
        }
        else
            shakeObj();
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (!Active && (other.gameObject.tag == "Body" || other.gameObject.tag == "Shiled") && other.transform.parent.tag == "Player")
        {
            other.transform.parent.gameObject.GetComponent<PlayerScript>().EatItem(1);

            var a = Instantiate(ItemEffect, transform.position, Quaternion.Euler(0f, 0f, 0f));
            // ?????? ?????? <- ???? ???????,.
            var KE1 = Instantiate(BombSound2, transform.position, Quaternion.Euler(0f, 0f, 20f)); // ¾ÆÀÌÅÛ ¸Ô´Â ¼Ò¸®
            Destroy(gameObject, 0.2f);
        }
    }
}