using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public GameObject StarSound;
    public ParticleSystem ItemEffect;
    float timer22 = 0;
    float watime2 = 0.6f;
    bool flag = true;

    // Start is called before the first frame update
    private void Update()
    {
        shakeObj();
    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Body" && other.transform.parent.tag == "Player")
        {
            other.transform.parent.gameObject.GetComponent<Player>().EatStar();

            // 여기에 플레이어 반짝이게 만드는 값을 넘겨주던, 함수를실행시키던 등등 하기. 자율적으로.
            // 먹히는 소리재생 <- 내가 구현할것,.
            var a = Instantiate(ItemEffect, transform.position, Quaternion.Euler(0f, 0f, 0f));
            var KE1 = Instantiate(StarSound, transform.position, Quaternion.Euler(0f, 0f, 20f));
            Destroy(gameObject, 0.2f);
        }
    }
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
}
