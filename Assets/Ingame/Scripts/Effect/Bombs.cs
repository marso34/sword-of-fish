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

    public bool Active = false; // true면 설치용 폭탄, false면 폭탄 아이템
    float timer = 0f;
    float timer_ = 0f;
    float timer22 = 0;
    float watime2 = 0.6f;
    bool flag = true;
    int c = 0;

    void shakeObj() // 위아래 움직임
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
            transform.GetChild(0).gameObject.SetActive(false); // 배리어 이미지(GetChild(0)) 지우고
            timer += Time.deltaTime;
            timer_ += Time.deltaTime;

            if (timer >= 0.3f) // 0.3초 간격으로 붉은색 깜빡임
            {
                timer = 0f;
                c ^= 1;
            }

            GetComponent<SpriteRenderer>().color = (c == 0) ? Color.white : Color.red; // c가 0이면 기본색, 1이면 붉은색

            if (timer_ >= 1f)
            {
                var KE1 = Instantiate(BombSound, transform.position, Quaternion.Euler(0f, 0f, 20f)); // 폭발 소리
                var a = Instantiate(Explosion, transform.position, Quaternion.Euler(0f, 0f, 0f)); // 폭발 이펙트
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

            var a = Instantiate(ItemEffect, transform.position, Quaternion.Euler(0f, 0f, 0f)); // 아이템 먹는 이펙트
            var KE1 = Instantiate(BombSound2, transform.position, Quaternion.Euler(0f, 0f, 20f)); // 아이템 먹는 소리
            Destroy(gameObject, 0.2f);
        }
    }
}