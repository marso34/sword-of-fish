using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabSkillArmor : MonoBehaviour
{
    public PolygonCollider2D Polygon;
    float timer;

    void Start()
    {
        timer = 0f;
        Destroy(gameObject, 1f);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 0.2f)
            Polygon.enabled = true;
    }
}
