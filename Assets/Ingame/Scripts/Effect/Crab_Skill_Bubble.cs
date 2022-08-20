using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab_Skill_Bubble : MonoBehaviour
{
    ParticleSystem.ShapeModule shape;
    ParticleSystem.EmissionModule emisson;
    float timer;



    void Start()
    {
        shape = transform.GetComponent<ParticleSystem>().shape;
        emisson = transform.GetComponent<ParticleSystem>().emission;
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 0.5f)
        {
            shape.radius = Mathf.Lerp(shape.radius, 1f, Time.deltaTime * 0.5f);
            emisson.rateOverTime = 100f + timer * 10f;
        }
    }
}