using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMove : MonoBehaviour
{
    Rigidbody2D RB;
    public bool MoveFlag;
    void Start()
    {
        MoveFlag = true;
        RB = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (MoveFlag)
        {
            if (GameObject.FindGameObjectWithTag("Potal") != null)
            {
                Vector3 P = new Vector3(GameObject.FindGameObjectWithTag("Potal").transform.position.x - transform.position.x, transform.position.y, transform.position.z);
                RB.velocity = P.normalized * 0.7f;
            }
        }
        else RB.velocity = Vector2.zero;
    }
}
