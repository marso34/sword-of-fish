using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashRotate : MonoBehaviour
{
    // Start is called before the first frame update
    float timer22 = 0;
    float watime2 = 1f;
    float timer33 = 0;
    float watime3 = 5f;
    float timer44 = 0;
    float watime4 = 4f;
    bool roateDirflag = true;
    bool flag = true;
    float rota;
    float Speed = 0.1f;
    Vector3 roateDir;

    // Update is called once per frame
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        float roateDirX = Random.Range(-0.9f, 0.9f);
        float roateDirY = Random.Range(-0.9f, 0.9f);
        roateDir = new Vector3(roateDirX, roateDirY, 0);
        Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, roateDir.normalized); //랜덤방향에 맞게 정면을 보도록 회전값 받아오기.
        transform.localRotation = toRotation;

    }
    void Update()
    {
        if (!transform.parent.GetComponent<Trush>().FRZFlag)
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
            roateDirflag = !roateDirflag;
            timer33 = 0;
            watime3 = Random.Range(0.8f, 1.2f);
            rota = Random.Range(10f, 50f);
        }
        timer44 += Time.deltaTime;
        if (timer44 > watime4)
        {
            flag = !flag;
            timer44 = 0;
            watime4 = Random.Range(0.8f, 1.2f);
        }

        if (roateDirflag)
        {
            transform.transform.Rotate(Vector3.forward * rota * Time.deltaTime);
        }
        else
        {
            transform.transform.Rotate(Vector3.back * rota * Time.deltaTime);
        }

    }
}
