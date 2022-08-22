using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleBeam : MonoBehaviour
{
    public ParticleSystem Beam;
    public ParticleSystem Razer;
    public CapsuleCollider2D Capsule;

    float timer;

    private void Start()
    {
        ParticleSystem.MainModule main = Beam.main;
        ParticleSystem.MainModule main2 = Razer.main;

        if (main.startRotation.mode == ParticleSystemCurveMode.Constant)
            main.startRotation = (-transform.eulerAngles.z) * Mathf.Deg2Rad;

        if (main2.startRotation.mode == ParticleSystemCurveMode.Constant)
            main2.startRotation = (-transform.eulerAngles.z) * Mathf.Deg2Rad;

        timer = 0f;

        Destroy(gameObject, 3.6f);
    }
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 2f)
            Capsule.enabled = true;
        if (timer >= 3f)
            Capsule.enabled = false;
    }
}
