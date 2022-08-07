using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubleParticle : MonoBehaviour
{
    public ParticleSystem Buble;
    public float Speed;
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
            transform.GetChild(0).localScale = transform.parent.localScale * 0.3f;
            ParticleSystem.MainModule main = Buble.main;
            ParticleSystem.EmissionModule emission = Buble.emission;

            // float size = transform.parent.localScale.y;

            main.startSize = new ParticleSystem.MinMaxCurve(0.15f, 0.2f);
            main.startSpeed = new ParticleSystem.MinMaxCurve(Speed * 0.4f, Speed * 0.8f);
            emission.rateOverTime = 3f + (Speed * Speed)/2;
        }
    }
}
