using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMove : MonoBehaviour
{
    GameObject Player;
    GameObject[] CameraWall;
    Rigidbody2D RB;
    public bool MoveFlag;

    Vector3 position;

    void Start()
    {
        CameraWall = new GameObject[4];
        CameraWall = GameObject.FindGameObjectsWithTag("Finish");
        position = CameraWall[3].transform.position;
        MoveFlag = true;
        RB = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
            if (!Player.GetComponent<Player>().Life)
                MoveFlag = false;

            if (MoveFlag)
            {
                if (GameObject.FindGameObjectWithTag("Potal") != null)
                {
                    Vector3 P = GameObject.FindGameObjectWithTag("Potal").transform.position - transform.position;
                    RB.velocity = P.normalized * 3f;
                    CameraWall[3].GetComponent<Rigidbody2D>().velocity = P.normalized * 3f;
                }
            }
            else
            {
                RB.velocity = Vector2.zero;
                CameraWall[3].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                CameraWall[3].transform.position = position;
            }
        }
    }
}
