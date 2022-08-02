using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEffect : MonoBehaviour
{
    public ParticleSystem ps;

    Material m;
    Sprite image;

    void Start()
    {
        ps = transform.GetChild(0).GetComponent<ParticleSystem>(); // 자식 파티클 -> 실질적인 파티클
        m = transform.GetChild(0).GetComponent<Renderer>().material; // 자식의 머티리얼
        image = transform.parent.GetComponent<SpriteRenderer>().sprite;
        
        m.SetTexture("_MainTex", image.texture);

        Quaternion toRotation = transform.parent.localRotation;
        transform.parent = null;
        transform.rotation = toRotation;

        Destroy(gameObject, 2f);
    }


    void Update()
    {

    }
}
