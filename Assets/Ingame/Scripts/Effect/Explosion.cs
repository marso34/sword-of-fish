using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update

    float timer = 0f;
    bool flag = true;
    void Start()
    {
        Destroy(gameObject, 1.3f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 0.6f) transform.tag = "Finish";
    }

    
}