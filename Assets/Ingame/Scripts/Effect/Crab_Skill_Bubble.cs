using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab_Skill_Bubble : MonoBehaviour
{
    public ParticleSystem BubbleBeam;

    float timer;
    int Count;
    int MaxCnt;
    public Vector3 dir;
    void Start()
    {
        timer= 0f;
        MaxCnt = Random.Range(4, 7);
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
        timer += Time.deltaTime;

        if (timer >= 0.5f && Count < MaxCnt && GameObject.FindGameObjectWithTag("Player") != null)
        {
            dir = GameObject.FindGameObjectWithTag("Player").transform.position - transform.position;
            
            Vector3 V = new Vector3(-dir.y,dir.x,dir.z).normalized *(Random.Range(-4.1f,4.1f)) - dir;
            var bubble = Instantiate(BubbleBeam, transform.position,Quaternion.LookRotation(Vector3.forward,V ));
            bubble.transform.parent = transform;
            Debug.Log(Quaternion.LookRotation(Vector3.forward, dir.normalized).z);
            timer = 0.4f;
            Count++;
        }
    }
}