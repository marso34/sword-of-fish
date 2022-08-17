using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombs : Item
{
    // Start is called before the first frame update
    public GameObject BombSound;
    public GameObject BombSound2;
    public ParticleSystem Explosion;

    public bool Active = false; // true면 설치용 폭탄, false면 폭탄 아이템
    float ColorTimer = 0f; // 색변경 타이머
    float timer_ = 0f; // 폭탄 설치 생존 시간
    int c = 0;

    private void Update()
    {
        if (Active)
        {
            transform.GetChild(0).gameObject.SetActive(false); // 배리어 이미지(GetChild(0)) 지우고
            ColorTimer += Time.deltaTime;
            timer_ += Time.deltaTime;

            if (ColorTimer >= 0.3f) // 0.3초 간격으로 붉은색 깜빡임
            {
                ColorTimer = 0f;
                c ^= 1;
            }

            GetComponent<SpriteRenderer>().color = (c == 0) ? Color.white : Color.red; // c가 0이면 기본색, 1이면 붉은색

            if (timer_ >= 1f)
            {
                var KE1 = Instantiate(BombSound, transform.position, Quaternion.Euler(0f, 0f, 20f)); // 폭발 소리
                var a = Instantiate(Explosion, transform.position, Quaternion.Euler(0f, 0f, 0f)); // 폭발 이펙트
                a.transform.localScale = transform.localScale;
                Destroy(gameObject);
            }
        }
        else
            shakeObj();
    }

    public override void eatItem(GameObject T)
    {
        if (!Active)
        {
            T.transform.gameObject.GetComponent<PlayerScript>().EatItem(1);

            var a = Instantiate(ItemEffect, transform.position, Quaternion.Euler(0f, 0f, 0f)); // 아이템 먹는 이펙트
            var b = Instantiate(BombSound2, transform.position, Quaternion.Euler(0f, 0f, 0f));
            Destroy(gameObject);
        }
    }
}