using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSkill : MonoBehaviour
{
    public GameObject IceSound;
    GameObject Player1;
    public GameObject Prt;
    private void Start()
    {
        transform.tag = "FRZ";
        Destroy(transform.parent.gameObject, 2f);
        var b = Instantiate(IceSound, transform.position, Quaternion.Euler(0f, 0f, 0f));
    }

    // void OnParticleCollision(GameObject other)
    // {
    //     Debug.Log("파티클 충돌");
    // }
}
