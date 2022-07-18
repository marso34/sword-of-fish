using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeEffast : MonoBehaviour
{
    GameObject GM;
    Color C;
    float time;
    float Watingtime;
    float firstWatingTime;
    bool flag;
    // Start is called before the first frame update

    public void Start()//일반적인 스타트 (코루틴) 반복문임.)
    {
        GM = GameObject.FindGameObjectWithTag("GM");
        firstWatingTime = 0.1f;
        C = transform.GetComponent<SpriteRenderer>().color;
        time = 0;
        Watingtime = 0.003f;
        flag = false;
        Invoke("Defult_", 2f);
    }

    private void Update()
    {
        if (GM.GetComponent<GameManager_>().resetFlag) Destroy(gameObject);
        if (!flag)
        {
            time += Time.deltaTime;
            if (time > firstWatingTime)
            {
                flag = true;
                time = 0;
            }
        }

        if (flag)
        {
            time += Time.deltaTime;
            if (time > Watingtime)
            {
                C.a -= 0.1f;
                transform.GetComponent<SpriteRenderer>().color = C;
                time = 0;
            }
        }

    }
    public void Defult_()
    {
        Destroy(gameObject);
    }



}
