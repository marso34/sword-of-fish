using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigTrashBomb : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Boss;
    public GameObject point;
    Vector3 dir;
    float Speed;
    float timer;
    Color C;
    void Start()
    {
        C = Color.white;
        dir = transform.position - point.transform.position;
        Speed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Boss.GetComponent<BigTrash>().HP <= 0) {
            transform.Translate(dir.normalized * Speed * Time.deltaTime, Space.World);

            if (C.a > 0)
                C.a -= Time.deltaTime/2;
            GetComponent<SpriteRenderer>().color = C;
        }
    }
}
