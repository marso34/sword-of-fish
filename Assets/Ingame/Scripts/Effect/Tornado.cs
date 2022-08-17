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

    float SignedX;
    float Speed;
    float SizeX;
    float SizeY;

    public float Timer;

    void Start()
    {
        Child0 = transform.GetChild(0).GetComponent<SpriteRenderer>();
        Child1 = transform.GetChild(1).GetComponent<SpriteRenderer>();
        Child2 = transform.GetChild(2).GetComponent<SpriteRenderer>();

        Speed = 40f;

        SignedX = transform.localScale.x; // x의 부호
        SizeX = transform.localScale.x * 0.3f;
        SizeY = transform.localScale.y * 0.3f;

        if (SignedX < 0)
            V = Vector3.forward;
        else
            V = Vector3.back;

        Alpha = Child0.color;
        Timer = 0f;

        transform.tag = "Tornado";

        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(V * Speed * Time.deltaTime);

        Timer += Time.deltaTime;
        if (Timer <= 0.5f)
        {
            SizeX = Mathf.Lerp(SizeX, SignedX * 1.5f, Time.deltaTime * 2f);
            SizeY = Mathf.Lerp(SizeY, 1.5f, Time.deltaTime * 2f);
            transform.localScale = new Vector3(SizeX, SizeY, 1f);
        }
        else if (Timer >= 1.5f)
        {
            Speed += Time.deltaTime * 100f;

            SizeX = Mathf.Lerp(SizeX, 0, Time.deltaTime * 0.5f);
            SizeY = Mathf.Lerp(SizeY, 0, Time.deltaTime * 0.5f);
            transform.localScale = new Vector3(SizeX, SizeY, 1f);

            Alpha.a = Mathf.Lerp(Alpha.a, 0, Time.deltaTime * 4f);
            Child0.color = Alpha;
            Child1.color = Alpha;
            Child2.color = Alpha;
        }
    }

    public void OnCollisionStay2D(Collision2D other)
    {
        if (transform.gameObject.tag == "SkillP" &&  other.gameObject.tag == "Body" && other.transform.parent.tag == "Player" && Timer <= 2f)
        {
            Debug.Log("퍼플피쉬 스킬 접촉");
            other.transform.parent.gameObject.GetComponent<PlayerScript>().RB.velocity = (transform.position - other.gameObject.transform.parent.position).normalized * Random.Range(0.01f, 0.11f);
        }
    }
}