using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingCrab : Boss
{
    // Start is called before the first frame update
    void Start()
    {
        Life = true;
        HitFlag = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        GM = GameObject.FindGameObjectWithTag("GM");
        Circle = GetComponent<CircleCollider2D>();
        Skin = GetComponent<SpriteRenderer>();
        HP = 12;
        Speed = 3.8f;
        RotationSpeed = 800f;
        FRZFlag = false;
        S = transform.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
