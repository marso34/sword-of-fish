using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab_Skill_Bubble : MonoBehaviour
{
    public ParticleSystem BubbleBeam;

    float timer;
    int Count;
    int MaxCnt;

    void Start()
    {
        MaxCnt = Random.Range(3, 6);
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 0.5f && Count < MaxCnt)
        {
            var bubble = Instantiate(BubbleBeam, transform.position, Quaternion.Euler(0, 0, Random.Range(100f, 260f)));
            bubble.transform.parent = transform;
            timer = 0.4f;
            Count++;
        }
    }
}