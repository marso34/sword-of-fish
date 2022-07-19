using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ParticleSystem ItemEffect;
    public GameObject Sound;

    float timer = 0;
    float watime = 0.6f;
    bool flag = true;
    
    public void shakeObj()  // 위아래 움직임
    {
        timer += Time.deltaTime;

        if (timer > watime)
        {
            flag = !flag;
            timer = 0;
        }

        if (flag)   transform.Translate(Vector3.up * 0.6f * Time.deltaTime);
        else        transform.Translate(Vector3.down * 0.6f * Time.deltaTime);
    }
}
