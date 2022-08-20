using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public GameObject BigTrash;

    Color alpha;
    float alphaSpeed; // 알파값(투명도) 변화 속도

    float Timer;
    float Speed;
    int LEFTorRIGHT;


    void Start()
    {
        BigTrash = GameObject.FindGameObjectWithTag("BigTrash");

        alpha = transform.GetComponent<SpriteRenderer>().color;
        alphaSpeed = 0.4f;

        if (Random.Range(-1f, 1f) >= 0)
            LEFTorRIGHT = 1;
        else LEFTorRIGHT = 0;

        Speed = Random.Range(0.1f, 0.16f);
    }

    void Update()
    {
        Timer += Time.deltaTime;

        if (Timer >= 0.2f)
        {
            LEFTorRIGHT ^= 1;
            Timer = 0f;
        }

        if (BigTrash.GetComponent<BigTrash>().HP <= 0)
        {
            ShakeObj();
            AlphaChange();
        }
    }

    void ShakeObj()
    {
        if (LEFTorRIGHT == 1)
            transform.Translate(Vector3.left * Speed * Time.deltaTime);
        else
            transform.Translate(Vector3.right * Speed * Time.deltaTime);

        transform.Translate(Vector3.down * Speed * 0.6f * Time.deltaTime);
    }

    void AlphaChange()
    {
        alpha.a = Mathf.Lerp(alpha.a, 0, Time.deltaTime * alphaSpeed);
        transform.GetComponent<SpriteRenderer>().color = alpha;
    }
}
