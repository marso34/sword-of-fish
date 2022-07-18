using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrash : MonoBehaviour
{
    float timer22 = 0;
    float watime2 = 1f;
    float timer33 = 0;
    float watime3 = 5f;
    float timer44 = 0;
    float watime4 = 4f;
    bool dirflag = true;
    bool flag = true;
    float rota;
    float Speed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        shakeObj();
    }

    void shakeObj()
    {
        Speed = Random.Range(0.05f, 0.12f);
        timer22 += Time.deltaTime;
        if (timer22 > watime2)
        {
            flag = !flag;
            timer22 = 0;
            watime2 = Random.Range(0.8f, 1.2f);
        }
        timer33 += Time.deltaTime;
        if (timer33 > watime3)
        {
            dirflag = !dirflag;
            timer33 = 0;
            watime3 = Random.Range(0.8f, 1.2f);
            rota = Random.Range(10f, 15f);
        }
        timer44 += Time.deltaTime;
        if (timer44 > watime4)
        {
            flag = !flag;
            timer44 = 0;
            watime4 = Random.Range(0.8f, 1.2f);
        }

        if (dirflag)
        {
            transform.Translate(Vector3.left * Speed * Time.deltaTime);
            transform.Rotate(Vector3.forward * rota * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.right * Speed * Time.deltaTime);
            transform.Rotate(Vector3.back * rota * Time.deltaTime);
        }
        if (flag)
        {
            transform.Translate(Vector3.up * Speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.down * Speed * Time.deltaTime);
        }
    }
}
