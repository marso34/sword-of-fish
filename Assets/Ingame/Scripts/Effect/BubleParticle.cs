using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubleParticle : MonoBehaviour
{
    public ParticleSystem Buble;
    // Start is called before the first frame update
    void Start()
    {
        Buble = transform.GetChild(0).GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Buble != null)
        {
            transform.GetChild(0).localScale = transform.parent.localScale * 0.2f;
            ParticleSystem.MainModule main = Buble.main;
            ParticleSystem.EmissionModule emission = Buble.emission;

            float size = transform.parent.localScale.y;
            float speed = transform.parent.GetComponent<Player>().Speed;

            main.startSize = new ParticleSystem.MinMaxCurve(size * 0.15f, size * 0.4f);
            main.startSpeed = new ParticleSystem.MinMaxCurve(speed * 0.4f, speed * 0.8f);
            emission.rateOverTime = 3f + (speed * speed)/2;
        }
    }
}
