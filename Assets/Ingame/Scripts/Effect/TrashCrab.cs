using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCrab : MonoBehaviour
{
    public GameObject Eye;
    public Sprite[] Img;
    public int HP;

    float Timer;
    int Num;

    void Start()
    {
        Num = 0;
    }

    void Update()
    {
        HP = transform.GetComponent<BigTrash>().HP;

        if (HP <= 0 && Num < 4)
        {
            Timer += Time.deltaTime;

            if (Timer >= 0.2f)
            {
                Eye.transform.GetComponent<SpriteRenderer>().sprite = Img[Num];
                Num++;
                Timer = 0f;
            }
        }
    }
}