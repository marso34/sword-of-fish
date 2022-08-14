using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer Child0;
    SpriteRenderer Child1;
    SpriteRenderer Child2;
    SpriteRenderer SR;

    Vector3 V;
    Color Alpha;

    float Speed;
    float SizeX;
    float SizeY;
    float Timer;

    void Start()
    {
        Child0 = transform.GetChild(0).GetComponent<SpriteRenderer>();
        Child1 = transform.GetChild(1).GetComponent<SpriteRenderer>();
        Child2 = transform.GetChild(2).GetComponent<SpriteRenderer>();

        Speed = 40f;

        SizeX = transform.localScale.x;
        SizeY = transform.localScale.y;

        if (SizeX < 0)
            V = Vector3.forward;
        else
            V = Vector3.back;

        Alpha = Child0.color;
        Timer = 0f;

        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(V * Speed * Time.deltaTime);

        Timer += Time.deltaTime;
        if (Timer >= 1.5f)
        {
            Speed += Time.deltaTime * 10f;

            SizeX = Mathf.Lerp(SizeX, 0, Time.deltaTime * 0.5f);
            SizeY = Mathf.Lerp(SizeY, 0, Time.deltaTime * 0.5f);
            transform.localScale = new Vector3(SizeX, SizeY, 1f);

            Alpha.a = Mathf.Lerp(Alpha.a, 0, Time.deltaTime * 4f);
            Child0.color = Alpha;
            Child1.color = Alpha;
            Child2.color = Alpha;
        }
    }
}
