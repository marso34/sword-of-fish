using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMove : MonoBehaviour
{
    GameObject Player;
    GameObject[] CameraWall;
    Rigidbody2D RB;
    public bool MoveFlag;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        CameraWall = new GameObject[4];
        CameraWall = GameObject.FindGameObjectsWithTag("Finish");
        MoveFlag = true;
        RB = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (!Player.GetComponent<Player>().Life)
            MoveFlag = false;
            
        if (MoveFlag)
        {
            if (GameObject.FindGameObjectWithTag("Potal") != null)
            {
                Vector3 P = new Vector3(GameObject.FindGameObjectWithTag("Potal").transform.position.x - transform.position.x, transform.position.y, transform.position.z);
                RB.velocity = P.normalized * 2f;
                CameraWall[3].GetComponent<Rigidbody2D>().velocity = P.normalized * 2f;
            }
        }
        else
        {
            RB.velocity = Vector2.zero;
            CameraWall[3].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}
